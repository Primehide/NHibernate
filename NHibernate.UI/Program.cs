using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.BL;
using NHibernate.Domain;

namespace NHibernate.UI
{
    public class Program
    {
        /* seed data */
        private static readonly LoLAccount[] _accounts = new[]
        {
            new LoLAccount { SummonerName = "Account1", AantalOfIp = 20, AantalOfRp = 50, HuidigeRang = "DIAMOND V" },
            new LoLAccount { SummonerName = "Account2", AantalOfIp = 20, AantalOfRp = 50, HuidigeRang = "PLATINUM V" },
            new LoLAccount { SummonerName = "Account3", AantalOfIp = 20, AantalOfRp = 50, HuidigeRang = "GOLD III" },
        };
        /* end seed data */
        private static bool quit = false;
        private static IManager mgr = new Manager();
        static void Main(string[] args)
        {
            /* seed data in databank steken */
            foreach (var account in _accounts)
            {
                mgr.AddLoLAccount(account);
            }
            /* end seeding */
            while (!quit)
                ShowMenu();
        }

        private static void ShowMenu()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("====== NHibernate CRUD Demo =====");
            Console.WriteLine("=================================");
            Console.WriteLine("1) Maak account aan (CREATE)");
            Console.WriteLine("2) Toon details van een account (READ)");
            Console.WriteLine("3) Naam updaten (UPDATE)");
            Console.WriteLine("4) Account verwijderen (DELETE)");
            DetectMenuAction();
        }

        private static void DetectMenuAction()
        {
            bool inValidAction = false;
            do
            {
                Console.Write("keuze: ");
                string input = Console.ReadLine();
                int action;
                if (Int32.TryParse(input, out action))
                {
                    switch (action)
                    {
                        case 1:
                            ActionCreateAccount(); break;
                        case 2:
                            ActionShowAccount(); break;
                        case 3:
                            ActionUpdateName(); break;
                        case 4:
                            ActionRemoveAccount(); break;
                        case 0:
                            quit = true;
                            return;
                        default:
                            Console.WriteLine("Geen geldige keuze");
                            inValidAction = true;
                            break;
                    }
                }
            } while (inValidAction);
        }

        private static void ActionRemoveAccount()
        {
            Console.Write("Geef het id van het account dat je wil verwijderen: ");
            int input = Int32.Parse(Console.ReadLine());

            LoLAccount accountToDelete = mgr.ReadAccount(input);
            mgr.DeleteAccount(accountToDelete);
        }

        private static void ActionUpdateName()
        {
            Console.Write("Geef het id van het account dat je wil update: ");
            int input = Int32.Parse(Console.ReadLine());

            LoLAccount accountToUpdate = mgr.ReadAccount(input);
            Console.Write("Nieuwe naam:");
            string naam = Console.ReadLine();
            accountToUpdate.SummonerName = naam;
            mgr.ChangeName(accountToUpdate);
        }

        private static void ActionCreateAccount()
        {
            Console.WriteLine("Er zijn momenteel " + mgr.ReadAllAccounts().Count() + "in de databank");
            Console.Write("Account naam: ");
            string naam = Console.ReadLine();

            Console.Write("Aantal rp");
            int rp = Int32.Parse(Console.ReadLine());

            Console.Write("Aantal ip");
            int ip = Int32.Parse(Console.ReadLine());

            Console.Write("Huidige rang: ");
            string rang = Console.ReadLine();

            LoLAccount accountToAdd = new LoLAccount()
            {
                SummonerName = naam,
                AantalOfRp = rp,
                AantalOfIp = ip,
                HuidigeRang = rang
            };
            mgr.AddLoLAccount(accountToAdd);
            Console.WriteLine("Er zijn momenteel " + mgr.ReadAllAccounts().Count() + "in de databank");
        }

        private static void ActionShowAccount()
        {
            Console.WriteLine("Account lijst: ");
            foreach (var acc in mgr.ReadAllAccounts())
            {
                Console.WriteLine(acc.Id + ") " + acc.SummonerName);
            }
            Console.WriteLine("Geeft het id in: ");
            int input = Int32.Parse(Console.ReadLine());

            LoLAccount account = mgr.ReadAccount(input);
            Console.WriteLine(account.Id + ": " + account.SummonerName + " - " + account.AantalOfIp + " - " + account.HuidigeRang);
        }
    }
}
