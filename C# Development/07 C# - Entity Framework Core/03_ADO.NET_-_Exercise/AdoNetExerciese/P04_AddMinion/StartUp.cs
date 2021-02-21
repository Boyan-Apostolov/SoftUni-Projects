using System;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;

namespace P04_AddMinion
{
    class StartUp
    {
        private const string ConnectionString = @"Server=.;Database=MinionsDB;Integrated Security=true";

        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            string[] minionsInput = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] minionsInfo = minionsInput[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            string[] villainsInput = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] villainsInfo = villainsInput[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            string result = AddMinionToDatabase(sqlConnection, minionsInfo, villainsInfo);

            Console.WriteLine(result);
        }

        private static string AddMinionToDatabase(SqlConnection sqlConnection, string[] minionsInfo, string[] villainsInfo)
        {
            StringBuilder output = new StringBuilder();

            string minionName = minionsInfo[0];
            string minionAge = minionsInfo[1];
            string minionTown = minionsInfo[2];

            string villainName = villainsInfo[0];

            string townId = EnsureTownExists(sqlConnection, minionTown, output);

            string villainId = EnsureVillainExists(sqlConnection, villainName, output);

            string insertMinionQuerryText =
                @"INSERT INTO Minions(Name,Age,TownId) VALUES (@minionName,@minionAge,@townId)";
            using SqlCommand insertMinionCommand = new SqlCommand(insertMinionQuerryText, sqlConnection);
            insertMinionCommand.Parameters.AddRange(new []
            {
                new SqlParameter("@minionName",minionName), 
                new SqlParameter("@minionAge",minionAge), 
                new SqlParameter("@townId",townId), 
            });

            insertMinionCommand.ExecuteNonQuery();

            string getMinionIdQuerryText = $"SELECT Id FROM Minions WHERE Name = @minionName";

            using SqlCommand getMinionIdCommand = new SqlCommand(getMinionIdQuerryText,sqlConnection);
            getMinionIdCommand.Parameters.AddWithValue("@minionName", minionName);

            string minionId = getMinionIdCommand.ExecuteScalar().ToString();


            string insertIntoMappingQuerryText =
                @"INSERT INTO MinionsVillains(MinionId,VillainId) VALUES (@minionId,@villainId)";
            using SqlCommand insertIntoMappungCommand = new SqlCommand(insertIntoMappingQuerryText, sqlConnection);

            insertIntoMappungCommand.Parameters.AddWithValue("@minionId", minionId);
            insertIntoMappungCommand.Parameters.AddWithValue("@villainId", villainId);

            insertIntoMappungCommand.ExecuteNonQuery();

            output.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

            return output.ToString().TrimEnd();
        }

        private static string EnsureVillainExists(SqlConnection sqlConnection, string villainName, StringBuilder output)
        {
            string getVillainIdQuerryText = @"SELECT Id FROM Villains WHERE Name = @name";
            using SqlCommand getVillainIdCommand = new SqlCommand(getVillainIdQuerryText, sqlConnection);
            getVillainIdCommand.Parameters.AddWithValue("@name", villainName);

            string villainId = getVillainIdCommand.ExecuteScalar()?.ToString();

            if (villainId == null)
            {
                string getFactorIdQuerryText = @"SELECT Id FROM EvilnessFactors WHERE Name = 'Evil'";
                using SqlCommand getFactorIdCommand = new SqlCommand(getFactorIdQuerryText, sqlConnection);

                string factorId = getFactorIdCommand.ExecuteScalar()?.ToString();

                string insertVillainQuerryText =
                    @"INSERT INTO Villains(Name,EvilnessFactorId) VALUES (@villainName, @factorId)";
                using SqlCommand insertVillainCommand = new SqlCommand(insertVillainQuerryText,sqlConnection);

                insertVillainCommand.Parameters.AddWithValue("@villainName", villainName);
                insertVillainCommand.Parameters.AddWithValue("@factorId", factorId);

                insertVillainCommand.ExecuteNonQuery();

                villainId = getVillainIdCommand.ExecuteScalar().ToString();

                output.AppendLine($"Villain {villainName} was added to the database.");
            }

            return villainId;
        }

        private static string EnsureTownExists(SqlConnection sqlConnection, string minionTown, StringBuilder output)
        {
            string getTownIdQuerryText = @"SELECT Id FROM Towns WHERE Name = @townName";

            using SqlCommand getTownIdCommand = new SqlCommand(getTownIdQuerryText,sqlConnection);
            getTownIdCommand.Parameters.AddWithValue("@townName", minionTown);

            string townId = getTownIdCommand.ExecuteScalar()?.ToString();

            if (townId == null)
            {
                string insertTownQuerryText = @"INSERT INTO Towns(Name,CountryCode) VALUES (@townName,1)";

                using SqlCommand insertTownCommand = new SqlCommand(insertTownQuerryText,sqlConnection);
                insertTownCommand.Parameters.AddWithValue("@townName", minionTown);

                insertTownCommand.ExecuteNonQuery();

                townId = getTownIdCommand.ExecuteScalar().ToString();

                output.AppendLine($"Town {minionTown} was added to the database.");
                output.ToString().TrimEnd();
            }

            return townId;
        }
    }
}
