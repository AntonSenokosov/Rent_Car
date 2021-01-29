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
    public class TypeBodiesController : Controller
    {
        private EFDbContext db = new EFDbContext();

        // GET: TypeBodies
        public async Task<ActionResult> Index()
        {
            return View(await db.TypeBodies.ToListAsync());
        }

        // GET: TypeBodies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeBody typeBody = await db.TypeBodies.FindAsync(id);
            if (typeBody == null)
            {
                return HttpNotFound();
            }
            return View(typeBody);
        }

        // GET: TypeBodies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeBodies/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BodyId,NameBody")] TypeBody typeBody)
        {
            if (ModelState.IsValid)
            {
                db.TypeBodies.Add(typeBody);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(typeBody);
        }

        // GET: TypeBodies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeBody typeBody = await db.TypeBodies.FindAsync(id);
            if (typeBody == null)
            {
                return HttpNotFound();
            }
            return View(typeBody);
        }

        // POST: TypeBodies/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BodyId,NameBody")] TypeBody typeBody)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeBody).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(typeBody);
        }

        // GET: TypeBodies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeBody typeBody = await db.TypeBodies.FindAsync(id);
            if (typeBody == null)
            {
                return HttpNotFound();
            }
            return View(typeBody);
        }

        // POST: TypeBodies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TypeBody typeBody = await db.TypeBodies.FindAsync(id);
            db.TypeBodies.Remove(typeBody);
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
