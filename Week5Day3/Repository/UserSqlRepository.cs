
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5Day3.Entities;
using Week5Day3.Interfaces;


namespace Week5Day3
{
    class UserSqlRepository : IUserDbManager
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb; " +
                                              "Initial Catalog = Golf; " +
                                              "Integrated Security = true;";
        public void Delete(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from [User] where Id = @id";
                command.Parameters.AddWithValue("@id", user.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<User> Fetch()
        {
            List<User> users = new List<User>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from [User]";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var firstname = (string)reader["FirstName"];
                    var lastname = (string)reader["LastName"];
                    var birthday = (DateTime)reader["Birthday"];
                    var gender = (GenderEnum)reader["Gender"];
                    var subscribed = (bool)reader["Subscribed"];
                    var id = (int)reader["Id"];

                    User user = new User(firstname, lastname, birthday, gender, subscribed, id);
                    users.Add(user);
                }
            }
            return users;
        }

        public User GetById(int? id)
        {
            User user = new User();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from [User] where Id = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var firstname = (string)reader["FirstName"];
                    var lastname = (string)reader["LastName"];
                    var birthday = (DateTime)reader["Birthday"];
                    var gender = (GenderEnum)reader["Gender"];
                    var subscribed = (bool)reader["Subscribed"];

                    user = new User(firstname, lastname, birthday, gender, subscribed, id);
                }
            }
            return user;
        }

        public void Insert(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

               
                command.CommandText = "insert into [User] values (@first, @last, @birth, @gender, @subscribed)";
                command.Parameters.AddWithValue("@first", user.FirstName);
                command.Parameters.AddWithValue("@last", user.LastName);
                command.Parameters.AddWithValue("@birth", user.Birthday);
                command.Parameters.AddWithValue("@gender", user.Gender);
                command.Parameters.AddWithValue("@subscribed", user.Subscribed);

                command.ExecuteNonQuery();
            }
        }

        public void Update(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update [User] " +
                                      "set FirstName = @first, LastName = @last, Birthday = @birth, Gender = @gender, Subscribed = @subscribed " +
                                      "where Id = @id";
                command.Parameters.AddWithValue("@first", user.FirstName);
                command.Parameters.AddWithValue("@last", user.LastName);
                command.Parameters.AddWithValue("@birth", user.Birthday);
                command.Parameters.AddWithValue("@gender", user.Gender);
                command.Parameters.AddWithValue("@subscribed", user.Subscribed);
                command.Parameters.AddWithValue("@id", user.Id);


                command.ExecuteNonQuery();
            }
        }
    }
}