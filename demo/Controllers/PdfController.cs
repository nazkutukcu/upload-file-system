using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using demo.Models;

namespace demo.Controllers
{
    public class PdfController : Controller
    {
        private PdfUploadDBEntities db = new PdfUploadDBEntities();

        // GET: Pdf
        public ActionResult Index()
        {
            return View(db.DuyuruFileUrls.ToList());
        }

        // GET: Pdf/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DuyuruFileUrl duyuruFileUrl = db.DuyuruFileUrls.Find(id);
            if (duyuruFileUrl == null)
            {
                return HttpNotFound();
            }
            return View(duyuruFileUrl);
        }

        // GET: Pdf/Create
        public ActionResult Create()
        {
            return View();
        }
       

        // POST: Pdf/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Url,UserID,FileName,Title,CreateDate,UserName")] DuyuruFileUrl duyuruFileUrl)
        {
            
            if (ModelState.IsValid)
            {
                db.DuyuruFileUrls.Add(duyuruFileUrl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(duyuruFileUrl);
        }

        // GET: Pdf/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DuyuruFileUrl duyuruFileUrl = db.DuyuruFileUrls.Find(id);
            if (duyuruFileUrl == null)
            {
                return HttpNotFound();
            }
            return View(duyuruFileUrl);
        }

        // POST: Pdf/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Url,UserID,FileName,Title,CreateDate,UserName")] DuyuruFileUrl duyuruFileUrl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(duyuruFileUrl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(duyuruFileUrl);
        }

        // GET: Pdf/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DuyuruFileUrl duyuruFileUrl = db.DuyuruFileUrls.Find(id);
            if (duyuruFileUrl == null)
            {
                return HttpNotFound();
            }
            return View(duyuruFileUrl);
        }

        // POST: Pdf/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DuyuruFileUrl duyuruFileUrl = db.DuyuruFileUrls.Find(id);
            db.DuyuruFileUrls.Remove(duyuruFileUrl);
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
