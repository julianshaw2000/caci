using Games.Task5TennisSquash;

namespace Games.Task6API.Data;
public class ScoreService
{
    private readonly AppDbContext _dbContext;

    public ScoreService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Guid EvaluateAndSaveScore(string team1Name, string team2Name, string scoreInput, IScoreTracker tracker)
    {
        // Evaluate the score
        tracker.ProcessScore();
        var result = tracker.ResultMessage;

        // Save to database
        var scoreRecord = new ScoreRecord
        {
            Id = Guid.NewGuid(),
            Team1Name = team1Name,
            Team2Name = team2Name,
            ScoreInput = scoreInput,
            Result = result
        };
        _dbContext.ScoreRecords.Add(scoreRecord);
        _dbContext.SaveChanges();

        return scoreRecord.Id;
    }

    // Methods for retrieving and deleting scores
}

