using Xunit;
using Games.Task2NameScore; 

namespace Games.Test;



public class Task2_SportTeamNameTests
{
    [Theory]
    [InlineData("Lions", "Tigers", "111111111111111", 15, "Lions beat Tigers 15-0")] // Early win for Team 1
    [InlineData("Lions", "Tigers", "000000000000000", 15, "Tigers beat Lions 0-15")] // Early win for Team 2
    [InlineData("Lions", "Tigers", "101010101010101010101", 15, "Lions beat Tigers 10-12")] // Win for Team 1 after a tie
    [InlineData("Lions", "Tigers", "010101010101010101010", 15, "Tigers beat Lions 10-12")] // Win for Team 2 after a tie  
    public void PredictWinner_ShouldCalculateCorrectOutcome(string team1Name, string team2Name, string score, int n, string expectedOutcome)
    {
        string result = WinnerTwoName.PredictWinner(team1Name, team2Name, score, n);
        Assert.Equal(expectedOutcome, result);
    }
}
