using Games.Task4VolleyBall;
using Games.Task5TennisSquash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Test;

public class Task4_VolleyBall_Three_Game_Tests
{



    [Theory]

    // Test for a match where one team consistently wins
    [InlineData("Ravens", "Badgers", "111111111111111111111111111111111111111111111111", "Badgers beat Ravens (0-3) Score 0-15, 0-15, 0-15")]

    // Test for a match with alternating wins and a close final set
    [InlineData("Ravens", "Badgers", "111001110001110011100011111111111110000011111", "Badgers beat Ravens (0-2) Score 10-15, 5-15")]

    // Test for a match that includes a set with extended play beyond 15 points
    [InlineData("Ravens", "Badgers", "1111111111100000000000011111111111111111100000000011111", "Badgers beat Ravens (0-2) Score 12-15, 9-15")] 

    public void PredictWinner_ShouldCalculateCorrectOutcomeAndScore2(string team1Name, string team2Name, string score, string expectedOutcome)
    {
        var tracker = new ScoreTracker(team1Name, team2Name, score);
        tracker.ProcessScore();
        string result = tracker.ResultMessage;
        Assert.Equal(expectedOutcome, result);
    }
}
