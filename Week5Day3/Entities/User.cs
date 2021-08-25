using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5Day3.Entities
{
    class User
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public GenderEnum Gender { get; set; }

        public bool Subscribed { get; set; }
        public int? Id { get; set; }
        public virtual string Print()
        {
            return $"{FirstName}, {LastName}, {Birthday.Date}, {Gender}, Tesserato: {Subscribed}";
        }

        public User()
        {

        }

        public User(string FirstName, string LastName, DateTime Birthday, GenderEnum Gender, bool Subscribed,int? Id)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Birthday = Birthday;
            this.Gender = Gender;
            this.Subscribed = Subscribed;
        }

    
}

    enum GenderEnum
    {
        Male,
        Female
    }
}
