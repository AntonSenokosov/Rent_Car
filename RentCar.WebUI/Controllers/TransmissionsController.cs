using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentCar.Domain.Concrete;
using RentCar.Domain.Entities;

namespace RentCar.WebUI.Controllers
{
    public class TransmissionsController : Controller
    {
        private EFDbContext db = new EFDbContext();

        // GET: Transmissions
        public async Task<ActionResult> Index()
        {
            return View(await db.Transmissions.ToListAsync());
        }

        // GET: Transmissions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transmission transmission = await db.Transmissions.FindAsync(id);
            if (transmission == null)
            {
                return HttpNotFound();
            }
            return View(transmission);
        }

        // GET: Transmissions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transmissions/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TransmissionId,NameTransmission")] Transmission transmission)
        {
            if (ModelState.IsValid)
            {
                db.Transmissions.Add(transmission);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(transmission);
        }

        // GET: Transmissions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transmission transmission = await db.Transmissions.FindAsync(id);
            if (transmission == null)
            {
                return HttpNotFound();
            }
            return View(transmission);
        }

        // POST: Transmissions/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TransmissionId,NameTransmission")] Transmission transmission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transmission).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(transmission);
        }

        // GET: Transmissions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transmission transmission = await db.Transmissions.FindAsync(id);
            if (transmission == null)
            {
                return HttpNotFound();
            }
            return View(transmission);
        }

        // POST: Transmissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Transmission transmission = await db.Transmissions.FindAsync(id);
            db.Transmissions.Remove(transmission);
            await db.SaveChangesAsync();
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
