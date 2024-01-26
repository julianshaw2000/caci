using Games.Task5TennisSquash;

namespace Games.Task5TennisSquash;

public interface IScoreTracker
{
    void ProcessScore();
    string ResultMessage { get; }
}


public class SquashScoreTracker : IScoreTracker
{ 
        private readonly string team1Name;
        private readonly string team2Name;
        private readonly string score;
        private readonly int gamesToWin = 2;
        private readonly int pointsToWin = 11;
        private readonly int deucePoint = 10;
        private readonly int[] gameWins = new int[2];
        private readonly List<string> gameScores = new List<string>();
        public string ResultMessage { get; private set; } = string.Empty;

        public SquashScoreTracker(string team1Name, string team2Name, string score)
        {
            this.team1Name = team1Name;
            this.team2Name = team2Name;
            this.score = score;
        }

        public void ProcessScore()
        {
            int[] points = new int[2];
            int currentGame = 0;

            foreach (char ch in score)
            {
                int teamIndex = ch - '0';
                if (teamIndex < 0 || teamIndex > 1) continue; // Ignore invalid characters

                points[teamIndex]++;

                if (IsGameWon(points))
                {
                    gameWins[teamIndex]++;
                    gameScores.Add($"{points[0]}-{points[1]}");
                    points = new int[2];
                    currentGame++;

                    if (gameWins[0] == gamesToWin || gameWins[1] == gamesToWin || currentGame == 3)
                    {
                        SetResultMessage();
                        break;
                    }
                }
            }
        }

        private bool IsGameWon(int[] points)
        {
            // Check if a player has won the game
            if (points[0] >= pointsToWin || points[1] >= pointsToWin)
            {
                int pointDifference = Math.Abs(points[0] - points[1]);
                if ((points[0] >= deucePoint || points[1] >= deucePoint) && pointDifference >= 2)
                {
                    return true;
                }
                else if (points[0] < deucePoint && points[1] < deucePoint)
                {
                    return true;
                }
            }
            return false;
        }

        private void SetResultMessage()
        {
            string winner = gameWins[0] > gameWins[1] ? team1Name : team2Name;
            string setScore = $"{gameWins[0]}-{gameWins[1]}";
            string matchScore = string.Join(", ", gameScores);

            var teamWinner = team1Name != winner ? team1Name : team2Name;


            ResultMessage = $"{winner} beat {teamWinner} ({setScore}) Score {matchScore}";
        }
    }








public class TennisScoreTracker : IScoreTracker
{     
        private readonly string team1Name;
        private readonly string team2Name;
        private readonly string score;
        private readonly int gamesToWin = 2;
        private readonly int pointsToWin = 4;
        private readonly int deucePoint = 4;
        private readonly int[] gameWins = new int[2];
        private readonly List<string> gameScores = new List<string>();
        public string ResultMessage { get; private set; } = string.Empty;

        public TennisScoreTracker(string team1Name, string team2Name, string score)
        {
            this.team1Name = team1Name;
            this.team2Name = team2Name;
            this.score = score;
        }

        public void ProcessScore()
        {
            int[] points = new int[2];
            int currentGame = 0;

            foreach (char ch in score)
            {
                int teamIndex = ch - '0';
                if (teamIndex < 0 || teamIndex > 1) continue; // Ignore invalid characters

                points[teamIndex]++;

                if (IsGameWon(points))
                {
                    gameWins[teamIndex]++;
                    gameScores.Add($"{points[0]}-{points[1]}");
                    points = new int[2];
                    currentGame++;

                    if (gameWins[0] == gamesToWin || gameWins[1] == gamesToWin || currentGame == 3)
                    {
                        SetResultMessage();
                        break;
                    }
                }
            }
        }

        private bool IsGameWon(int[] points)
        {
            // Check if a player has won the game
            if (points[0] >= pointsToWin || points[1] >= pointsToWin)
            {
                int pointDifference = Math.Abs(points[0] - points[1]);
                if ((points[0] >= deucePoint || points[1] >= deucePoint) && pointDifference >= 2)
                {
                    return true;
                }
                else if (points[0] < deucePoint && points[1] < deucePoint)
                {
                    return true;
                }
            }
            return false;
        }

        private void SetResultMessage()
        {
            string winner = gameWins[0] > gameWins[1] ? team1Name : team2Name;
            string setScore = $"{gameWins[0]}-{gameWins[1]}";
            string matchScore = string.Join(", ", gameScores);

            var teamWinner = team1Name != winner ? team1Name : team2Name;

            ResultMessage = $"{winner} beat {teamWinner} ({setScore}) Score {matchScore}";
        }
    }




 

 

public class MatchPredictor
{
    public static string PredictWinner(string team1Name, string team2Name, string score, IScoreTracker tracker)
    {
        tracker.ProcessScore();
        return tracker.ResultMessage;
    }
}

//IScoreTracker volleyballTracker = new SquashScoreTracker("TeamA", "TeamB", "111000111...");
//string volleyballResult = MatchPredictor.PredictWinner("TeamA", "TeamB", "111000111...", volleyballTracker);

//IScoreTracker tennisTracker = new TennisScoreTracker("Player1", "Player2", "11112111221122");
//string tennisResult = MatchPredictor.PredictWinner("Player1", "Player2", "11112111221122", tennisTracker);
