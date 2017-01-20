using System;
using System.Data.OleDb;

namespace Excel_Operations
{
    public class ExcelOperations
    {
        public const string TaskSeparator = "---------------";
        public static void Main(string[] args)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\file.xlsx;Extended Properties=Excel 12.0 XML";

            using (OleDbConnection dbConnection = new OleDbConnection(connectionString))
            {
                dbConnection.Open();

                var excelSchema = dbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                var sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();

                // Task 06.
                PrintResults(dbConnection, sheetName);
                Console.WriteLine(TaskSeparator);

                // Task 07.
                AddResult(dbConnection, sheetName, "Diana", 100);
                Console.WriteLine(TaskSeparator);
            }
        }

        public static void AddResult(OleDbConnection dbConnection, string sheetName, string userName, int score)
        {
            var addResultOleDbCommand = new OleDbCommand($"INSERT INTO [{sheetName}] VALUES(@Name, @Score)", dbConnection);
            addResultOleDbCommand.Parameters.AddWithValue("@Name", $"{userName}");
            addResultOleDbCommand.Parameters.AddWithValue("@Score", $"{score}");

            try
            {
                var rowsAffected = addResultOleDbCommand.ExecuteNonQuery();
                Console.WriteLine($"Rows affected: {rowsAffected}");
            }
            catch (OleDbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void PrintResults(OleDbConnection dbConnection, string sheetName)
        {
            var allResultsOleDbCommand = new OleDbCommand($"SELECT * FROM [{sheetName}]", dbConnection);

            using (var reader = allResultsOleDbCommand.ExecuteReader())
            {
                reader.Read();
                while (reader.Read())
                {
                    Console.WriteLine($"name: {reader["Name"]}, score: {reader["Score"]}");
                }
            }
        }
    }
}
