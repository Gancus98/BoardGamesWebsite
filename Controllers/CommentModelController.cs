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