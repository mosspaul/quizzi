using System;
using Newtonsoft.Json;

namespace core.DTOs;


public class Result
{
    [JsonProperty("response_code")]
    public int ResponseCode { get; set; }

    [JsonProperty("results")]
    public List<QuestionDto> Questions { get; set; }
}

public class QuestionDto
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("difficulty")]
    public string Difficulty { get; set; }

    [JsonProperty("category")]
    public string Category { get; set; }

    [JsonProperty("question")]
    public string Question { get; set; }

    [JsonProperty("correct_answer")]
    public string CorrectAnswer { get; set; }

    [JsonProperty("incorrect_answers")]
    public List<string> IncorrectAnswers { get; set; }
}