using System;
using System.Collections.Generic;
using System.Text;

namespace _05_FootballTeamGenerator.Common
{
    public static class GlobalConstants

    {
        public static string InvalidStatMSG = "{0} should be between {1} and {2}.";
        public static string EmptyNameExpectionMSG = "A name should not be empty.";
        public static string RemovingMissingPlayerExeptionMSG = "Player {0} is not in {1} team.";
        public static string TeamDoesNotExist = "Team {0} does not exist.";
    }
}
