using System;
using System.Data.SqlClient;
using System.Drawing;

namespace Ado_Dot_Net_HW
{
    public class SqlOperationsAdoDotNet
    {
        public const string TaskSeparator = "-----------------";
        public static void Main()
        {
            var connectionStringNorthwind = "Server=.\\SQLEXPRESS;Database=Northwind;Integrated Security=true";
            var connection = new SqlConnection(connectionStringNorthwind);

            connection.Open();

            using (connection)
            {
                // Task 01
                PrintRowsCountInCategories(connection);
                Console.WriteLine(TaskSeparator);

                // Task 02
                PrintCategoriesNamesAndDescriptions(connection);
                Console.WriteLine(TaskSeparator);

                // Task 03
                PrintProductsByCategories(connection);
                Console.WriteLine(TaskSeparator);

                // Task 04
                AddNewProduct("My Product", true, connection);
                Console.WriteLine(TaskSeparator);

                // Task 05
                SaveCategoriesPics(connection);
                Console.WriteLine(TaskSeparator);

                // Task 08
                FindProductByText(connection);
                Console.WriteLine(TaskSeparator);
            }
        }

        public static void FindProductByText(SqlConnection connection)
        {
            var containsCommand = new SqlCommand(@"SELECT ProductName 
                                                     FROM Products 
                                                     WHERE CHARINDEX(@SeachPattern, ProductName) > 0", connection);

            Console.WriteLine("Enter searching text:");
            var searchPattern = Console.ReadLine();
            containsCommand.Parameters.AddWithValue("@SeachPattern", searchPattern);

            using (var reader = containsCommand.ExecuteReader())
            {
                Console.WriteLine($"Products contains: '{searchPattern}'");
                int count = 0;
                while (reader.Read())
                {
                    Console.WriteLine(reader["ProductName"]);
                    count++;
                }

                if (count == 0)
                {
                    Console.WriteLine("No products matches");
                }
            }
        }

        public static void SaveCategoriesPics(SqlConnection connection)
        {
            var categoriesPicsCommand = new SqlCommand(@"SELECT Picture FROM Categories", connection);

            using (var reader = categoriesPicsCommand.ExecuteReader())
            {
                int count = 1;
                while (reader.Read())
                {
                    byte[] bitmap = (byte[])reader["Picture"];

                    Image image = (Bitmap)((new ImageConverter()).ConvertFrom(bitmap));
                    image.Save($"..\\..\\Pictures\\{count}.jpg");
                    count++;
                }
            }

            Console.WriteLine("Pictures saved successfully!");
        }

        public static void AddNewProduct(string productName, bool discontinued, SqlConnection connection)
        {
            var addNewPRoductCommand = new SqlCommand(@"INSERT INTO Products (ProductName, Discontinued) 
                                                           VALUES(@productName, @discontinued)", connection);

            addNewPRoductCommand.Parameters.Add(new SqlParameter("@productName", productName));
            addNewPRoductCommand.Parameters.Add(new SqlParameter("@discontinued", discontinued));

            var rowsAffected = addNewPRoductCommand.ExecuteNonQuery();

            Console.WriteLine($"Rows affected: {rowsAffected}");
        }

        public static void PrintProductsByCategories(SqlConnection connection)
        {
            var productsByCategoriesCommand = new SqlCommand(@"SELECT p.ProductName, c.CategoryName 
                                                                   FROM Products as p 
                                                                   JOIN Categories as c 
                                                                   ON p.CategoryID = c.CategoryID
                                                                   GROUP BY c.CategoryName, p.ProductName", connection);

            using (var reader = productsByCategoriesCommand.ExecuteReader())
            {
                string currCategory = string.Empty;

                while (reader.Read())
                {
                    string readerCategoryName = (string)reader["CategoryName"];

                    if (currCategory != readerCategoryName)
                    {
                        currCategory = readerCategoryName;

                        Console.WriteLine();
                        Console.WriteLine($"    {currCategory}");
                    }
                    Console.WriteLine(reader["ProductName"]);
                }
            }
        }

        public static void PrintCategoriesNamesAndDescriptions(SqlConnection connection)
        {
            var categoriesCommand = new SqlCommand("SELECT CategoryName, Description FROM Categories", connection);

            using (var reader = categoriesCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("Categories");
                    Console.WriteLine($"Name: {reader["Categoryname"]}");
                    Console.WriteLine($"Description: {reader["Description"]}");
                    Console.WriteLine("--");
                }
            }
        }

        public static void PrintRowsCountInCategories(SqlConnection connection)
        {
            var rowsCountInCategoriesCommand = new SqlCommand("SELECT COUNT(*) FROM Categories", connection);
            var rowsCountCategoies = (int)rowsCountInCategoriesCommand.ExecuteScalar();
            Console.WriteLine(rowsCountCategoies);
        }
    }
}
