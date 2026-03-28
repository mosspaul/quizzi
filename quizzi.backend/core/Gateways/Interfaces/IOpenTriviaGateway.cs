using System;
using core.DTOs;
using data.Models;

namespace core.Gateways.Interfaces;

public interface IOpenTriviaGateway
{
    Task<List<CategoryDto>?> GetCategories();
    Task<List<QuestionDto>?> RetrieveQuestions(QuestionModel questionModel);
}
