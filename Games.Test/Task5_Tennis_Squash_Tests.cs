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
        [InlineData("Player1", "Player2", "11112111221122", "Player1 beat Player2 (2-1) Score 4-2, 2-4, 4-2")]
        // Test for a match with a clear win without reaching deuce
        [InlineData("Player1", "Player2", "111011101110", "Player1 beat Player2 (2-0) Score 4-1, 4-1")]

        // Test for a match that goes to deuce
        [InlineData("Player1", "Player2", "1111222211112222", "Player1 beat Player2 (2-0) Score 6-4, 6-4")]

        // Test for a match where the second player wins
        [InlineData("Player1", "Player2", "0000222200002222", "Player2 beat Player1 (2-0) Score 2-4, 2-4")]
        // Add more test data here for various tennis match scenarios
        public void TennisScoreTracker_ShouldCorrectlyPredictWinner(string team1Name, string team2Name, string score, string expectedOutcome)
        {
            IScoreTracker tracker = new TennisScoreTracker(team1Name, team2Name, score);
            tracker.ProcessScore();
            string result = tracker.ResultMessage;
            Assert.Equal(expectedOutcome, result);
        }
    }


    public class SquashScoreTrackerTests
    {
        // Existing test cases...
         
        [Theory]
        [InlineData("TeamA", "TeamB", "111000111000111", "TeamA beat TeamB (2-1) Score 15-0, 0-15, 15-0")] 
        public void SquashScoreTracker_ShouldCorrectlyPredictWinner(string team1Name, string team2Name, string score, string expectedOutcome)
        {
            IScoreTracker tracker = new SquashScoreTracker(team1Name, team2Name, score);
            tracker.ProcessScore();
            string result = tracker.ResultMessage;
            Assert.Equal(expectedOutcome, result);
        }
    }


}
