using musicP.resources.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicP.resources.database
{
    interface IUserDAO
    {
        List<User> GetAllUsers();
        User GetUserByUsername(string username);
        User GetUserByUsernameAndPassword(string username, string password);
        User GetUserByID(int userID);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUserByID(int userID);
    }
}
