using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PediosEvertec.IntegracionEvertec
{
    public class autorizacion
    {
        public string login { get; set; }
        public string seed { get; set; }
        public string nonce { get; set; }
        public string tranKey { get; set; }
    }

    public class Cantidad
    {
        public string currency { get; set; }
        public string total { get; set; }
    }

    public class Pago
    {
        public string reference { get; set; }
        public string description { get; set; }
        public Cantidad amount { get; set; }

        public bool allowPartial { get; set; }
    }

    public class Pagador
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string document { get; set; }
        public string documentType { get; set; }

        public string mobile { get; set; }
    }

    public class EnvioDatos
    {

        public string locale { get; set; }
        public string expiration { get; set; }

        public string returnUrl { get; set; }

        public string userAgent { get; set; }

        public string ipAddress { get; set; }

        public autorizacion auth { get; set; }
        public Pago payment { get; set; }

        public Pagador payer { get; set; }

    }

    public class StatusPago
    {
        public string status { get; set; }
        public string reason { get; set; }
        public string message { get; set; }
        public string date { get; set; }

    }
    public class ResponseEvertecPago
    {
        public StatusPago status { get; set; }
        public string requestId { get; set; }

        public string processUrl { get; set; }
    }

    public enum StatusPedido
    {
        CREATED = 1, PAYED = 2, REJECTED = 3
    }
}