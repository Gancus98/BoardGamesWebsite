using BoardGame.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BoardGame.DAL
{
    public class OnTheBoardDBInitializer<T>: CreateDatabaseIfNotExists<OnTheBoardContext>
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
                GameTime = 30,
                Photo = "https://3.bp.blogspot.com/-PIhaQ_huZHw/WFpYY-iZVeI/AAAAAAAAC9I/W0w24xro2zwsjK-4bw4b-AUT5kG5B5YdQCLcB/s1600/www.kostkizostalyrzucone.pl_o_grach_planszowych_tajniacy_recenzja_1.jpg",
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
                GameTime = 20,
                Photo= "https://files.rebel.pl/products/100/1203/_9004/sabotazysta-1200x900-ffffff.JPG",
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

            BoardGameModels game3 = new Models.BoardGameModels()
            {
                Title = "Party Time",
                Designer = "No info",
                Publisher = "Tactic Games",
                NumberOfPlayers = "4-12",
                RecommendedAge = 15,
                GameTime = 60,
                Photo = "https://image.ceneostatic.pl/data/products/37379894/i-party-time.jpg",
                Description = "NAJPRAWDOPODOBNIEJ TO NAJLEPSZA GRA " +
                "IMPREZOWA.Objaśniaj hasła inaczej mówiąc ale " +
                "zmieniaj sposób tłumaczenia za każdym razem, " +
                "gdy pionek odwiedzi pole specjalne.W tej wersji " +
                "bestsellerowej gry żadne słowo nigdy nie zabrzmi tak " +
                "samo. Baw się dobrze w doborowym towarzystwie. " +
                "Zawartość jest bardziej kolorowa, " +
                "niż w jakiejkolwiek innej grze Alias! " +
                "Zadania są bardzo różnorodne. " +
                "Idealny dla dorosłych i młodzieży."
            };
            context.BoardGame.Add(game3);

            BoardGameModels game4 = new Models.BoardGameModels()
            {
                Title = "Potwory w Tokio",
                Designer = "Richard Garfield",
                Publisher = "Egmont",
                NumberOfPlayers = " 2-6",
                RecommendedAge = 8,
                GameTime = 30,
                Photo = "https://info.znadplanszy.pl/wp-content/uploads/sites/42/2016/06/potworywtokio-okladka-1030x1030.jpg",
                Description = "Potwory w Tokio to gra dla od 2 do 6 graczy, w której wcielają się oni w zmutowane monstra, gigantyczne roboty i potężnych obcych, którzy z radościa okładają się wzajemnie w sielskiej atmosferze walcząc o tytuł króla Tokio, nie zważając przy tym na zniszczenia i spustoszenie, które sieją w samym mieście. " +
                "W trakcie swojej tury rzucasz sześcioma kośćmi wybierając symbole, których będziesz chciał użyć w nadchodzącej turze.Dzięki nim będziesz mógł atakować inne monstra, regenerować energię, " +
                "leczyć się i kupować karty specjalne.Dzięki nim posiądziesz specjalne zdolności jak regeneracja, naturalny pancerz, mimikrę, plucie kwasem, czy zianie ogniem! Używaj ich rozsądnie, aby udowodnić, że Tokio to tylko Twoje terytorium."
            };
            context.BoardGame.Add(game4);

            UserModels user1 = new Models.UserModels()
            {
                Name = "Dominika",
                Surname = "Kruk",
                Photo = "https://cdn.pixabay.com/photo/2016/03/09/12/10/woman-1246299_960_720.jpg",
                Phone = 555111222,
                Email = "jan@email.com",
                Reviews = new List<ReviewModels>
                    {
                        new Models.ReviewModels() { Title = "Tajniacy to gra dla każdego", Contents = "Gra wykonana " +
                        "jest solidnie, choć raczej prosto. Karty z hasłami są bardzo neutralne, ale na szczęście " +
                        "dość czytelne. W trakcie naszych partii okazało się jednak, że dla niektórych, dojrzalszych " +
                        "współgraczy problem stanowiła wielkość karty z zakodowanym układem słów. Jest ona na tyle mała, " +
                        "że jej odszyfrowanie wymagało wzmożonego wysiłku.", BoardGame = game1, DateOfPublication = DateTime.Now, Photo = "https://www.uraburagames.pl/wp-content/uploads/2019/06/tajniacy4.jpg" }
                    }
            };
            context.User.Add(user1);
            UserModels user2 = new Models.UserModels()
            {
                Name = "Tomasz",
                Surname = "Wilk",
                Photo = "https://cdn.pixabay.com/photo/2016/03/29/03/14/portrait-1287421_960_720.jpg",
                Phone = 997998999,
                Email = "wolf@email.com",
            };
            context.User.Add(user2);
            ReviewModels review1 = new Models.ReviewModels()
            {
                Title = "Tajniacy na wieczór",
                Contents = "Gra jest wykonana dobrze. Ze względu na charakter zabawy kart nie trzyma się w rękach, więc i koszulki wydają mi się w tym przypadku zbędne. Fajnym, choć przez nas raczej sporadycznie wykorzystywanym, dodatkiem jest klepsydra. Sama jej obecność na stole może powodować, że lubiący długie myślenie współgracze zaczną bardziej się mobilizować.",
                Author = user2,
                BoardGame = game1,
                DateOfPublication = DateTime.Now,
                Photo = "https://planszowkiwedwoje.pl/wp-content/uploads/2016/10/IMG_5188.jpg"
            };
            context.Review.Add(review1);
            ReviewModels review2 = new Models.ReviewModels()
            {
                Title = "Tajniacy i spółka",
                Contents = "Tajniacy mają temat dodany zupełnie od czapy i również traktuję ich bardziej jako grę rodzinną niż imprezową, choć według mnie sprawdzają się raczej w gronie rodziców czy dziadków, a nie koniecznie młodszych dzieci. Żeby zasługiwać na miano świetnej imprezówki gra musiałaby budzić większe emocje i zapewniać więcej śmiechu. Jest natomiast fajną, pobudzającą kreatywność pozycją, przy której miło spędzam czas.",
                Author = user2,
                BoardGame = game1,
                DateOfPublication = DateTime.Now,
                Photo = "https://planszowkiwedwoje.pl/wp-content/uploads/2016/10/IMG_5194.jpg"
            };
            context.Review.Add(review2);
            ReviewModels review3 = new Models.ReviewModels()
            {
                Title = "Sabotaż czy nie?",
                Contents = "Dzisiaj, dla odmiany, chcielibyśmy zaprezentować Wam grę karcianą. Małe pudełeczko skrywa prawdziwą perełkę-stały element naszych spotkań i imprez. Sabotażysta, bo o nim mowa, to gra od 3 do 10 osób. Gracze wcielają się w role krasnali kopiących tunele, które zaprowadzą ich do ukrytego w podziemiach góry złota. W zespole krasnali znajduje się jednak grupa tytułowych sabotażystów, którzy w różny sposób będą starali się pokrzyżować szyki poczciwym kopaczom. Nagrodą będą sztabki szlachetnego kruszcu, stawka jest, więc wysoka! Obie grupy muszą się wzajemnie wyczuć i wspierać. Tak-tylko kto jest kim? W tym właśnie tkwi urok Sabotażysty, jest to bowiem gra blefu. Podczas rozgrywki niejeden raz padnie pytanie „Czy jesteś sabotażystą?”.",
                Author = user2,
                BoardGame = game2,
                DateOfPublication = DateTime.Now,
                Photo = "https://1.bp.blogspot.com/-g_-c8vtxbaM/X4Rt2Qf87aI/AAAAAAAAQzM/01NywlRcaoc4UqrZ-JujHNShSp8oUxwlgCPcBGAYYCw/s2048/sabotazysta_1.JPG"
            };
            context.Review.Add(review3);
            UserModels user3 = new Models.UserModels()
            {
                Name = "Szymon",
                Surname = "Pawlak",
                Photo = "https://cdn.pixabay.com/photo/2016/03/26/20/35/young-man-1281282_960_720.jpg",
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