using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD_WEBAPPLICATION_11920.Models;

namespace WAD_WEBAPPLICATION_11920.DATA_ACCESS
{
    interface IUserRepository
    {
        IList<User> GetUsers();

        User GetById(int id);

        void CreateUser(User user);

        void UpdateUser(User user);

        void DeleteUser(User user);

        IList<Book> GetUserOwnedBooks();

    }
}
