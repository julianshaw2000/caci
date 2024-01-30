using Xunit;
using Games.Task2NameScore;
using Games.Helper;

namespace Games.Test
{
    public class Task2_WinnerNameTests
    {
        [Fact]
        public void PredictWinner_ShouldCalculateEarlyWinForTeam1()
        {
            string team1Name = "Lions";
            string team2Name = "Tigers";
            string score = "111111111111111";
            int n = 15;

            string expectedOutcome = GameFormatter.TeamsAndScore(team1Name, team2Name);

            string result = WinnerTwoName.PredictWinner(team1Name, team2Name, score, n);
            Assert.Equal(expectedOutcome, result);
        }

        [Fact]
        public void PredictWinner_ShouldCalculateEarlyWinForTeam2()
        {
            string team1Name = "Lions";
            string team2Name = "Tigers";
            string score = "000000000000000";
            int n = 15; 

            string expectedOutcome = GameFormatter.TeamsAndScore(team2Name, team1Name);

            string result = WinnerTwoName.PredictWinner(team1Name, team2Name, score, n);
            Assert.Equal(expectedOutcome, result);
        }

        //[Fact]
        //public void PredictWinner_ShouldCalculateWinForTeam1AfterTie()
        //{
        //    string team1Name = "Lions";
        //    string team2Name = "Tigers";
        //    string score = "101010101010101010101";
        //    int n = 15; 

        //    string expectedOutcome = GameFormatter.TeamsAndScore(team1Name, team2Name);

        //    string result = WinnerTwoName.PredictWinner(team1Name, team2Name, score, n);
        //    Assert.Equal(expectedOutcome, result);
        //}

        //[Fact]
        //public void PredictWinner_ShouldCalculateWinForTeam2AfterTie()
        //{
        //    string team1Name = "Lions";
        //    string team2Name = "Tigers";
        //    string score = "010101010101010101010";
        //    int n = 15; 

        //    string expectedOutcome = GameFormatter.TeamsAndScore(team2Name, team1Name );

        //    string result = WinnerTwoName.PredictWinner(team1Name, team2Name, score, n);
        //    Assert.Equal(expectedOutcome, result);
        //}
         
    }
}
