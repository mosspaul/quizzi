using System.Data.Common;
using System.Text.Json.Serialization;
using core.DTOs;
using core.Gateways.Interfaces;
using data.Models;
using Newtonsoft.Json;

namespace core.Gateways;

public class OpenTriviaGateway : IOpenTriviaGateway
{
    private readonly HttpClient _http;
    private TokenDto? _token;

    public OpenTriviaGateway(HttpClient http)
    {
        _http = http;
        _token = null;
    }


    private async Task GetSessionToken()
    {
        var request = new HttpRequestMessage(
            HttpMethod.Get, 
            "https://opentdb.com/api_token.php?command=request"
        );
        HttpResponseMessage response = await _http.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.ReasonPhrase);
        }
        string tokenJson = await response.Content.ReadAsStringAsync();
        var token = JsonConvert.DeserializeObject<TokenDto>(tokenJson);
        if (token?.ResponseCode == 0)
        {
            _token = token;
        }
    }
    public async Task<List<CategoryDto>?> GetCategories()
    {

        await GetSessionToken();
        
        var request = new HttpRequestMessage(
            HttpMethod.Get,
            "https://opentdb.com/api_category.php"
        );
        HttpResponseMessage response = await _http.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.ReasonPhrase);
        }
        string categoriesJson = await response.Content.ReadAsStringAsync();
        var categories = JsonConvert.DeserializeObject<CategoriesRoot>(categoriesJson)?.Categories;

        return categories;
    }

    public async Task<List<QuestionDto>?> RetrieveQuestions(QuestionModel questionModel)
    {
        var request = new HttpRequestMessage(
            HttpMethod.Get,
            UrlBuilder(questionModel)
        );
        HttpResponseMessage response = await _http.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.ReasonPhrase);
        }
        string questionsJson = await response.Content.ReadAsStringAsync();
        var questions = JsonConvert.DeserializeObject<Result>(questionsJson)?.Questions;
        return questions;
    }

    private string UrlBuilder(QuestionModel questionModel)
    {
        string url = $"https://opentdb.com/api.php?amount={questionModel.Amount}&category={questionModel.Category}&difficulty={questionModel.Difficulty}&type={questionModel.Type}";
        return _token != null ? url + $"&token={_token.Token}" : url;
    }
}
