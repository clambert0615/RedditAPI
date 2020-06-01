using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RedditAPILab.Models
{
    public class RedditDal
    {
        public string GetAPIJson(string subreddit)
        {
            string url = $"https://www.reddit.com/r/{subreddit}/.json";
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Convert the response into something useable 
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string output = sr.ReadToEnd();
            return output;

        }
        public string GetAPIJson()
        {
            string url = $"https://www.reddit.com/r/aww/.json";
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Convert the response into something useable 
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string output = sr.ReadToEnd();
            return output;

        }
        public RedditPost GetPost()
        {
            string output = GetAPIJson("aww");
            JObject json = JObject.Parse(output);
            List<JToken> modelData = json["data"]["children"].ToList();
            string s = modelData[0]["data"].ToString();
             RedditPost rp = JsonConvert.DeserializeObject<RedditPost>(modelData[1]["data"].ToString());
           

            return rp;
        }

        public Post GetInfo()
        {
            string data = GetAPIJson();
            Post p = JsonConvert.DeserializeObject<Post>(data);
            return p;
        }

    }
}
