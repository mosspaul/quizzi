using Newtonsoft.Json;

namespace core.DTOs;

public class CategoriesRoot
    {
        [JsonProperty("trivia_categories")]
        public List<CategoryDto> Categories { get; set; }
    }

    public class CategoryDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
