using System;
using Microsoft.Data.SqlClient;

namespace AdoNetDemo
{
    class Program
    {
        static void Main(string[] args)
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





                using (SqlConnection sqlConnection22 =
                    new SqlConnection("Server=.;Database=Service;Integrated Security=true"))
                {
                    sqlConnection22.Open();

                   // string Username = "ealpine0";
                    string Username = " 'OR 1=1 --";

                    string command22= "SELECT COUNT(*) FROM Users WHERE Username = '"+Username+"'";
                    SqlCommand sqlCommand22 = new SqlCommand(command22, sqlConnection22);

                    int usersCount = (int) sqlCommand22.ExecuteScalar();

                    if (usersCount>0)
                    {
                        Console.WriteLine("you got in");
                    }
                }
            }
        }
    }
}
