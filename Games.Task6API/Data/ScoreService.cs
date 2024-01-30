using Games.Task5TennisSquash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Games.Task6API.Data
{
    public interface IScoreService
    {
        public Task<IEnumerable<ScoreRecord>> GetAllScoreRecordsAsync();
        public Task<ScoreRecord> GetScoreRecordAsync(Guid id);
        public ScoreRecordDto EvaluateAndSaveScore(ScoreRecordDto scoreRecordDto, SportType sportType);
        public Task<bool> DeleteScoreRecordAsync(Guid id);
        public Task DeleteAllScoreRecordsAsync();

    }

    public class ScoreService : IScoreService
    {
        private readonly AppDbContext _dbContext;

        public ScoreService()
        {
            
        }
        public ScoreService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ScoreRecord>> GetAllScoreRecordsAsync()
        {
            return await _dbContext.ScoreRecords.ToListAsync();
        }

        public async Task<ScoreRecord> GetScoreRecordAsync(Guid id)
        {
            return await _dbContext.ScoreRecords.FindAsync(id);
        }

        public ScoreRecordDto EvaluateAndSaveScore(ScoreRecordDto scoreRecordDto, SportType sportType)
        {
            IScoreTracker tracker = CreateTracker(scoreRecordDto, sportType);
            tracker.ProcessScore();

            var scoreRecord = new ScoreRecord
            {
                Id = Guid.NewGuid(),
                Team1Name = scoreRecordDto.Team1Name,
                Team2Name = scoreRecordDto.Team2Name,
                ScoreInput = scoreRecordDto.ScoreInput,
                Result = tracker.ResultMessage
            };

            _dbContext.ScoreRecords.Add(scoreRecord);
            _dbContext.SaveChanges();

            return scoreRecordDto;
        }

        private IScoreTracker CreateTracker(ScoreRecordDto scoreRecordDto, SportType sportType)
        {

            switch (sportType)
            {
                case SportType.Tennis:
                    return new TennisScoreTracker(scoreRecordDto.Team1Name, scoreRecordDto.Team2Name, scoreRecordDto.ScoreInput);

                case SportType.Squash:
                    return new SquashScoreTracker(scoreRecordDto.Team1Name, scoreRecordDto.Team2Name, scoreRecordDto.ScoreInput);

                default:
                    throw new ArgumentException("Invalid sport type");
            }
        
        }
           

        

        public async Task<bool> DeleteScoreRecordAsync(Guid id)
        {
            var scoreRecord = await _dbContext.ScoreRecords.FindAsync(id);
            if (scoreRecord == null)
            {
                return false;
            }

            _dbContext.ScoreRecords.Remove(scoreRecord);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task DeleteAllScoreRecordsAsync()
        {
            var allRecords = _dbContext.ScoreRecords;
            _dbContext.ScoreRecords.RemoveRange(allRecords);
            await _dbContext.SaveChangesAsync();
        }
    }
}
