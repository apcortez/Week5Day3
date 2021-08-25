using System;
using System.Collections.Generic;
using System.Linq;
using Week5Day3.Entities;
using Week5Day3.Repository;

namespace Week5Day3
{
    internal class GolfManager
    {
        //public static UserListRepository userRepository = new UserListRepository();
        public static UserSqlRepository userRepository = new UserSqlRepository();

        internal static void showUsers()
        {
            List<User> users = userRepository.Fetch();
            foreach(var user in users)
            {
                Console.WriteLine(user.Print());
            }

            Console.WriteLine();
        }

        internal static void EditUser()
        {
            User user = ScegliUser();
            User userUpdated = ChiediDatiUser();
            userUpdated.Id = user.Id;
            userRepository.Update(userUpdated);
        }

        internal static void DeleteUser()
        {
            User user = ScegliUser();
            userRepository.Delete(user);
        }

        private static User ScegliUser()
        {
            List<User> users = userRepository.Fetch();
            int i = 1;
            foreach(var user in users)
            {
                Console.WriteLine($"Premi {i} per selezionare {user.Print()}");
                i++;
            }

            bool isInt;
            int utenteScelto;
            do
            {
                Console.WriteLine("Quale utente vuoi selezionare?");

                isInt = int.TryParse(Console.ReadLine(), out utenteScelto);

            } while (!isInt || utenteScelto <= 0 || utenteScelto > users.Count);

            return users.ElementAt(utenteScelto - 1);
        }

        internal static void InsertUser()
        {
            User user = ChiediDatiUser();
            userRepository.Insert(user);
        }

        private static User ChiediDatiUser()
        {
            User user = new User();
            string firstName, lastName; DateTime birthday;
            int gender;
            bool isInt, subscribed;
            do
            {
                Console.WriteLine("Inserisci il nome dell'iscritto: ");
                firstName = Console.ReadLine();
            } while (firstName.Length <2);

            do
            {
                Console.WriteLine("Inserisci il cognome dell'iscritto: ");
                lastName = Console.ReadLine();
            } while (lastName.Length < 2);

            Console.WriteLine("Inserisci la data di nascita dell'iscritto: ");
            birthday = DateTime.Parse(Console.ReadLine());

            do
            {
                Console.WriteLine("Scegli un genere");
                foreach (var genere in Enum.GetValues(typeof(GenderEnum)))
                {
                    Console.WriteLine($"Premi {(int)genere + 1} per {(GenderEnum)genere}");
                }
                isInt = int.TryParse(Console.ReadLine(), out gender);

            } while (gender < 0 || gender> 2);

            Console.WriteLine("L'utente è iscritto? true/false ");
            subscribed= bool.Parse(Console.ReadLine());

            user = new User(firstName, lastName, birthday, (GenderEnum)gender, subscribed, null);

            return user;
        }
    

        internal static void GetUser()
        {
            Console.WriteLine("Inserisci l'id del user:");
            int id = int.Parse(Console.ReadLine());
            User user = userRepository.GetById(id);
            Console.WriteLine(user.Print());
        }

        internal static void FilterByCardHolder()
        {

            List<User> users = userRepository.Fetch();
            foreach (var user in users)
            {
                if (user.Subscribed)
                {
                    Console.WriteLine(user.Print());
                }
            }
        }
    }
}