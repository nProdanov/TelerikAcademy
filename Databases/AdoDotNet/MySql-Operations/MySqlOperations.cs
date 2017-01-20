using MySql.Data.MySqlClient;
using System;

namespace MySql_Operations
{
    public class MySqlOperations
    {
        public const string TaskSeparator = "---------------";

        public static void Main(string[] args)
        {
            var connectionString = @"Server=127.0.0.1;Database=Books;Uid=root;
                                    Pwd = 1234;";

            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                mySqlConnection.Open();

                
                PrintAllBooks(mySqlConnection);
                Console.WriteLine(TaskSeparator);

                AddBook(mySqlConnection, "Sweet Thursday", "9780143039471", "1954-01-01", 3);
                Console.WriteLine(TaskSeparator);

                FindBooksByTitle(mySqlConnection);
                Console.WriteLine(TaskSeparator);
            }
        }

        public static void FindBooksByTitle(MySqlConnection mySqlConnection)
        {
            var containsCommand = new MySqlCommand(@"SELECT Title 
                                                     FROM Books 
                                                     WHERE LOCATE(@SeachPattern, Title) > 0", mySqlConnection);

            Console.WriteLine("Enter searching text:");
            var searchPattern = Console.ReadLine();
            containsCommand.Parameters.AddWithValue("@SeachPattern", searchPattern);

            using (var reader = containsCommand.ExecuteReader())
            {
                Console.WriteLine($"Books Title contains: '{searchPattern}'");
                int count = 0;
                while (reader.Read())
                {
                    Console.WriteLine(reader["Title"]);
                    count++;
                }

                if (count == 0)
                {
                    Console.WriteLine("No books matches");
                }
            }
        }

        public static void AddBook(MySqlConnection mySqlConnection, string title, string isbn, string publishedDate, int authorId)
        {
            var addBookCommand = new MySqlCommand(@"INSERT INTO Books (Title, ISBN, PublishedDate, AuthorId) 
                                                      VALUES(@Title, @ISBN, @PublishedDate, @AuthorId)", mySqlConnection);
            addBookCommand.Parameters.AddWithValue("@Title", title);
            addBookCommand.Parameters.AddWithValue("@ISBN", isbn);
            addBookCommand.Parameters.AddWithValue("@PublishedDate", publishedDate);
            addBookCommand.Parameters.AddWithValue("@AuthorId", authorId);

            var rowsAffected = addBookCommand.ExecuteNonQuery();
            Console.WriteLine($"Rows affected: {rowsAffected}");
        }

        public static void PrintAllBooks(MySqlConnection mySqlConnection)
        {
            var selectAllBooksCommand = new MySqlCommand(@"SELECT Title, ISBN, PublishedDate, authors.Name 
                                                             FROM books 
                                                             JOIN authors 
                                                             ON books.AuthorId = authors.Id", mySqlConnection);

            using (var reader = selectAllBooksCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"Title: {reader["Title"]}");
                    Console.WriteLine($"ISBN: {reader["ISBN"]}");
                    Console.WriteLine($"Published Year: {((DateTime)reader["PublishedDate"]).Year}");
                    Console.WriteLine($"Author: {reader["Name"]}");
                    Console.WriteLine("--");
                }
            }
        }
    }
}
