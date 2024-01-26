namespace Games.Task4VolleyBall
{
    public class ScoreTracker
    {
        private readonly string team1Name;
        private readonly string team2Name;
        private readonly string score;
        private readonly int pointsToWin = 15;
        private readonly int[] gameWins = new int[2];
        private readonly List<string> gameResults = new List<string>();
        public string ResultMessage { get; private set; } = string.Empty;

        public ScoreTracker(string team1Name, string team2Name, string score)
        {
            this.team1Name = team1Name;
            this.team2Name = team2Name;
            this.score = score;
        }

        public void ProcessScore()
        {
            int[] count = new int[2];
            foreach (char point in score)
            {
                int teamIndex = point - '0';
                if (teamIndex < 0 || teamIndex > 1) continue;  // Skip invalid characters

                count[teamIndex]++;

                if (count[0] >= pointsToWin || count[1] >= pointsToWin)
                {
                    int winningTeamIndex = count[0] >= pointsToWin ? 0 : 1;
                    gameWins[winningTeamIndex]++;
                    gameResults.Add($"{count[0]}-{count[1]}");
                    count = new int[2]; // Reset scores for next game

                    if (gameResults.Count == 3) break; // Assuming a best of 3 games
                }
            }

            FormatResultMessage();
        }

        private void FormatResultMessage()
        {
            if (gameResults.Any())
            {
                string winner = gameWins[0] > gameWins[1] ? team1Name : team2Name;
                string gameScore = $"{gameWins[0]}-{gameWins[1]}";
                string matchScore = string.Join(", ", gameResults);

                ResultMessage = $"{winner} beat {(winner == team1Name ? team2Name : team1Name)} ({gameScore}) Score {matchScore}";
            }
        }
    }
}
