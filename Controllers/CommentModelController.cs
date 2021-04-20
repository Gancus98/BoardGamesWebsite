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
    public class CommentModelController : Controller
    {
        private OnTheBoardContext db = new OnTheBoardContext();

        public ActionResult Index()
        {
            var comments = db.Comment.Include(s => s.Author).Include(s => s.Review);
            return View(comments.ToList());
        }


        //public ActionResult Create()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult Create(ReviewModels review, int id/*int id, string content*/)
        {
            try
            {
                    CommentModels comment1 = new CommentModels();

                    var query = db.User.Where(i => i.Email == User.Identity.Name);
                    UserModels user = query.Single();
                    comment1.Author = user;

                    var query2 = db.Review.Where(i => i.ID == id);
                    ReviewModels review2 = query2.Single();


                    comment1.Review = review2;
                    System.Diagnostics.Debug.WriteLine(review.ID);
                    comment1.PostDate = DateTime.Now;
                    comment1.Contents = Request.Form["textarea"];
                    if (ModelState.IsValid)
                    {
                        db.Comment.Add(comment1);
                        db.SaveChanges();
                        return RedirectToAction("Details", "ReviewModel", new { id });
                    }
                    return RedirectToAction("Details", "ReviewModel", new { id });


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

            var query = db.Comment.Include(s => s.Author).Include(s => s.Review).Where(i => i.ID == id);
            CommentModels comment = query.Single();

            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }


        public ActionResult DeleteExacly(int? id)
        {
            System.Diagnostics.Debug.WriteLine("DeleteExacly");
            CommentModels comment = db.Comment.Find(id);
            var id2 = comment.Review.ID;
            System.Diagnostics.Debug.WriteLine(id2);
            try
            {
                db.Comment.Remove(comment);
                db.SaveChanges();
                return RedirectToAction("Details", "ReviewModel", new { id = id2 });
            }
            catch
            {
                ViewBag.Message = String.Format("This element is coneted with other DB you cant remove it!");
                //return RedirectToAction("Details", "ReviewModel", new { id });
                return RedirectToAction("Details", "ReviewModel", new { id = id2 });
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var query = db.Comment.Include(s => s.Author).Include(s => s.Review).Where(i => i.ID == id);
            CommentModels comment = query.Single();

            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            CommentModels comment = db.Comment.Find(id);
            try
            {
                db.Comment.Remove(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = String.Format("This element is coneted with other DB you cant remove it!");
                return View(comment);
                // return RedirectToAction("Index");
            }
        }

        

    }
}