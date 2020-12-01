using BoardGame.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BoardGame.DAL
{
    public class OnTheBoardDBInitializer<T>:DropCreateDatabaseAlways<OnTheBoardContext>
    {
        protected override void Seed(OnTheBoardContext context)
        {
            UserModels user = new Models.UserModels()
            {
                Name = "Jan",
                Surname = "Kowalski",
                Phone = 555111222,
                Email = "jan@email.com"
                //Reviews = new List<ReviewModels>
                //    {
                //        new Models.ReviewModels() { Title = "Pierwsza", Contents = "Treść" }
                //    }
            };
            context.User.Add(user);
            context.SaveChanges();

        }
    }
}