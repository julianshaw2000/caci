

namespace Games.Helper
{
    public static class GameFormatter
    {
        public const string Team1Won = "Team 1 won";
        public const string Team1Lost = "Team 1 lost";
        public const string Team2Won = "Team 2 won";
        public const string Team2Lost = "Team 2 lost";

        //public static string Task2Message(string team1, string team2, int count1,int count2)
        // {
        //     return count1 > count2 ? $"{team2} beat {team1} {count2}-{count1}" : $"{team1} beat {team2} {count1}-{count2}";
        // }


        // public static string FormatWinnerScoreMessage(string winningTeam, string losingTeam, int winningTeamScore, int losingTeamScore)
        // {
        //     return $"{winningTeam} beat {losingTeam} {winningTeamScore}-{losingTeamScore}";
        // }


        // //   ResultMessage = count[0] > count[1]? $"{team2Name} beat {team1Name} {count[1]}-{count[0]}" : $"{team1Name} beat {team2Name} {count[0]}-{count[1]}";


        public static string TeamsAndScore(string winningTeam, string losingTeam, int winningTeamScore, int losingTeamScore)
        {
            return $"{winningTeam} beat {losingTeam} {winningTeamScore}-{losingTeamScore}";

        }

        public static string TeamsAndScore(string winningTeam, string losingTeam, int[] count)
        {
            var winningTeamScore = count[0] > count[1] ? count[0] : count[1];
            var losingTeamScore = count[0] <= count[1] ? count[1] : count[0];

            return $"{winningTeam} beat {losingTeam} {winningTeamScore}-{losingTeamScore}";
        }

       

        public static string TeamsAndScore(string winningTeam, string losingTeam)
        {
            return $"{winningTeam} beat {losingTeam}";
        }
    }
}
