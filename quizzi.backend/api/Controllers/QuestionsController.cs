using core.Managers.Interfaces;
using data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TriviaController : ControllerBase
{
    private readonly ITriviaManager _TriviaManager;
    public TriviaController(ITriviaManager TriviaManager)
    {
        _TriviaManager = TriviaManager;
    }

    [HttpGet("categories")]
    public async Task<IActionResult> GetCategories()
    {
        try
        {
            var categories = await _TriviaManager.GetCategories();
            if (categories == null)
            {
                return NoContent();
            }
            return Ok(categories);
        } 
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("questions")]
    public async Task<IActionResult> RetrieveQuestions([FromBody] QuestionModel questionModel)
    {
        try
        {
            var questions = await _TriviaManager.RetrieveQuestions(questionModel);
            if (questions == null)
            {
                return NoContent();
            }
            return Ok(questions);
        } 
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

