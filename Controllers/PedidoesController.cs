using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PediosEvertec.Models;
using PediosEvertec.IntegracionEvertec;
using System.Threading.Tasks;

namespace PediosEvertec.Controllers
{
    public class PedidoesController : Controller
    {
        private ModelPedidos db = new ModelPedidos();

        // GET: Pedidoes
        public ActionResult Index()
        {
            var pedido = db.Pedido.Include(p => p.product);
            return View(pedido.ToList());
        }

        // GET: Pedidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedidoes/Create
        public ActionResult Create(int? id)
        {
            product producto = db.product.Where(x => x.id == id).FirstOrDefault();
            ViewBag.product = producto;
            return View();
        }

        // POST: Pedidoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,customer_name,customer_email,customer_mobile,status,created_at,updated_at,product_id,customer_document,customer_lastname")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                string url = Request.Url.GetLeftPart(UriPartial.Authority) + "/";
                PediosEvertec.IntegracionEvertec.IntegracionEvertec integracion =
                    new PediosEvertec.IntegracionEvertec.IntegracionEvertec();
                pedido.created_at = DateTime.Now;
                pedido.updated_at = DateTime.Now;
                pedido.status = StatusPedido.CREATED.ToString();
                product pr = db.product.Where(x => x.id == pedido.product_id).FirstOrDefault();
                db.Pedido.Add(pedido);
                db.SaveChanges();
                ResponseEvertecPago pago = await integracion.InitAsync(url, pedido, pr.name_product, pr.value_product.Value);
                pedido.processUrl = pago.processUrl;
                pedido.fechaProcess = DateTime.Now;
                pedido.requestId = pago.requestId;
                db.SaveChanges();
                return Redirect(pago.processUrl);
                // return RedirectToAction("Index");
            }
            else
            {
                return View(pedido);
            }

            // return RedirectToAction("Index", "products");
        }

        // GET: Pedidoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            PediosEvertec.IntegracionEvertec.IntegracionEvertec ie = new PediosEvertec.IntegracionEvertec.IntegracionEvertec();
            ResponseEvertecPago respuesta = await ie.EstadoAsync(pedido);
            pedido.status = respuesta.status.status;
            db.SaveChanges();
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,customer_name,customer_email,customer_mobile,status,created_at,updated_at,product_id")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.product_id = new SelectList(db.product, "id", "code_product", pedido.product_id);
            return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedido.Find(id);
            db.Pedido.Remove(pedido);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
