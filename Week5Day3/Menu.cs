using System;

namespace Week5Day3
{
    internal class Menu
    {
        internal static void Start()
        {
            bool continuare = true;

            do
            {
                Console.WriteLine("Premi 1 per vedere tutti gli iscritti");
                Console.WriteLine("Premi 2 per modificare i dati di un iscritto");
                Console.WriteLine("Premi 3 per eliminare un iscritto");
                Console.WriteLine("Premi 4 per inserire un nuovo iscritto");
                Console.WriteLine("Premi 5 per avere informazioni di un iscritto");
                Console.WriteLine("Premi 6 per filtrare gli iscritti tesserati");
                Console.WriteLine("Premi 0 per uscire");
                Console.WriteLine();
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        GolfManager.showUsers();
                        break;
                    case "2":
                        GolfManager.EditUser();
                        break;
                    case "3":
                        GolfManager.DeleteUser();
                        break;
                    case "4":
                        GolfManager.InsertUser();
                        break;
                    case "5":
                        GolfManager.GetUser();
                        break;
                    case "6":
                        GolfManager.FilterByCardHolder();
                        break;
                    case "0":
                        Console.WriteLine("Arrivederci! ");
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("Scelta sbagliata riprova");
                        break;
                }
            } while (continuare);
        }
    }
}
