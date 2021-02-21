using System;
using System.Text;
using Microsoft.Data.SqlClient;

namespace P02_VillainNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string ConnectionString = "Server=.;Database=MinionsDB;Integrated Security=true";
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            string getVillainsWithMoreThanThreeeMinionsQuerryText =@"
                                                          SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                                            FROM Villains AS v 
                                                            JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                                        GROUP BY v.Id, v.Name 
                                                          HAVING COUNT(mv.VillainId) > 3 
                                                        ORDER BY COUNT(mv.VillainId)";
            using SqlCommand getVillainsWithMoreThanThreeeMinionsCommand =
                new SqlCommand(getVillainsWithMoreThanThreeeMinionsQuerryText, sqlConnection);

            using SqlDataReader reader = getVillainsWithMoreThanThreeeMinionsCommand.ExecuteReader();

            StringBuilder sb = new StringBuilder();

            while (reader.Read())
            {
                string villainName = reader["Name"].ToString();
                string countOfMinions = reader["MinionsCount"].ToString();
                sb.AppendLine($"{villainName} - {countOfMinions}");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
