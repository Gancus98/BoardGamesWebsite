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

            BoardGameModels game5 = new Models.BoardGameModels()
            {
                Title = "DECRYPTO",
                Designer = "Thomas Dagenais - Lespérance",
                Publisher = "2 Pionki",
                NumberOfPlayers = " 4",
                RecommendedAge = 8,
                GameTime = 45,
                Photo = "https://files.rebel.pl/products/100/1203/_107274/gra-planszowa-2pionki-Decrypto-front.png",
                Description = "Stańcie w szranki z przeciwną drużyną łamaczy kodów. Każda z dwóch drużyn otrzymuje zestaw znanych tylko im haseł. Jedna, wybrana osoba z drużyny staje się szyfrantem - zna on kod i stara się przekazać swojej drużynie podpowiedzi słowne w taki sposób, aby jego sojusznicy dopasowali hasła do słów w odpowiedniej kolejności wskazanej przez kod. W tym samym czasie przeciwnicy również próbują go rozszyfrować, ale nie znają haseł oponentów, więc do dyspozycji mają tylko słowne podpowiedzi."
            };
            context.BoardGame.Add(game5);



            context.SaveChanges();
        }
    }
}