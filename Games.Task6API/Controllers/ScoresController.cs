using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Games.Task6API.Data;
using Games.Task5TennisSquash;

namespace Games.Task6API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly IScoreService _scoreService;

        public ScoresController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        // GET: api/ScoreRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScoreRecord>>> GetScoreRecords()
        {
            var scores = await _scoreService.GetAllScoreRecordsAsync();
            return Ok(scores);
        }

        // GET: api/ScoreRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScoreRecord>> GetScoreRecord(Guid id)
        {
            var scoreRecord = await _scoreService.GetScoreRecordAsync(id);
            if (scoreRecord == null)
            {
                return NotFound();
            }
            return Ok(scoreRecord);
        }

        // POST: api/ScoreRecords
        [HttpPost]
        public ActionResult<ScoreRecord> PostScoreRecord(ScoreRecordDto scoreRecord, SportType sportType)
        {
            var result = _scoreService.EvaluateAndSaveScore(scoreRecord, sportType);
            return Ok(result);
        }

        // DELETE: api/ScoreRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScoreRecord(Guid id)
        {
            var success = await _scoreService.DeleteScoreRecordAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/ScoreRecords
        [HttpDelete("DeleteAllScoreRecord")]
        public async Task<IActionResult> DeleteAllScoreRecord()
        {
            await _scoreService.DeleteAllScoreRecordsAsync();
            return NoContent();
        }
    }
}
