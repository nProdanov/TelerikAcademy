using System;
using System.Data.SQLite;

namespace SqLite_Operations
{
    public class SqLiteOperations
    {
        public const string TaskSeparator = "---------------";

        public static void Main(string[] args)
        {
            var sqLiteConnectionString = "Data Source=..\\..\\Books.db;Version=3;";

            using (var sqLiteConnection = new SQLiteConnection(sqLiteConnectionString))
            {
                sqLiteConnection.Open();

                PrintAllBooks(sqLiteConnection);
                Console.WriteLine(TaskSeparator);

                AddBook(sqLiteConnection, "Sweet Thursday", "9780143039471", "1954-01-01", 3);
                Console.WriteLine(TaskSeparator);

                FindBooksByTitle(sqLiteConnection);
                Console.WriteLine(TaskSeparator);
            }
        }

        public static void FindBooksByTitle(SQLiteConnection mySqlConnection)
        {
            var containsCommand = new SQLiteCommand(@"SELECT Title 
                                                     FROM Books 
                                                     WHERE ChARINDEX(@SeachPattern, Title) > 0", mySqlConnection);

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

        public static void AddBook(SQLiteConnection mySqlConnection, string title, string isbn, string publishedDate, int authorId)
        {
            var addBookCommand = new SQLiteCommand(@"INSERT INTO Books (Title, ISBN, PublishedDate, AuthorId) 
                                                      VALUES(@Title, @ISBN, @PublishedDate, @AuthorId)", mySqlConnection);
            addBookCommand.Parameters.AddWithValue("@Title", title);
            addBookCommand.Parameters.AddWithValue("@ISBN", isbn);
            addBookCommand.Parameters.AddWithValue("@PublishedDate", publishedDate);
            addBookCommand.Parameters.AddWithValue("@AuthorId", authorId);

            var rowsAffected = addBookCommand.ExecuteNonQuery();
            Console.WriteLine($"Rows affected: {rowsAffected}");
        }

        public static void PrintAllBooks(SQLiteConnection mySqlConnection)
        {
            var selectAllBooksCommand = new SQLiteCommand(@"SELECT Title, ISBN, PublishedDate, authors.Name 
                                                             FROM books 
                                                             JOIN authors 
                                                             ON books.AuthorId = authors.Id", mySqlConnection);

            using (var reader = selectAllBooksCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"Title: {reader["Title"]}");
                    Console.WriteLine($"ISBN: {reader["ISBN"]}");
                    Console.WriteLine($"Published Year: {reader["PublishedDate"]}");
                    Console.WriteLine($"Author: {reader["Name"]}");
                    Console.WriteLine("--");
                }
            }
        }
    }
}
