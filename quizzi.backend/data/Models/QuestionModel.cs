using System;
using System.Dynamic;

namespace data.Models;

public class QuestionModel
{
    public required string Difficulty {get;set;}
    public int Amount {get;set;} = 10;
    public int Category {get;set;}
    public required string Type = "multiple";
}
