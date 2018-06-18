using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _180528.Api
{
    public class HackerNewsRepository
    {
        public List<Story> GetTwentyTopStories()
        {      
            var client = new WebClient(); 
            string json = client.DownloadString("https://hacker-news.firebaseio.com/v0/topstories.json?print=pretty");
            List<int> ids = JsonConvert.DeserializeObject<List<int>>(json).Take(20).ToList(); 

            List<Story> stories = new List<Story>();
            foreach (int id in ids)
            {       
                string storyjson = client.DownloadString($"https://hacker-news.firebaseio.com/v0/item/{id}.json?print=pretty");
                stories.Add(JsonConvert.DeserializeObject<Story>(storyjson));  
            }
            return stories;   
        }
    }
}
