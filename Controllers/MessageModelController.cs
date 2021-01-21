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
    public class MessageModelController : Controller
    {
        private OnTheBoardContext db = new OnTheBoardContext();

        public ActionResult Index()
        {
            var messages = db.Message.Include(s => s.SenderUser).Include(s => s.ReceiverUser);
            return View(messages.ToList());
        }

        //public ActionResult Index()
        //{
        //    DbSet<MessageModels> messages = db.Message;
        //    return View(messages.ToList());
        //}


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var query = db.Message.Include(s => s.SenderUser).Include(s => s.ReceiverUser).Where(i => i.ID == id);
            MessageModels message = query.Single();

            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var query = db.Message.Include(s => s.SenderUser).Include(s => s.ReceiverUser).Where(i => i.ID == id);
            MessageModels message = query.Single();

            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            MessageModels message = db.Message.Find(id);
            try
            {
                db.Message.Remove(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = String.Format("This element is coneted with other DB you cant remove it!");
                return View(message);
                // return RedirectToAction("Index");
            }
        }
    }
}