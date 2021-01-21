using BoardGame.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BoardGame.DAL
{
    public class OnTheBoardDBInitializer<T>: DropCreateDatabaseAlways<OnTheBoardContext>
    {
        protected override void Seed(OnTheBoardContext context)
        {
            BoardGameModels game1 = new Models.BoardGameModels()
            {
                Title = "Tajniacy",
                Designer = "Vlaada CHavatil",
                Publisher = "Rebel",
                NumberOfPlayers = "2-6",
                RecommendedAge = 10,
                Description = "Dwie drużyny, którym przewodzi dwóch Szefów Wywiadu, próbują" +
                " jak najszybciej nawiązać kontakt ze wszystkimi swoimi agentami. " +
                " Problem leży w tym, że Szef Wywiadu może podawać swojej drużynie " +
                " tylko jedno hasło na turę, którym powiąże ze sobą kilka widocznych " +
                " dla wszystkich kryptonimów. Drużyna musi domyśleć się, który z prezentowanych " +
                " kryptonimów należy do agentów ich drużyny, omijając cudzych agentów. " +
                " Ale uwaga! Jeden z kryptonimów należy do zabójcy..."
            };
            context.BoardGame.Add(game1);
            BoardGameModels game2 = new Models.BoardGameModels()
            {
                Title = "Sabotażysta",
                Designer = "Frederic Moyersen",
                Publisher = "G3",
                NumberOfPlayers = " 3-10",
                RecommendedAge = 8,
                Description = "Sabotażysta to polska edycja światowego hitu Saboteur. Gracze wcielają " +
                "się w role krasnali poszukujących bryłek złota w kopalni. Praca wre, gdy " +
                "nagle kilof łamie się, a górnicza latarnia niespodziewanie gaśnie. Sabotażysta " +
                "znowu uderzył! Kim jest tajemniczy przeciwnik? Czy działa sam czy w grupie? Czy " +
                "zdoła powstrzymać kopaczy przed wydobyciem złota? Jeżeli kopacze zdołają przebić " +
                "tunel do skarbu, otrzymają nagrodę w postaci bryłek złota, podczas gdy sabotażyści " +
                "odejdą z pustymi rękoma. Jednak jeśli kopacze poniosą porażkę, nagrodę zagarniają " +
                "sabotażyści. Sabotażysta to gra towarzyska, w której wymagana jest spryt, strategia i " +
                "umiejętność przewidywania ruchów przeciwnika"
            };
            context.BoardGame.Add(game2);
            UserModels user1 = new Models.UserModels()
            {
                Name = "Jan",
                Surname = "Kowalski",
                Phone = 555111222,
                Email = "jan@email.com",
                Reviews = new List<ReviewModels>
                    {
                        new Models.ReviewModels() { Title = "Tajniacy to gra dla każdego", Contents = "Gra wykonana " +
                        "jest solidnie, choć raczej prosto. Karty z hasłami są bardzo neutralne, ale na szczęście " +
                        "dość czytelne. W trakcie naszych partii okazało się jednak, że dla niektórych, dojrzalszych " +
                        "współgraczy problem stanowiła wielkość karty z zakodowanym układem słów. Jest ona na tyle mała, " +
                        "że jej odszyfrowanie wymagało wzmożonego wysiłku.", BoardGame = game1, DateOfPublication = DateTime.Now }
                    }
            };
            context.User.Add(user1);
            UserModels user2 = new Models.UserModels()
            {
                Name = "Tomasz",
                Surname = "Wilk",
                Phone = 997998999,
                Email = "wolf@email.com",
            };
            context.User.Add(user2);
            ReviewModels review1 = new Models.ReviewModels()
            {
                Title = "Tajniacy na wieczór",
                Contents = "Przykładowa treść tajniacy maniacy, test",
                Author = user2,
                BoardGame = game1,
                DateOfPublication = DateTime.Now
            };
            context.Review.Add(review1);
            ReviewModels review2 = new Models.ReviewModels()
            {
                Title = "Tajniacy i spółka",
                Contents = "Inna przykładowa treść",
                Author = user2,
                BoardGame = game1,
                DateOfPublication = DateTime.Now
            };
            context.Review.Add(review2);
            ReviewModels review3 = new Models.ReviewModels()
            {
                Title = "Sabotaż czy nie?",
                Contents = "Bardzo fajna gra polecam z całego serduszka",
                Author = user2,
                BoardGame = game2,
                DateOfPublication = DateTime.Now
            };
            context.Review.Add(review3);
            UserModels user3 = new Models.UserModels()
            {
                Name = "Szymon",
                Surname = "Pawlak",
                Phone = 12121212,
                Email = "szpaw@email.com",
            };
            context.User.Add(user3);
            MessageModels msg1 = new Models.MessageModels()
            {
                Contents = "Hej, masz chwilę?",
                IsDeleted = false,
                SenderUser = user1,
                ReceiverUser = user2,
                PostDate = DateTime.Now
            };
            context.Message.Add(msg1);
            MessageModels msg2 = new Models.MessageModels()
            {
                Contents = "Daj mi tylko 5 minut",
                IsDeleted = false,
                SenderUser = user2,
                ReceiverUser = user1,
                PostDate = DateTime.Now
            };
            context.Message.Add(msg2);

            CommentModels com1 = new Models.CommentModels()
            {
                Contents = "Bardzo fajna recenzja",
                PostDate = DateTime.Now,
                Author = user3,
                Review = review1
            };
            context.Comment.Add(com1);

            FriendModels fr1 = new Models.FriendModels()
            {
                MyFollowers = user2,
                MyObservations = user1,
                StartDate = DateTime.Now
            };
            context.Friend.Add(fr1);

            FriendModels fr2 = new Models.FriendModels()
            {
                MyFollowers = user2,
                MyObservations = user3,
                StartDate = DateTime.Now
            };
            context.Friend.Add(fr2);

            AdvertisementModels ad1 = new Models.AdvertisementModels()
            {
                Date = DateTime.Now,
                City = "Łódź",
                Description = "Nocne granie w moim domu",
                MaxPlayer = 6,
                IsActive = true,
                Author = user1,
                BoardGame = game1
            };
            context.Advertisement.Add(ad1);

            PlayerModels pl1 = new Models.PlayerModels()
            {
                Advertisement = ad1,
                Player = user2
            };
            context.Player.Add(pl1);

            PlayerModels pl2 = new Models.PlayerModels()
            {
                Advertisement = ad1,
                Player = user3
            };
            context.Player.Add(pl2);


            context.SaveChanges();
        }
    }
}