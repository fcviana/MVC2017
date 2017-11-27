using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ADS.Models;

namespace ADS.Controllers
{
    
    public class EscolasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Escolas
        
        public ActionResult Index()
        {
            return View(db.Escola.ToList());
        }

        // GET: Escolas/Details/5
        [Authorize(Roles ="Admin, Assistente")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escola escola = db.Escola.Find(id);
            if (escola == null)
            {
                return HttpNotFound();
            }
            return View(escola);
        }

        // GET: Escolas/Create
        [Authorize(Roles = "Admin, Assistente")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Escolas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,cidade,estado,quantidade")] Escola escola)
        {
            if (ModelState.IsValid)
            {
                db.Escola.Add(escola);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(escola);
        }

        // GET: Escolas/Edit/5
        [Authorize(Roles = "Admin, Assistente")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escola escola = db.Escola.Find(id);
            if (escola == null)
            {
                return HttpNotFound();
            }
            return View(escola);
        }

        // POST: Escolas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,cidade,estado,quantidade")] Escola escola)
        {
            if (ModelState.IsValid)
            {
                db.Entry(escola).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(escola);
        }

        // GET: Escolas/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escola escola = db.Escola.Find(id);
            if (escola == null)
            {
                return HttpNotFound();
            }
            return View(escola);
        }

        // POST: Escolas/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Escola escola = db.Escola.Find(id);
            db.Escola.Remove(escola);
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
