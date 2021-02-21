using System;
using Microsoft.Data.SqlClient;

namespace AdoNetDemo
{
    class Program2
    {
        static void Mai(string[] args)
        {
            string connectionString = "Server=.;Database=SoftUni;Integrated Security=true";
            SqlConnection sqlConnection2 = new SqlConnection(connectionString);

            using (SqlConnection sqlConnection =
                new SqlConnection("Server=.;Database=SoftUni;Integrated Security=true"))
            {
                sqlConnection.Open();

                string command = "SELECT COUNT(*) FROM Employees";
                SqlCommand sqlCommand = new SqlCommand(command,sqlConnection);

                object result = sqlCommand.ExecuteScalar();

                Console.WriteLine(result);



                string command2 = "SELECT FirstName, LastName FROM Employees WHERE FirstName LIKE 'N%'";
                SqlCommand sqlCommand2 = new SqlCommand(command2, sqlConnection);
                using (SqlDataReader reader = sqlCommand2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string firstName = (string) reader["FirstName"];
                        string lastName = (string) reader["LastName"];
                        Console.WriteLine(firstName + ' ' + lastName);
                    }
                }

                SqlCommand updateSalary = new SqlCommand("UPDATE Employees SET Salary = Salary * 1.10", sqlConnection);
                int updatedRows = updateSalary.ExecuteNonQuery();
                Console.WriteLine($"Salary updated for {updatedRows} employees");

            }
        }
    }
}
