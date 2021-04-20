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


        
        public ActionResult InviteToFriend(string myEmail, string friendEmail, int advId)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("Próba dodania przyjaciela");
                System.Diagnostics.Debug.WriteLine(myEmail);
                System.Diagnostics.Debug.WriteLine(friendEmail);
                var query1 = db.User.Where(i => i.Email == myEmail);
                UserModels user1 = query1.Single();

                var query2 = db.User.Where(i => i.Email == friendEmail);
                UserModels user2 = query2.Single();

                FriendModels friendship = new FriendModels();
                friendship.MyObservations = user2;
                friendship.MyFollowers = user1;
                friendship.StartDate = DateTime.Now;

                FriendModels friendship2 = new FriendModels();
                friendship2.MyObservations = user1;
                friendship2.MyFollowers = user2;
                friendship2.StartDate = DateTime.Now;


                db.Friend.Add(friendship);
                db.Friend.Add(friendship2);
                db.SaveChanges();
                return RedirectToAction("Details", "AdvertisementModel", new { id = advId });
            }
            catch
            {
                return RedirectToAction("Details", "AdvertisementModel", new { id = advId });
            }
        }

        [Authorize]
        public ActionResult Index(string searchString)
        {
            System.Diagnostics.Debug.WriteLine(searchString);
            if (!String.IsNullOrEmpty(searchString))
            {
                List<AdvertisementModels> advertisement = new List<AdvertisementModels>();
                advertisement = db.Advertisement.Where(s => s.City == searchString).ToList();
                return View(advertisement);
            } else
            {
                DbSet<AdvertisementModels> advertisements2 = db.Advertisement;
                return View((advertisements2.ToList()));
            }
            
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
            ViewBag.BoardGame_Id = new SelectList(db.BoardGame, "ID", "Title");
            return View();
        }

        [HttpPost]
        public ActionResult Create(AdvertisementModels advertisement, int BoardGame_Id)
        {
            try
            {
                var query2 = db.BoardGame.Where(i => i.ID == BoardGame_Id);
                BoardGameModels game = query2.Single();
                var query = db.User.Where(i => i.Email == User.Identity.Name);
                UserModels user = query.Single();
                advertisement.Author = user;
                advertisement.BoardGame = game;
                advertisement.IsActive = true;
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
            System.Diagnostics.Debug.WriteLine("Delete advmodel");
            AdvertisementModels advertisement = db.Advertisement.Find(id);
            try
            {
                advertisement.Players.Clear();
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