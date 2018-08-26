using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using musicP.resources.classes;

namespace musicP.resources.database
{
    public class UserDAOImpl : IUserDAO
    {

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM [user]";

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int userID = dr.GetInt32(0);
                        string username = dr.GetString(1);
                        string password = dr.GetString(2);

                        User user = new User(userID, username, password);
                        users.Add(user);
                    }
                }
            }

            return users;
        }

        public User GetUserByUsername(string username)
        {
            User user = null;

            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT userID, password FROM [user] WHERE username = @username";
                cmd.Parameters.AddWithValue("@username", username);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        int userID = dr.GetInt32(0);
                        string password = dr.GetString(1);

                        user = new User(userID, username, password);
                    }
                }
            }

            return user;
        }

        public int GetUsernameCountByUsername(string username)
        {
            int usernameCount = 0;

            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(*) AS usernameCount FROM [user] WHERE username = @username";
                cmd.Parameters.AddWithValue("@username", username);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        usernameCount = dr.GetInt32(0);
                    }
                }
            }

            return usernameCount;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            User user = null;

            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM [user] WHERE username = @username AND password = @password";
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        int userID = dr.GetInt32(0);

                        user = new User(userID, username, password);
                    }
                }
            }

            return user;
        }

        public User GetUserByID(int userID)
        {
            User user = null;

            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT username FROM [user] WHERE userID = @userID;";
                cmd.Parameters.AddWithValue("@userID", userID);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        string username  = dr.GetString(0);
                        user = new User(userID, username);

                    }
                }
            }

            return user;
        }

        public void InsertUser(User user)
        {
            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO [user] (username, password) VALUES(@username, @password);";
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@password", user.password);
                cmd.ExecuteReader();
            }
        }

        public void UpdateUser(User user)
        {
            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "UPDATE [user] SET username = @username, password = @password WHERE userID = @userID;";
                cmd.Parameters.AddWithValue("@userID", user.userID);
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@password", user.password);
                cmd.ExecuteReader();
            }
        }

        public void DeleteUserByID(int userID)
        {
            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM [user] WHERE userID = @userID;";
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.ExecuteReader();
            }
        }

    }
}