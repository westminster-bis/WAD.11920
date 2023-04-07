using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using WAD_WEBAPPLICATION_11920.Models;

namespace WAD_WEBAPPLICATION_11920.DATA_ACCESS
{
    public class BookRepository : IBook
    {
        private string connectionString
        {
            get
            {
                return WebConfigurationManager.ConnectionStrings["BookAppConnectionString"].ConnectionString;
            }
        }

        public IList<Book> GetBooks ()
        {

            IList<Book> books = new List<Book>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT book.[id]
                                              ,book.[title]
                                              ,book.[isbn]
                                              ,book.[author]
                                              ,book.[issued_year]
                                              ,book.[borrower]
                                              ,[dbo].[users].first_name
                                              ,[dbo].[users].last_name
                                          FROM [dbo].[books] book
                                          INNER JOIN [dbo].[users] ON book.borrower = [dbo].[users].id
                                            ";

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var book = new Book();
                            book.Id = reader.GetInt32(reader.GetOrdinal("id"));
                            book.BookTitle = reader.GetString(reader.GetOrdinal("title"));
                            book.ISBN = reader.GetString(reader.GetOrdinal("isbn"));
                            book.Author = reader.GetString(reader.GetOrdinal("author"));
                            book.IssuedYear = reader.GetDateTime(reader.GetOrdinal("issued_year"));
                            book.Borrower = reader.GetInt32(reader.GetOrdinal("borrower"));
                            book.BorrowerName = reader.GetString(reader.GetOrdinal("first_name")) + " " + reader.GetString(reader.GetOrdinal("last_name"));

                         

                            books.Add(book);
                        }
                    }
                }

            }

            return books;
        }

        public Book GetById(int id)
        {
            Book book = null;
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT book.[id]
                                          ,book.[title]
                                          ,book.[isbn]
                                          ,book.[author]
                                          ,book.[issued_year]
                                          ,book.[borrower]
                                          ,[dbo].[users].[first_name]
                                          ,[dbo].[users].[last_name]
                                      FROM [dbo].[books] book
                                      INNER JOIN [dbo].[users] ON book.borrower = [dbo].[users].id 
                                        WHERE book.id = @id
                                    ";
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            book = new Book()
                            {
                                Id = id,
                                BookTitle = reader.GetString(reader.GetOrdinal("title")),
                                ISBN = reader.GetString(reader.GetOrdinal("isbn")),
                                Author = reader.GetString(reader.GetOrdinal("author")),
                                Borrower = reader.GetInt32(reader.GetOrdinal("borrower")),
                                IssuedYear = reader.GetDateTime(reader.GetOrdinal("issued_year")),
                                BorrowerName = reader.GetString(reader.GetOrdinal("first_name")) + " " + reader.GetString(reader.GetOrdinal("last_name"))

                        };
                        }
                    }

                }
            }

            return book;
        }

        public void Update(Book book)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"UPDATE [dbo].[books]
                                           SET [title] = @title
                                              ,[isbn] = @isbn
                                              ,[author] = @author
                                              ,[issued_year] = @issued_year
                                              ,[borrower] = @borrower
                                              
                                         WHERE id = @id";
                    command.Parameters.AddWithValue("@title", book.BookTitle);
                    command.Parameters.AddWithValue("@isbn", book.ISBN);
                    command.Parameters.AddWithValue("@author", book.Author);
                    command.Parameters.AddWithValue("@issued_year", book.IssuedYear);
                    command.Parameters.AddWithValue("@borrower", book.Borrower);
                    command.Parameters.AddWithValue("@id", book.Id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }

        public void Create(Book book)
        {
            
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = @"INSERT INTO [dbo].[books]
                                                       ([title]
                                                       ,[isbn]
                                                       ,[author]
                                                       ,[issued_year]
                                                       ,[borrower]
                                                        )
                                                     
                                                 VALUES
                                                       (
		                                               @title
                                                       ,@isbn
                                                       ,@author
		                                               ,@issued_year
		                                               ,@borrower
                                                    )";
                        command.Parameters.AddWithValue("@title", book.BookTitle);
                        command.Parameters.AddWithValue("@isbn", book.ISBN);
                        command.Parameters.AddWithValue("@author", book.Author);
                        command.Parameters.AddWithValue("@issued_year", book.IssuedYear);
                        command.Parameters.AddWithValue("@borrower", book.Borrower);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            
        }

        public void Delete(Book book)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM [dbo].[books]
                                                      WHERE id = @id";
                    command.Parameters.AddWithValue("@id", book.Id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}