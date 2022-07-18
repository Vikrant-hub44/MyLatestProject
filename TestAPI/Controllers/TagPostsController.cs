using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TestAPI.Models;
using System.Linq.Dynamic;
namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagPostsController : ControllerBase
    {
        [Route("GetTagPosts")]
        [HttpGet]
        public async Task<JsonResult> GetTagPosts(string tags, string sortBy = "id", string direction = "asc")
        {
            if (string.IsNullOrEmpty(tags)) 
            {
                return new JsonResult(new { Data = "null", error = "tags parameter is required", code = 400 });
            }

            List<Post> results = new List<Post>();
            var tagList = tags.Split(",").Distinct();
            
            HttpClient client = new HttpClient();
            
            foreach (var tag in tagList)
            {
                HttpResponseMessage response = await client.GetAsync("https://api.assessment.skillset.technology/a74fsg46d/posts?tag="+ tag);
                if (response.IsSuccessStatusCode)
                {
                    Result posts = new Result();
                    var data = await response.Content.ReadAsStringAsync();
                    posts = JsonConvert.DeserializeObject<Result>(data);
                    //posts.Posts = posts.Posts.OrderBy(sortBy + " " + direction).ToArray();
                    results.AddRange(posts.Posts);
                }
            }
            return new JsonResult(new { Data = SortedData(results, sortBy, direction), error = "", code = 200 });
        }

        private List<Post> SortedData(List<Post> posts, string sortBy, string direction)
        {
            bool dire = direction == "asc" ? false : true;
            switch (sortBy)
            {
                case "id":
                    if (dire)
                    {
                        posts = posts.OrderByDescending(x => x.Id).ToList();
                    }
                    else
                    {
                        posts = posts.OrderBy(x => x.Id).ToList();
                    }
                    break;
                case "author":
                    if (dire)
                    {
                        posts = posts.OrderByDescending(x => x.Author).ToList();
                    }
                    else
                    {
                        posts = posts.OrderBy(x => x.Author).ToList();
                    }
                    break;
                    
            }
            return posts;
        }
    }
}
