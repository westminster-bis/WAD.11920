using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using WAD_WEBAPPLICATION_11920.Models;

namespace WAD_WEBAPPLICATION_11920.DATA_ACCESS
{
    public class UserRepository : IUserRepository
    {
        private string connectionString
        {
            get
            {
                return WebConfigurationManager.ConnectionStrings["BookAppConnectionString"].ConnectionString;
            }
        }

        public IList<User> GetUsers()
        {

            IList<User> users = new List<User>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT [id]
                                              ,[first_name]
                                              ,[last_name]
                                              ,[phoner]
                                              ,[email]
                                              
                                          FROM [dbo].[users]";

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new User();
                            user.Id = reader.GetInt32(reader.GetOrdinal("id"));
                            user.FirstName = reader.GetString(reader.GetOrdinal("first_name"));
                            user.LastName = reader.GetString(reader.GetOrdinal("last_name"));
                            user.Phone = reader.GetString(reader.GetOrdinal("phoner"));
                            user.Email = reader.GetString(reader.GetOrdinal("email"));

                           

                            users.Add(user);
                        }
                    }
                }

            }

            return users;
        }

        public IList<Book> GetUserOwnedBooks()
        {
            IList<Book> books = new List<Book>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT *
                                              
                                          FROM [dbo].[books] book 
                                            INNER JOIN users ON book.borrower = user.id
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
                            book.Borrower = reader.GetInt32(reader.GetOrdinal("author"));
                            book.IssuedYear = reader.GetDateTime(reader.GetOrdinal("issued_year"));



                            books.Add(book);
                        }
                    }
                }
                

            }
            return books;
        }

        public void CreateUser(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO [dbo].[users]
                                                       ([first_name]
                                                       ,[last_name]
                                                       ,[phoner]
                                                       ,[email]
                                                        )
                                                     
                                                 VALUES
                                                       (
		                                               @first_name
                                                       ,@last_name
                                                       ,@phoner
		                                               ,@email)";
                    command.Parameters.AddWithValue("@first_name", user.FirstName);
                    command.Parameters.AddWithValue("@last_name", user.LastName);
                    command.Parameters.AddWithValue("@phoner", user.Phone);
                    command.Parameters.AddWithValue("@email", user.Email);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public User GetById(int id)
        {
            User user = null;
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT [id]
                                          ,[first_name]
                                          ,[last_name]
                                          ,[phoner]
                                          ,[email]
                                      FROM [dbo].[users]
                                        WHERE id = @id
                                    ";
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User()
                            {
                                Id = id,
                                FirstName = reader.GetString(reader.GetOrdinal("first_name")),
                                LastName = reader.GetString(reader.GetOrdinal("last_name")),
                                Email = reader.GetString(reader.GetOrdinal("email")),
                                Phone = reader.GetString(reader.GetOrdinal("phoner")),
                            };
                        }
                    }

                }
            }

            return user;
        }

        public void UpdateUser(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"UPDATE [dbo].[users]
                                           SET [first_name] = @first_name
                                              ,[last_name] = @last_name
                                              ,[phoner] = @phone
                                              ,[email] = @email
                                              
                                         WHERE id = @id";
                    command.Parameters.AddWithValue("@first_name", user.FirstName);
                    command.Parameters.AddWithValue("@last_name", user.LastName);
                    command.Parameters.AddWithValue("@phone", user.Phone);
                    command.Parameters.AddWithValue("@email", user.Email);
                    command.Parameters.AddWithValue("@id", user.Id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUser(User client)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM [dbo].[users]
                                                      WHERE id = @id";
                    command.Parameters.AddWithValue("@id", client.Id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}