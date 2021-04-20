using BoardGame.DAL;
using BoardGame.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace BoardGame.Controllers
{
    [Authorize] 
    //oznacza ze potrzebne logowanie aby sie tu dostac
    public class UserModelController : Controller
    {
        private OnTheBoardContext db = new OnTheBoardContext();

        //[Authorize (Users = "admin@admin.pl")]
        [Authorize(Roles = "admin")]
        public ActionResult Index(string searchString)
        {
            System.Diagnostics.Debug.WriteLine(searchString);
            if (!String.IsNullOrEmpty(searchString))
            {
                List<UserModels> users1 = new List<UserModels>();
                users1 = db.User.ToList();
                List<UserModels> users3 = new List<UserModels>();
                foreach (var x in users1)
                {
                    if (x.Surname.ToLower().Contains(searchString.ToLower())) {
                        users3.Add(x);
                    }
                }
                return View(users3.ToList());
            }
            else
            {
                DbSet<UserModels> users2 = db.User;
                return View((users2.ToList()));
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index"); // przekierowanie do akcji index nic się nie zmieni
            }

            UserModels userModel = db.User.Find(id);

            if(userModel == null)
            {
                return HttpNotFound(); // mozna tu wyświetlic np statyczny kontent jakoś albo cokolwiek
            }
            return View(userModel);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            System.Diagnostics.Debug.WriteLine("DELETE USERMODEL CONTROLLER");
            UserModels userModel = db.User.Find(id);
            try {
                System.Diagnostics.Debug.WriteLine(userModel.Email);
                db.Review.RemoveRange(db.Review.Where(i => i.Author.ID == userModel.ID));
                db.Comment.RemoveRange(db.Comment.Where(i => i.Author.ID == userModel.ID));
                db.Advertisement.RemoveRange(db.Advertisement.Where(i => i.Author.ID == userModel.ID));
                db.Message.RemoveRange(db.Message.Where(i => (i.ReceiverUser.ID == userModel.ID || i.SenderUser.ID == userModel.ID)));
                db.Player.RemoveRange(db.Player.Where(i => i.Player.ID == userModel.ID));
                db.Friend.RemoveRange(db.Friend.Where(i => (i.MyFollowers.ID == userModel.ID || i.MyObservations.ID == userModel.ID)));
                new AccountController().DeleteConfirmed(userModel.Email);

                db.User.Remove(userModel);
                db.SaveChanges();


            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("TU RZUCAM");
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            UserModels userModel = db.User.Find(id);

            if (userModel == null)
            {
                return HttpNotFound();
            }
            return View(userModel);
        }


        [HttpPost, ActionName("Edit")]
        public ActionResult EditUser(UserModels userModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userModel);
        }

        public ActionResult Create()
        {
            return View();
        }


        // to co przyjdzie z funcji create wyrzej w tej funkcji zostanie powiazane z klasą modelu
        [HttpPost]
        public ActionResult Create(UserModels userModel)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(userModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userModel); // do formularza wrócą te dane bez tego zostały by puste
        }
        // dopisac edit i delete również z 2 akcji będą się składały // edit wyswietlimy tak jak w details tylko pola do edycji
        // edit jak details nastepnie dopisać za pomocą odpowiednich metod zedytować zapisać i niech to działa // edit zle dane?
        // wyswietlic wtedy odpowiedni widok

        // delete przekazane przez id czy pod tym id jest dany obiekt nastepnie go wyswietlimy i za pomoca odpowiedniej akcji


    }
}