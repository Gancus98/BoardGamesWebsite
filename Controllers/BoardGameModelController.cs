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
    public class BoardGameModelController : Controller
    {
        private OnTheBoardContext db = new OnTheBoardContext();
        public ActionResult Index()
        {
            DbSet<BoardGameModels> games = db.BoardGame;
            return View(games.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            BoardGameModels game = db.BoardGame.Find(id);

            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BoardGameModels game)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.BoardGame.Add(game);
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
            BoardGameModels game = db.BoardGame.Find(id);

            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        [HttpPost]
        public ActionResult Edit(BoardGameModels game)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(game).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(game);
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
            BoardGameModels game = db.BoardGame.Find(id);

            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            BoardGameModels game = db.BoardGame.Find(id);
            try
            {
                db.BoardGame.Remove(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
               ViewBag.Message = String.Format("This element is coneted with other DB you cant remove it!");
               return View(game);
               // return RedirectToAction("Index");
            }
        }
    }
}
