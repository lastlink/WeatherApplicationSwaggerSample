using System.Text.Json.Serialization;

namespace WebApplication5
{
    /// <summary>
    /// WeatherForecast (11,0)-(19,1)
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// get or set date
        /// </summary>
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
        public List<NestedKey> nestedPropsArray { get; set; }
        public Dictionary<string, NestedKey> NestedProps { get; set; } = new Dictionary<string, NestedKey>();
        public Dictionary<string, string> stringDictionary { get; set; }
        public Dictionary<string, object> keyValuePairs { get; set; }
        /// <summary>
        /// different article commment
        /// </summary>
        public Article Article { get; set; }
    }
    /// <summary>
    /// article comment
    /// </summary>
    public class Article
    {
        /// <summary>
        /// get or set article name
        /// </summary>
        public string name { get; set; }

        public string description { get; set; }

        public string url { get; set; }
        /// <summary>
        /// nested article type comment
        /// </summary>
        public ArticleType type { get; set; }
        public ArticleType2 type2 { get; set; }
        public UserDetails ModifiedBy { get; set; }
        public UserDetails CreatedBy { get; set; }
        public List<Article> articles { get; set; }
        public List<string> strings { get; set; }
        public List<int> ints { get; set; }
        public List<double> doubles { get; set; }
        public List<bool> bools { get; set; }
        public List<DateTime> dates { get; set; }
        public List<object> objects { get; set; }
    }
    /// <summary>
    /// enum article type
    /// </summary>
    public enum ArticleType
    {
        /// <summary>
        /// article value
        /// </summary>
        Article,
        BlogPost,
        Video,
        Other
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ArticleType2
    {
        /// <summary>
        ///  article value2
        /// </summary>
        Article,
        BlogPost,
        Video,
        Other
    }

    public class UserDetails
    {

        public string name { get; set; }

        public string email { get; set; }

        public List<Article> articles { get; set; }
    }


    /// <summary>
    /// brief description
    /// </summary>
    public class NestedKey
    {
        public string name { get; set; }

        public string value { get; set; }

        public string type { get; set; }

        public string description { get; set; }
    }
}