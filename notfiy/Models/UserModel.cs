using notfiy.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using notfiy.Core;
using Microsoft.VisualBasic.ApplicationServices;

namespace notfiy.Models
{
    internal class UserModel : Model
    {

        public List<User> GetAllUsers()
        {
            var users = new List<User>();


            Connection.Open();
            var command = new NpgsqlCommand("SELECT * FROM users", Connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    User user = new User();
                    user.IdUser = (int)reader["id_users"];
                    user.Username = (string)reader["username"];
                    user.Password = (string)reader["password"];
                    user.TimeCreated = (string)reader["users_time_created"];
                    users.Add(user);
                }
            }
            return users;
        }

        public User GetUserById(int idUser)
        {
            User user = null;

            Connection.Open();
            var command = new NpgsqlCommand("SELECT * FROM users WHERE id_users = @id", Connection);
            command.Parameters.AddWithValue("@id",idUser);

            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    user = new User 
                    {
                        user.IdUser = (int)reader["id_users"];
                        user.Username = (string)reader["username"];
                        user.Password = (string)reader["password"];
                        user.TimeCreated = (string)reader["users_time_created"];
                        users.Add(user);
                    }
                }
            }
            return user;
        }

    }
}
