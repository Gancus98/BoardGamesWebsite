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

        [Authorize]
        public ActionResult Index(int? id)
        {
            var query = db.User.Where(i => i.Email == User.Identity.Name);
            UserModels logedUser = query.Single();


            var viewModel = new MessageFriendViewModels();
            viewModel.Friends = db.Friend.Include(s => s.MyObservations).Where(i => i.MyFollowers.ID == logedUser.ID);

            if (id != null)
            {
                


                var query2 = db.Friend.Where(i => i.ID == id.Value);
                FriendModels friendship = query2.Single();
                System.Diagnostics.Debug.WriteLine("Myf MyO: ", friendship.MyFollowers, friendship.MyObservations, "---");
                var query3 = db.User.Where(i => i.ID == friendship.MyObservations.ID);
                UserModels receiver = query3.Single();


                // message isReaded
                List<MessageModels> messagesList = db.Message.Where(i => i.ReceiverUser.ID == logedUser.ID)
                    .Where(j => j.ReadDate == null)
                    .Where(j => j.SenderUser.ID == receiver.ID)
                    .ToList();
                foreach (var x in messagesList)
                {
                    System.Diagnostics.Debug.WriteLine("IN LOOP");
                    x.ReadDate = DateTime.Now;

                }
                db.SaveChanges();



                System.Diagnostics.Debug.WriteLine(receiver.ID);
                System.Diagnostics.Debug.WriteLine("---------------------------");
                System.Diagnostics.Debug.WriteLine("Chose friend: ", receiver.FullName, "---");

                ViewBag.FriendId = id.Value;
                viewModel.Messages = db.Message.Where(i => ((i.SenderUser.ID == logedUser.ID ||
                i.ReceiverUser.ID == logedUser.ID) && (i.ReceiverUser.ID == receiver.ID || i.SenderUser.ID == receiver.ID)));
            }

            return View(viewModel);


            //var messages = db.Message.Include(s => s.SenderUser).Include(s => s.ReceiverUser);
            //return View(messages.ToList());
        }

        //public ActionResult Index()
        //{
        //    DbSet<MessageModels> messages = db.Message;
        //    return View(messages.ToList());
        //}

        public ActionResult CreateExacly(int id)
        {
            System.Diagnostics.Debug.WriteLine(id);

            var query1 = db.User.Where(i => i.Email == User.Identity.Name);
            UserModels author = query1.Single();


            var query2 = db.Friend.Where(i => i.ID == id);
            FriendModels friendship = query2.Single();

            var query3 = db.User.Where(i => i.ID == friendship.MyObservations.ID);
            UserModels receiver = query3.Single();


            System.Diagnostics.Debug.WriteLine("Author", author.FullName);
            System.Diagnostics.Debug.WriteLine("Receiver", receiver.FullName);

            MessageModels message = new MessageModels();
            message.Contents = Request.Form["inputarea"];
            message.ReceiverUser = receiver;
            message.SenderUser = author;
            message.IsDeleted = false;
            message.PostDate = DateTime.Now;
            message.ReadDate = null;

            db.Message.Add(message);
            db.SaveChanges();


            return RedirectToAction("Index", "MessageModel", new { id });
        }

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