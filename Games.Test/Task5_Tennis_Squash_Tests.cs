using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using  Games.Task5TennisSquash;

namespace Games.Test;

public class Task5_Tennis_Squash_Tests
{
    public class TennisScoreTrackerTests
    { 

        [Theory]
        [InlineData("Player1", "Player2", "111100001111", "Player2 beat Player1 (1-2) Score 0-4, 4-0, 0-4")]
        [InlineData("Player1", "Player2", "111001111001 ", "Player2 beat Player1 (0-2) Score 2-4, 2-4")]
        [InlineData("Player1", "Player2", "11100110110111101", "Player2 beat Player1 (0-2) Score 2-4, 2-4")] 
        public void TennisScoreTracker_ShouldCorrectlyPredictWinner(string team1Name, string team2Name, string score, string expectedOutcome)
        {
            IScoreTracker tracker = new TennisScoreTracker(team1Name, team2Name, score);
            tracker.ProcessScore();
            string result = tracker.ResultMessage;
            Assert.Equal(expectedOutcome, result);
        }
    }


    //public class SquashScoreTrackerTests
    //{
    //    // Existing test cases...
         
    //    [Theory]
    //    [InlineData("TeamA", "TeamB", "111000111000111", "TeamA beat TeamB (2-1) Score 15-0, 0-15, 15-0")] 
    //    public void SquashScoreTracker_ShouldCorrectlyPredictWinner(string team1Name, string team2Name, string score, string expectedOutcome)
    //    {
    //        IScoreTracker tracker = new SquashScoreTracker(team1Name, team2Name, score);
    //        tracker.ProcessScore();
    //        string result = tracker.ResultMessage;
    //        Assert.Equal(expectedOutcome, result);
    //    }
    //}


}
