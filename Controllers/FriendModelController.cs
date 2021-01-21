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
    public class FriendModelController : Controller
    {
        private OnTheBoardContext db = new OnTheBoardContext();

        public ActionResult Index()
        {
            var friends = db.Friend.Include(s => s.MyFollowers).Include(s => s.MyObservations);
            return View(friends.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var query = db.Friend.Include(s => s.MyFollowers).Include(s => s.MyObservations).Where(i => i.ID == id);
            FriendModels friend = query.Single();

            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }
    }
}