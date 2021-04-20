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


        [HttpPost]
        public ActionResult Create(PlayerModels player, int id/*int id, string content*/)
        {
            try
            {
                PlayerModels player1 = new PlayerModels();

                var query = db.User.Where(i => i.Email == User.Identity.Name);
                UserModels user = query.Single();

                var query2 = db.Advertisement.Where(i => i.ID == id);
                AdvertisementModels adv = query2.Single();

                player1.Player = user;
                player1.Advertisement = adv;

                PlayerModels testPlayer = new PlayerModels();
                testPlayer.Advertisement = adv;
                testPlayer.Player = user;
                var test = db.Player
                    .Where(b => b.Player.ID == user.ID)
                    .Where(c => c.Advertisement.ID == adv.ID)
                    .FirstOrDefault();

                if (test != null)
                {
                    System.Diagnostics.Debug.WriteLine("You are already added to the game!");
                    return RedirectToAction("Details", "AdvertisementModel", new { id });
                }


                if (ModelState.IsValid)
                {
                    System.Diagnostics.Debug.WriteLine("IS WALID");
                    db.Player.Add(player1);
                    db.SaveChanges();
                    return RedirectToAction("Details", "AdvertisementModel", new { id });
                }
                return RedirectToAction("Details", "AdvertisementModel", new { id });


            }
            catch
            {
                return View();
            }
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

      
        public ActionResult DeleteExacly(int? id)
        {
            var query = db.User.Where(i => i.Email == User.Identity.Name);
            UserModels user = query.Single();
            System.Diagnostics.Debug.WriteLine(id);

            try
            {
                var query2 = db.Player.Where(i => i.Player.ID == user.ID).Where(j => j.Advertisement.ID == id);
                PlayerModels player = query2.Single();
                db.Player.Remove(player);
                db.SaveChanges();
                return RedirectToAction("Details", "AdvertisementModel", new { id });
            }
            catch
            {
                return RedirectToAction("Details", "AdvertisementModel", new { id });
            }
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