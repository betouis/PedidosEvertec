using PlacetoPay.Integrations.Library.CSharp.Contracts;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using PediosEvertec.Models;

namespace PediosEvertec.IntegracionEvertec
{
    public class IntegracionEvertec
    {
        private const string login = "6dd490faf9cb87a9862245da41170ff2";
        private const string tranKey = "024h1IlD";
        private const string urlString = @"https://test.placetopay.com/redirection/api/session/";

        public async Task<ResponseEvertecPago> InitAsync(Pedido pedido, string producto, double valor)
        {
            return await AutenticacionAsync(pedido, producto, valor);
        }
        public async Task<ResponseEvertecPago> AutenticacionAsync(Pedido pedido, string producto, double valor)
        {

            string nonce = (new Random()).GetHashCode().ToString();
            string nonceBase64 = Base64(nonce);
            string seed = (DateTime.Now.AddMinutes(4)).ToString("yyyy-MM-ddTHH:mm:sszzz");
            string keySend = Base64(ToSha1(nonce + seed + tranKey));
            Uri url = new Uri(urlString);

            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                EnvioDatos dataEnviar = new EnvioDatos()
                {
                    auth = new autorizacion()
                    {
                        login = login,
                        nonce = nonceBase64,
                        seed = seed,
                        tranKey = keySend
                    },
                    locale = "es_CO",
                    payment = new Pago()
                    {
                        allowPartial = false,
                        amount = new Cantidad()
                        {
                            currency = "COP",
                            total = valor.ToString()
                        },
                        description = "Pedido Evertec Producto " + producto,
                        reference = pedido.id.ToString()
                    },
                    payer = new Pagador()
                    {
                        document = pedido.customer_document,
                        documentType = "CC",
                        email = pedido.customer_email,
                        name = pedido.customer_name,
                        surname = pedido.customer_lastname,
                        mobile = pedido.customer_mobile
                    },
                    expiration = (DateTime.Now.AddDays(4)).ToString("yyyy-MM-ddTHH:mm:sszzz"),
                    returnUrl = "http://localhost:60756/",
                    userAgent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.82 Safari/537.36",
                    ipAddress = "127.0.0.1"
                };

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                string userContenido = ser.Serialize(dataEnviar);

                HttpClient cliente = new HttpClient();
                string contenido = userContenido;
                HttpContent content = new StringContent(contenido, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await cliente.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    string resultadoToken = await response.Content.ReadAsStringAsync();
                    ResponseEvertecPago res = ser.Deserialize<ResponseEvertecPago>(resultadoToken);
                    return res;
                }
                else
                {
                    string resultadoToken = await response.Content.ReadAsStringAsync();
                    throw new Exception("Error generando el pago");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error generando el pago");
            }

        }


        static public String Base64(byte[] input)
        {
            return System.Convert.ToBase64String(input);
        }

        static public String Base64(String input)
        {
            if (input != null)
            {
                return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(input));
            }
            return "";
        }

        static public byte[] ToSha1(String text)
        {
            System.Security.Cryptography.SHA1 hashString = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            return hashString.ComputeHash(ToStream(text));
        }

        static public Stream ToStream(String text)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter sw = new StreamWriter(stream);
            sw.Write(text);
            sw.Flush();
            stream.Position = 0;
            return stream;
        }

    }
}