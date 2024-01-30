using Xunit;
using Games.Task3WinnerScore;
using Games.Helper;

namespace Games.Test
{
    public class Task3_Winner_Score_Test
    {
        [Fact]
        public void PredictWinner_ShouldCalculateTeam1WinningAll()
        {
            string team1Name = "Ravens";
            string team2Name = "Badgers";
            string score = "111111111111111";
            int n = 15;
            string expectedOutcome = "Ravens beat Badgers 15-0";

            string result = WinnerScore.PredictWinner(team1Name, team2Name, score, n);
            Assert.Equal(expectedOutcome, result);
        }

        [Fact]
        public void PredictWinner_ShouldCalculateTeam2WinningAll()
        {
            string team1Name = "Ravens";
            string team2Name = "Badgers";
            string score = "000000000000000";
            int n = 15;
          //  string expectedOutcome = "Badgers beat Ravens 0-15";

            string expectedOutcome = GameFormatter.TeamsAndScore(team1Name, team2Name, 15, 0);

            string result = WinnerScore.PredictWinner(team1Name, team2Name, score, n);
            Assert.Equal(expectedOutcome, result);
        }

        [Fact]
        public void PredictWinner_ShouldCalculateTeam1WinningAfterTie()
        {
            string team1Name = "Ravens";
            string team2Name = "Badgers";
            string score = "1010101010101010101011111";
            int n = 15;
            string expectedOutcome = "Ravens beat Badgers 15-10";

            string result = WinnerScore.PredictWinner(team1Name, team2Name, score, n);
            Assert.Equal(expectedOutcome, result);
        }
         
    }
}
