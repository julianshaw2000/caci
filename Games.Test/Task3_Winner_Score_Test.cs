using Xunit;
using Games.Task3WinnerScore;

namespace Games.Test;
     
public class Task3_Winner_Score_Test
    {
        [Theory]
        [InlineData("Ravens", "Badgers", "111111111111111", 15, "Ravens beat Badgers 15-0")] // Team 1 wins all
        [InlineData("Ravens", "Badgers", "000000000000000", 15, "Badgers beat Ravens 0-15")] // Team 2 wins all
        [InlineData("Ravens", "Badgers", "101010101010101010101", 15, "Ravens beat Badgers 10-12")] // Team 1 wins after tie 
        public void PredictWinner_ShouldCalculateCorrectOutcomeAndScore(string team1Name, string team2Name, string score, int n, string expectedOutcome)
        {

       // public WinnerScore(string team1Name, string team2Name, string score, int n)
            string result = WinnerScore.PredictWinner(team1Name, team2Name, score, n);
            Assert.Equal(expectedOutcome, result);
        }
    }






