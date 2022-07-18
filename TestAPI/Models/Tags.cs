using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Models
{
    public class Tags
    {
        public Tags() {
            TagList = new List<string>();
        }
        public long Id { get; set; }
        public string author { get; set; }
        public long AuthorId { get; set; }
        public int Likes { get; set; }
        public double Popularity { get; set; } 
        public int Reads { get; set; }
        public List<string> TagList { get; set; }
    }
}
