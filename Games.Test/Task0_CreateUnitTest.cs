﻿using System;
using System.IO;
using Xunit;

namespace Games.Test
{
    public class Task0_CreateUnitTest
    { 
         
            [Theory]
            [InlineData("1001010101111011101111", "Team 1 won")] // Team 1 wins normally 
            [InlineData("000000000000000", "Team 1 lost")] // Team 1 loses by opponent reaching 15 first 
            [InlineData("111111111111110111", "Team 1 won")] // Team 1 wins in a tie-breaker 
            public void PredictWinnerTest(string score, string expectedOutput)
            {
                using (var sw = new StringWriter())
                {
                    Console.SetOut(sw);

                    Sport.PredictWinner(score, 15);

                    var result = sw.ToString().Trim();
                    Assert.Equal(expectedOutput, result);
                }
            }
        
 
    }
}
