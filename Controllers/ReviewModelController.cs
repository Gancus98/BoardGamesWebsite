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
    public class ReviewModelController : Controller
    {
        private OnTheBoardContext db = new OnTheBoardContext();
        public ActionResult Index(string BoardGame_Id)
        {
            ViewBag.BoardGame_Id = new SelectList(db.BoardGame, "Title", "Title");

            var reviews = db.Review.Include(s => s.BoardGame).Include(s => s.Author);

            if (!String.IsNullOrEmpty(BoardGame_Id))
            {
                reviews = reviews.Where(s => s.BoardGame.Title.Contains(BoardGame_Id));
            }

            return View(reviews.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            ReviewModels game = db.Review.Find(id);

            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        public ActionResult Create()
        {
            ViewBag.BoardGame_Id = new SelectList(db.BoardGame, "ID", "Title");
            ViewBag.Author_Id = new SelectList(db.User, "ID", "FullName");
            return View();
        }

        //[HttpPost]
        //public ActionResult Create([Bind(Exclude = "ID, Title, DateOfPublication, Author_Id, BoardGame_Id")] ReviewModels review)
        //{
        //    System.Diagnostics.Debug.WriteLine("[ReviewModelController - Create]", review.Author);
            
        //    if (ModelState.IsValid)
        //    {
        //        db.Review.Add(review);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.BoardGame_ID = new SelectList(db.BoardGame, "ID", "Title", review.BoardGame.ID);
        //    ViewBag.Author_ID = new SelectList(db.User, "ID", "FullName", review.Author.ID);

        //    return View(review);
        //}

        [HttpPost]
        public ActionResult Create([Bind(Include = "ID, Title, Photo, Contents, DateOfPublication")] ReviewModels review, int Author_Id, int BoardGame_Id)
        {
            if (ModelState.IsValid)
            {
                var query1 = db.User.Where(i => i.ID == Author_Id);
                UserModels user = query1.Single();
                review.Author = user;

                var query2 = db.BoardGame.Where(i => i.ID == BoardGame_Id);
                BoardGameModels game = query2.Single();
                review.BoardGame = game;

                db.Review.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BoardGame_Id = new SelectList(db.BoardGame, "Id", "Title", review.BoardGame.ID);
            ViewBag.Author_Id = new SelectList(db.User, "Id", "FullName", review.Author.ID);

            return View(review);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            ReviewModels game = db.Review.Find(id);

            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        [HttpPost]
        public ActionResult Edit(ReviewModels review)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(review).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(review);
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
            ReviewModels game = db.Review.Find(id);

            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            ReviewModels review = db.Review.Find(id);
            try
            {
                db.Review.Remove(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = String.Format("This element is coneted with other DB you cant remove it!");
                return View(review);
                // return RedirectToAction("Index");
            }
        }
    }
}