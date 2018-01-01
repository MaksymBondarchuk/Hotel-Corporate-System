using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel_Corporate_System.Models.Database;

namespace Hotel_Corporate_System.Controllers
{
    public class ClientServicesController : Controller
    {
        private HotelContext db = new HotelContext();

        // GET: ClientServices
        public ActionResult Index()
        {
            var clientServices = db.ClientServices.Include(c => c.Bill).Include(c => c.Client).Include(c => c.Service);
            return View(clientServices.ToList());
        }

        // GET: ClientServices/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientService clientService = db.ClientServices.Find(id);
            if (clientService == null)
            {
                return HttpNotFound();
            }
            var service = db.Services.Find(clientService.ServiceId);
            clientService.Service = service;
            var client = db.Clients.Find(clientService.ClientId);
            clientService.Client = client;
            return View(clientService);
        }

        // GET: ClientServices/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name");
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Name");
            return View();
        }

        // POST: ClientServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Comment,Date,ActualAmount,ClientId,ServiceId,BillId")] ClientService clientService)
        {
            if (ModelState.IsValid)
            {
                clientService.Id = Guid.NewGuid();
                var bill = new Bill { Amount = clientService.ActualAmount };
                db.Bills.Add(bill);

                clientService.BillId = bill.Id;
                db.ClientServices.Add(clientService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", clientService.ClientId);
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Name", clientService.ServiceId);
            return View(clientService);
        }

        // GET: ClientServices/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientService clientService = db.ClientServices.Find(id);
            if (clientService == null)
            {
                return HttpNotFound();
            }
            ViewBag.BillId = new SelectList(db.Bills, "Id", "Id", clientService.BillId);
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", clientService.ClientId);
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Name", clientService.ServiceId);
            return View(clientService);
        }

        // POST: ClientServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Comment,Date,ActualAmount,ClientId,ServiceId,BillId")] ClientService clientService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BillId = new SelectList(db.Bills, "Id", "Id", clientService.BillId);
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", clientService.ClientId);
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Name", clientService.ServiceId);
            return View(clientService);
        }

        // GET: ClientServices/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientService clientService = db.ClientServices.Find(id);
            if (clientService == null)
            {
                return HttpNotFound();
            }
            return View(clientService);
        }

        // POST: ClientServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ClientService clientService = db.ClientServices.Find(id);
            db.ClientServices.Remove(clientService);
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
