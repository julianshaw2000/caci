
using Moq;
using Games.Task6API.Controllers;
using Games.Task6API.Data;
using Microsoft.EntityFrameworkCore; 
using Microsoft.AspNetCore.Mvc; 
public class ScoresControllerTests
{

    private readonly Mock<AppDbContext> _mockContext;
    private readonly Mock<DbSet<ScoreRecord>> _mockSet;
    private readonly Mock<ScoreService> _mockScoreService;
    private readonly ScoresController _controller;
    public ScoresControllerTests()
{
    _mockSet = new Mock<DbSet<ScoreRecord>>();
    _mockContext = new Mock<AppDbContext>();
    _mockScoreService = new Mock<ScoreService>();

    _mockContext.Setup(m => m.ScoreRecords).Returns(_mockSet.Object);
    _controller = new ScoresController(_mockContext.Object, _mockScoreService.Object);
}



[Fact]
public async Task GetScoreRecord_ReturnsScoreById()
{
    // Arrange
    var scoreRecordId = Guid.NewGuid();
    var scoreRecord = new ScoreRecord { Id = scoreRecordId, /* ... other properties ... */ };
    _mockSet.Setup(m => m.FindAsync(scoreRecordId)).ReturnsAsync(scoreRecord);

    // Act
    var result = await _controller.GetScoreRecord(scoreRecordId);

    // Assert
    var actionResult = Assert.IsType<ActionResult<ScoreRecord>>(result);
    var returnValue = Assert.IsType<ScoreRecord>(actionResult.Value);
    Assert.Equal(scoreRecordId, returnValue.Id);
}






    [Fact]
    public async Task PostScoreRecord_CreatesNewScoreRecord()
    {
        // Arrange
        var mockSet = new Mock<DbSet<ScoreRecord>>();
        var mockContext = new Mock<AppDbContext>();
        mockContext.Setup(m => m.ScoreRecords).Returns(mockSet.Object);

        var mockScoreService = new Mock<ScoreService>(mockContext.Object);
        var controller = new ScoresController(mockContext.Object, mockScoreService.Object);

        var newScoreRecordDto = new ScoreRecordDto
        {
            // Populate with test data
        };

        // Act
        var result = controller.PostScoreRecord(newScoreRecordDto, SportType.Tennis);

        // Assert
        mockSet.Verify(m => m.Add(It.IsAny<ScoreRecord>()), Times.Once);
        mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        Assert.IsType<ActionResult<ScoreRecord>>(result);
    }






    [Fact]
    public async Task DeleteScoreRecord_RemovesScoreRecord()
    {
        // Arrange
        var mockSet = new Mock<DbSet<ScoreRecord>>();
        var mockContext = new Mock<AppDbContext>();
        mockContext.Setup(m => m.ScoreRecords).Returns(mockSet.Object);

        var mockScoreService = new Mock<ScoreService>(mockContext.Object);
        var controller = new ScoresController(mockContext.Object, mockScoreService.Object);

        var newScoreRecordDto = new ScoreRecordDto
        {
            // Populate with test data
        };

       
         
        var Id = Guid.NewGuid();

        // Act
        var result = await controller.DeleteScoreRecord(Id);

        // Assert
        mockSet.Verify(m => m.Remove(It.IsAny<ScoreRecord>()), Times.Once);
        mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        Assert.IsType<NoContentResult>(result);


    }






     





}
