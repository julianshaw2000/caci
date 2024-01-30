using Games.Helper;
using Games.Task1Refactor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Test;

public class Task1_Refactor_Tests
{

    [Theory]

    [InlineData("1001010101111011101111",15,GameFormatter.Team1Won)] // Team 1 wins normally - Original
    [InlineData("000000000000000",15,  GameFormatter.Team1Lost)] // Team 1 loses by opponent reaching 15 first - Original
    [InlineData("111111111111110111",15, GameFormatter.Team1Won)] // Team 1 wins in a tie-breaker - Original 
    [InlineData("111111111111111", 15, GameFormatter.Team1Won)] // Team 1 wins early 
    [InlineData("101010101010101010101",15, GameFormatter.Team1Won)] // Team 1 wins after tie
    [InlineData("010101010101010101010", 15, GameFormatter.Team1Lost)] // Team 1 loses after tie 
    public void PredictWinner_ShouldCalculateCorrectOutcome(string score, int n, string expectedOutcome)
    {
        var result = SportRefactor.PredictWinner(score, n); 

        Assert.Equal(expectedOutcome, result);
    }
}