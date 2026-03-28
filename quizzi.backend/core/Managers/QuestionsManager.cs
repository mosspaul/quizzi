using System;
using core.DTOs;
using core.Gateways.Interfaces;
using core.Managers.Interfaces;
using data.Models;

namespace core.Managers;

public class TriviaManager : ITriviaManager
{
    private readonly IOpenTriviaGateway _triviaGateway;

    public TriviaManager(IOpenTriviaGateway triviaGateway)
    {
        _triviaGateway = triviaGateway;        
    }

    public async Task<List<CategoryDto>?> GetCategories()
    {
        return await _triviaGateway.GetCategories();
    }

    public async Task<List<QuestionDto>?> RetrieveQuestions(QuestionModel questionModel)
    {
        return await _triviaGateway.RetrieveQuestions(questionModel);
    }
}
