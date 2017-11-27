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
    public class EstudantesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Estudantes
           public ActionResult Index()
        {
            var estudante = db.Estudante.Include(e => e.escola);
            return View(estudante.ToList());
        }

        // GET: Estudantes/Details/5
        [Authorize(Roles = "Admin, Assistente")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudante estudante = db.Estudante.Find(id);
            if (estudante == null)
            {
                return HttpNotFound();
            }
            return View(estudante);
        }

        // GET: Estudantes/Create
        [Authorize(Roles = "Admin, Assistente")]
        public ActionResult Create()
        {
            ViewBag.EscolaId = new SelectList(db.Escola, "id", "nome");
            return View();
        }

        // POST: Estudantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nomeAlu,EscolaId")] Estudante estudante)
        {
            if (ModelState.IsValid)
            {
                Escola escola = db.Escola.Find(estudante.EscolaId);
                escola.quantidade++;
                db.Estudante.Add(estudante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EscolaId = new SelectList(db.Escola, "id", "nome", estudante.EscolaId);
            return View(estudante);
        }

        // GET: Estudantes/Edit/5
        [Authorize(Roles = "Admin, Assistente")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudante estudante = db.Estudante.Find(id);
            if (estudante == null)
            {
                return HttpNotFound();
            }
            ViewBag.EscolaId = new SelectList(db.Escola, "id", "nome", estudante.EscolaId);
            return View(estudante);
        }

        // POST: Estudantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nomeAlu,EscolaId")] Estudante estudante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EscolaId = new SelectList(db.Escola, "id", "nome", estudante.EscolaId);
            return View(estudante);
        }

        // GET: Estudantes/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudante estudante = db.Estudante.Find(id);
            if (estudante == null)
            {
                return HttpNotFound();
            }
            return View(estudante);
        }

        // POST: Estudantes/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estudante estudante = db.Estudante.Find(id);
            db.Estudante.Remove(estudante);
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
