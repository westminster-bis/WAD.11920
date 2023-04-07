using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD_WEBAPPLICATION_11920.Models;

namespace WAD_WEBAPPLICATION_11920.DATA_ACCESS
{
    interface IBook
    {
        IList<Book> GetBooks();

        Book GetById(int id);

        void Create(Book book);

        void Update(Book book);

        void Delete(Book book);

    }
}
