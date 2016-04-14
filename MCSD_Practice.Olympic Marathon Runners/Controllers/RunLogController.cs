using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MCSD_Practice.Olympic_Marathon_Runners.Models;

namespace MCSD_Practice.Olympic_Marathon_Runners.Controllers
{
    public class RunLogController : Controller
    {
        private OMRContext db = new OMRContext();

        
        public ActionResult Index()
        {
            return View(db.LogModels.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogModel logModel = db.LogModels.Find(id);
            if (logModel == null)
            {
                return HttpNotFound();
            }
            return View(logModel);
        }

        
        public ActionResult Create()
        {
            LogModel log = new LogModel();
            log.RunDate = DateTime.Now;
            return View(log);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RunDate,Distance,Time")] LogModel logModel)
        {
            if (ModelState.IsValid)
            {
                db.LogModels.Add(logModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(logModel);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogModel logModel = db.LogModels.Find(id);
            if (logModel == null)
            {
                return HttpNotFound();
            }
            return View(logModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RunDate,Distance,Time")] LogModel logModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(logModel);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogModel logModel = db.LogModels.Find(id);
            if (logModel == null)
            {
                return HttpNotFound();
            }
            return View(logModel);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LogModel logModel = db.LogModels.Find(id);
            db.LogModels.Remove(logModel);
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
