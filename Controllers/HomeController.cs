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
    public class HomeController : Controller
    {
        private OnTheBoardContext db = new OnTheBoardContext();
        public ActionResult Index()
        {
            DbSet<ReviewModels> reviews = db.Review;
            return View(reviews.ToList());
            
        }

        public ActionResult About()
        {
            List<ReviewModels>reviews = db.Review.ToList();


            if (reviews.Count < 3)
            {
                return View(reviews);
            }
            List<DateTime> datesOfPublication = new List<DateTime>();
            System.Diagnostics.Debug.WriteLine(reviews.Count);
            foreach (var item in reviews)
            {
                datesOfPublication.Add(item.DateOfPublication);

            }

            DateTime first = datesOfPublication.Max();
            ReviewModels a = new ReviewModels();
            foreach (var item in reviews)
            {
                if (item.DateOfPublication == first)
                {
                    a = item;
                }
            }
            reviews.Remove(a);
            datesOfPublication.Clear();
            System.Diagnostics.Debug.WriteLine(reviews.Count);
            foreach (var item in reviews)
            {
                datesOfPublication.Add(item.DateOfPublication);

            }
            DateTime second = datesOfPublication.Max();
            ReviewModels b = new ReviewModels();
            foreach (var item in reviews)
            {
                if (item.DateOfPublication == second)
                {
                    b = item;
                }
            }
            reviews.Remove(b);
            datesOfPublication.Clear();
            foreach (var item in reviews)
            {
                datesOfPublication.Add(item.DateOfPublication);

            }
            DateTime third = datesOfPublication.Max();
            ReviewModels c = new ReviewModels();
            foreach (var item in reviews)
            {
                if (item.DateOfPublication == third)
                {
                    c = item;
                }
            }
            reviews.Remove(c);

            List<ReviewModels> newestReview = new List<ReviewModels>();
            newestReview.Add(a);
            newestReview.Add(b);
            newestReview.Add(c);
    

            return View(newestReview);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}