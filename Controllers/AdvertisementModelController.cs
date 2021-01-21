using BoardGame.DAL;
using BoardGame.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoardGame.Controllers
{
    public class AdvertisementModelController : Controller
    {
        private OnTheBoardContext db = new OnTheBoardContext();
        public ActionResult Index()
        {
            DbSet<AdvertisementModels> advertisements = db.Advertisement;
            return View(advertisements.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            AdvertisementModels advertisement = db.Advertisement.Find(id);

            if (advertisement == null)
            {
                return HttpNotFound();
            }
            return View(advertisement);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AdvertisementModels advertisement)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Advertisement.Add(advertisement);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            AdvertisementModels advertisement = db.Advertisement.Find(id);

            if (advertisement == null)
            {
                return HttpNotFound();
            }
            return View(advertisement);
        }

        [HttpPost]
        public ActionResult Edit(AdvertisementModels advertisement)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(advertisement).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(advertisement);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            AdvertisementModels advertisement = db.Advertisement.Find(id);

            if (advertisement == null)
            {
                return HttpNotFound();
            }
            return View(advertisement);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            AdvertisementModels advertisement = db.Advertisement.Find(id);
            try
            {
                db.Advertisement.Remove(advertisement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = String.Format("This element is coneted with other DB you cant remove it!");
                return View(advertisement);
                // return RedirectToAction("Index");
            }
        }
    }
}