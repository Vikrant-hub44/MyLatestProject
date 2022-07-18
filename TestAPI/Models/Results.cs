using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Models
{
    public class Results
    {
        public Results() 
        {
            Tags = new List<Tags>();
        }
        public List<Tags> Tags { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("posts")]
        public Post[] Posts { get; set; }
    }

    public partial class Post
    {
        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("authorId")]
        public long AuthorId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("likes")]
        public long Likes { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("reads")]
        public long Reads { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}
