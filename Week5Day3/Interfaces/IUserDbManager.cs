using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5Day3.Entities;

namespace Week5Day3.Interfaces
{
    interface IUserDbManager
    {
        public List<User> Fetch();
        public User GetById(int? id);
        public void Insert(User user);
        public void Delete(User user);
        public void Update(User user);
    }
}
