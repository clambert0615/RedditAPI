using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedditAPILab.Models
{
   public class RedditPost
    {
        public string title { get; set; }

        //This is for the image
        public string url { get; set; }

        public string permalink { get; set; }

    }
}
