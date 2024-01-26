namespace Games.Task2NameScore;
 


 
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
                    ResultMessage = FormatResultMessage(team2Name, team1Name, count);
                    return;
                }

                if (CheckWinningCondition(count))
                {
                    ResultMessage = FormatResultMessage(team1Name, team2Name, count);
                    return;
                }

                ResetCountsIfTie(count);
            }

            ProcessPostTieScore(count);
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

        private void ProcessPostTieScore(int[] count)
        {
            for (int i = 0; i < score.Length; i++)
            {
                count[score[i] - '0']++;
                if (Math.Abs(count[0] - count[1]) == 2)
                {
                    ResultMessage = count[0] > count[1] ? $"{team2Name} beat {team1Name} {count[1]}-{count[0]}" : $"{team1Name} beat {team2Name} {count[0]}-{count[1]}";
                    return;
                }
            }
        }

        private string FormatResultMessage(string winningTeam, string losingTeam, int[] count)
        {
            return $"{winningTeam} beat {losingTeam} {count[1]}-{count[0]}";
        }
    }
