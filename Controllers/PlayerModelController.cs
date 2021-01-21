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
    public class PlayerModelController : Controller
    {
        private OnTheBoardContext db = new OnTheBoardContext();

        public ActionResult Index()
        {
            var players = db.Player.Include(s => s.Player).Include(s => s.Advertisement);
            return View(players.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var query = db.Player.Include(s => s.Player).Include(s => s.Advertisement).Where(i => i.ID == id);
            PlayerModels player = query.Single();

            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var query = db.Player.Include(s => s.Player).Include(s => s.Advertisement).Where(i => i.ID == id);
            PlayerModels player = query.Single();

            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            PlayerModels player = db.Player.Find(id);
            try
            {
                db.Player.Remove(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = String.Format("This element is coneted with other DB you cant remove it!");
                return View(player);
            }
        }
    }
}