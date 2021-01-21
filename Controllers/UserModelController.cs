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
    [Authorize] 
    //oznacza ze potrzebne logowanie aby sie tu dostac
    public class UserModelController : Controller
    {
        private OnTheBoardContext db = new OnTheBoardContext();

        //[Authorize (Users = "admin@admin.pl")]
        [Authorize(Roles = "admin")]
        public ActionResult Index(int? id)
        {
            var viewModel = new BoardViewModels();
            viewModel.Users = db.User.Include(s => s.Reviews);

            if (id != null)
            {
                ViewBag.UserId = id.Value;
                viewModel.Reviews = db.Review.Where(i => i.Author.ID == id.Value).Include(r => r.BoardGame).Include(u=>u.Author);
            }

            return View(viewModel);
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

        public ActionResult Delete(int? id)
        {
            UserModels userModel = db.User.Find(id);
            db.User.Remove(userModel);
            db.SaveChanges();
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