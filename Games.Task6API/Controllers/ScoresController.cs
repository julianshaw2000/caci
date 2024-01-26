using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Games.Task6API.Data;
using Games.Task5TennisSquash;

namespace Games.Task6API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ScoreService _scoreService;

        public ScoresController(AppDbContext context, ScoreService scoreService)
        {
            _context = context;
            _scoreService = scoreService;
        }
         
         


        // GET: api/ScoreRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScoreRecord>>> GetScoreRecords()
        {
            return await _context.ScoreRecords.ToListAsync();
        }

        // GET: api/ScoreRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScoreRecord>> GetScoreRecord(Guid id)
        {
            var scoreRecord = await _context.ScoreRecords.FindAsync(id);

            if (scoreRecord == null)
            {
                return NotFound();
            }

            return scoreRecord;
        }

       

        // POST: api/ScoreRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public   ActionResult<ScoreRecord> PostScoreRecord(ScoreRecordDto scoreRecord, SportType sportType)
        {
            IScoreTracker tracker;

            switch (sportType)
            {
                case SportType.Tennis:
                    tracker = new TennisScoreTracker(scoreRecord.Team1Name, scoreRecord.Team2Name, scoreRecord.ScoreInput);
                    break;
                case SportType.Squash:
                    tracker = new SquashScoreTracker(scoreRecord.Team1Name, scoreRecord.Team2Name, scoreRecord.ScoreInput);
                    break;
               
                default:
                    tracker = new TennisScoreTracker(scoreRecord.Team1Name, scoreRecord.Team2Name, scoreRecord.ScoreInput);
                    break;
            }
             
            tracker.ProcessScore();
            string result = tracker.ResultMessage;



               _scoreService.EvaluateAndSaveScore(scoreRecord.Team1Name, scoreRecord.Team2Name, scoreRecord.ScoreInput, tracker);
           

            return Ok( scoreRecord );
        }

        // DELETE: api/ScoreRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScoreRecord(Guid id)
        {
            var scoreRecord = await _context.ScoreRecords.FindAsync(id);
            if (scoreRecord == null)
            {
                return NotFound();
            }

            _context.ScoreRecords.Remove(scoreRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/ScoreRecords
        [HttpDelete("DeleteAllScoreRecord")]
        public async Task<IActionResult> DeleteAllScoreRecord()
        {
            var scoreRecords =   _context.ScoreRecords.AsEnumerable();
            if (scoreRecords == null)
            {
                return NotFound();
            }

            _context.ScoreRecords.RemoveRange(scoreRecords);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScoreRecordExists(Guid id)
        {
            return _context.ScoreRecords.Any(e => e.Id == id);
        }
    }
}
