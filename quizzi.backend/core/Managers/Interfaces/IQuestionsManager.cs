using System;
using core.DTOs;
using data.Models;

namespace core.Managers.Interfaces;

public interface ITriviaManager
{
    Task<List<CategoryDto>?> GetCategories();
    Task<List<QuestionDto>?> RetrieveQuestions(QuestionModel questionModel);
}
