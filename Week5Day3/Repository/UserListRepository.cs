using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5Day3.Entities;
using Week5Day3.Interfaces;

namespace Week5Day3.Repository
{
    class UserListRepository : IUserDbManager
    {
        public static List<User> users = new List<User>
        {
            new User("Pippo", "Neri", new DateTime(1993,06,20), GenderEnum.Male, false, 1),
            new User("Pluto", "Rossi", new DateTime(1980,03,10), GenderEnum.Male, true, 2),
            new User("Paperino", "Verdi", new DateTime(2000,03,14), GenderEnum.Male, false, 3),
            new User("Minnie", "Rosa", new DateTime(1993, 07, 31), GenderEnum.Female, true, 4),

        };

        public void Delete(User user)
        {
            users.Remove(user);
        }

        public List<User> Fetch()
        {
            return users;
        }

        public User GetById(int? id)
        {
            return users.Find(u => u.Id == id);
        }

        public void Insert(User user)
        {
            users.Add(user);
        }

        public void Update(User user)
        {
            var userToDelete = GetById(user.Id);
            Delete(userToDelete);
            Insert(user);
        }

       
    }
}
