namespace _09.MySQL_Books
{
    using _09.MySQL_Books.Models;
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;
    using System.Security;

    internal class MySQL_Books
    {
        private static MySqlConnection dbConnection;

        public static string getPassword()
        {
            string pass = "";
            Console.Write("Enter your password: ");
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return pass;
        }

        private static void ConnectToDB()
        {
            string pass = getPassword();
            Console.WriteLine(pass);
            string connectionStr = "Server=localhost;Database=sakila;Uid=root;Pwd=" + pass + ";";
            //string connectionStr = "Server=localhost;Uid=root;Pwd=" + pass + ";";
            dbConnection = new MySqlConnection(connectionStr);
            dbConnection.Open();
        }

        private static void DisconnectFromDB()
        {
            if (dbConnection != null)
            {
                dbConnection.Close();
            }
        }

        private static bool CreateBooksTable()
        {
            using (dbConnection)
            {
                MySqlCommand cmd = new MySqlCommand("CREATE TABLE Books ("
                 + " BookID int IDENTITY,"
                 + " BookName nvarchar(100) NOT NULL,"
                 + " AuthorName nvarchar(100) NOT NULL,"
                 + " PublishedDate datetime,"
                 + " ISBN int  NOT NULL,"
                 + " CONSTRAINT PK_Books PRIMARY KEY(BookID),"
                 + " CONSTRAINT uq_ISBN UNIQUE (ISBN)"
                  );
                if (cmd.ExecuteNonQuery() == 0)
                {
                    return false;
                }
                return true;
            }
        }

        private static bool CreateBooksDB()
        {
            using (dbConnection)
            {
                MySqlCommand cmd = new MySqlCommand("CREATE DATABASE BooksDB");
                if (cmd.ExecuteNonQuery() == 0)
                {
                    return false;
                }
                return true;
            }
        }

        private static int AddBooks(IEnumerable<Book> books)
        {
            int booksAdded = 0;
            foreach (var book in books)
            {
                using (dbConnection)
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO [Books]([BookName], [AuthorName], [PublishedDate], [ISBN])"
                    + " VALUES (@bookName, @authorName, @publishedDate, @isbn)", dbConnection);
                    cmd.Parameters.AddWithValue("@bookName", book.BookName);
                    cmd.Parameters.AddWithValue("@authorName", book.AuthorName);
                    cmd.Parameters.AddWithValue("@publishedDate", book.PublishedDate);
                    cmd.Parameters.AddWithValue("@isbn", book.ISBN);
                    booksAdded += cmd.ExecuteNonQuery();
                }

            }
            return booksAdded;
        }

        private static void Main(string[] args)
        {
            List<Book> books = new List<Book>(){ 
                new Book("The Holy Bible", "Unknown", DateTime.Parse("1/1/1"), 1),
                new Book("The Coran", "Mohammad", DateTime.Parse("1/1/300"), 100),
                new Book("Kama Sutra", "Indian Night Tales", DateTime.Parse("1/1/1000"), 69),
                new Book("1001 Nights", "Scheherazade", DateTime.Parse("1/1/1100"), 1001)
            };

            try
            {
                ConnectToDB();
                //var dbCreated = CreateBooksDB();
                var booksAdded = AddBooks(books);
                //Console.WriteLine(dbCreated ? "Database successfully created" : "Database was not created!");
                Console.WriteLine("{0} books added", booksAdded);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured: {0}", ex);
            }
            finally
            {
                DisconnectFromDB();
            }
        }
    }
}