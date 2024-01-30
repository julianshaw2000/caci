namespace Games.Task2NameScore
{
    public class WinnerTwoName
    {
        public static string PredictWinner(string team1Name, string team2Name, string score, int n)
        {
            ScoreTracker tracker = new ScoreTracker(team1Name, team2Name, score, n);
            tracker.ProcessScore();
            return tracker.ResultMessage;
        }
    }

    internal class ScoreTracker
    {
        private readonly string team1Name;
        private readonly string team2Name;
        private readonly string score;
        private readonly int n;
        public string ResultMessage { get; set; } = string.Empty;

        internal ScoreTracker(string team1Name, string team2Name, string score, int n)
        {
            this.team1Name = team1Name;
            this.team2Name = team2Name;
            this.score = score;
            this.n = n;
        }

        internal void ProcessScore()
        {
            int[] count = new int[2];
            for (int i = 0; i < score.Length; i++)
            {
                count[score[i] - '0']++;

                if (CheckLosingCondition(count))
                {
                    ResultMessage = Games.Helper.GameFormatter.TeamsAndScore(team2Name, team1Name);
                    return;
                }

                if (CheckWinningCondition(count))
                {
                    ResultMessage = Games.Helper.GameFormatter.TeamsAndScore(team1Name, team2Name);
                    return;
                }

                ResetCountsIfTie(count);
            }

            // Handle any additional logic for ties or other scenarios
        }

        private bool CheckLosingCondition(int[] count)
        {
            return count[0] == n && count[1] < n - 1;
        }

        private bool CheckWinningCondition(int[] count)
        {
            return count[1] == n && count[0] < n - 1;
        }

        private void ResetCountsIfTie(int[] count)
        {
            if (count[0] == n - 1 && count[1] == n - 1)
            {
                count[0] = 0;
                count[1] = 0;
            }
        }

        // Other methods can be added as needed
    }
}
 
