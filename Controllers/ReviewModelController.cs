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

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.BoardGame_Id = new SelectList(db.BoardGame, "ID", "Title");
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
        [Authorize]
        public ActionResult Create([Bind(Include = "ID, Title, Photo, Contents, DateOfPublication")] ReviewModels review, int BoardGame_Id)
        {
            System.Diagnostics.Debug.WriteLine("CREATE REVIEW");
            var query = db.User.Where(i => i.Email == User.Identity.Name);
            UserModels user = query.Single();
            review.Author = user;
            review.DateOfPublication = DateTime.Now;
            var query2 = db.BoardGame.Where(i => i.ID == BoardGame_Id);
            BoardGameModels game = query2.Single();
            review.BoardGame = game;

            System.Diagnostics.Debug.WriteLine(BoardGame_Id);
            if (ModelState.IsValid)
            {
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
            review.Comments.Clear();
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