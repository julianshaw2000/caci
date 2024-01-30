using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Games.Task6API.Data;
using Games.Task5TennisSquash;
using Games.Task6API.Controllers;

namespace Games.Task6API.Tests
{
    public class ScoresControllerTests
    {
        private readonly Mock<IScoreService> _mockScoreService;
        private readonly ScoresController _controller;

        public ScoresControllerTests()
        {
            _mockScoreService = new Mock<IScoreService>();
            _controller = new ScoresController(_mockScoreService.Object);
        }

        [Fact]
        public async Task GetScoreRecords_ReturnsAllScores()
        {
            // Arrange
            var mockScores = new List<ScoreRecord> { /* populate with test data */ };
            _mockScoreService.Setup(service => service.GetAllScoreRecordsAsync())
                             .ReturnsAsync(mockScores);

            // Act
            var result = await _controller.GetScoreRecords();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedScores = Assert.IsAssignableFrom<IEnumerable<ScoreRecord>>(actionResult.Value);
            Assert.Equal(mockScores, returnedScores); 
        }

        [Fact]
        public async Task GetScoreRecord_ReturnsScore_WhenScoreExists()
        {
            // Arrange
            var mockScore = new ScoreRecord { /* populate with test data */ };
            _mockScoreService.Setup(service => service.GetScoreRecordAsync(It.IsAny<Guid>()))
                             .ReturnsAsync(mockScore);

            // Act
            var result = await _controller.GetScoreRecord(Guid.NewGuid());

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(mockScore, actionResult.Value); 
        }

     //   [Fact(Skip = "Later")]
        [Fact]
        public async Task GetScoreRecord_ReturnsNotFound_WhenScoreDoesNotExist()
        {
            // Arrange
            _mockScoreService.Setup(service => service.GetScoreRecordAsync(It.IsAny<Guid>()))
                             .ReturnsAsync((ScoreRecord)null);

            // Act
            var result = await _controller.GetScoreRecord(Guid.NewGuid());

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Theory]
        [InlineData("11111111-1111-1111-1111-111111111111")]
        [InlineData("22222222-2222-2222-2222-222222222222")]
        public async Task GetScoreRecord_ReturnsScore_WhenScoreExists2(string guidString)
        {
            // Arrange
            var mockScore = new ScoreRecord { /* populate with test data */ };
            var guid = Guid.Parse(guidString);
            _mockScoreService.Setup(service => service.GetScoreRecordAsync(guid))
                             .ReturnsAsync(mockScore);

            // Act
            var result = await _controller.GetScoreRecord(guid);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(mockScore, actionResult.Value);
        }


    }
}
