using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace GameGround.ViewModel
{

    public class VmGameInfo
    {
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("rule")]
        public string Rule { get; set; }
        [JsonProperty("category")]
        public GameCategory Category { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("authorId")]
        public long? AuthorId { get; set; }
    }

    public class VmGame : VmGameInfo
    {
        [JsonProperty("collecttingPlayers")]
        public long CollecttingPlayers { get; set; }
        
    }
    
    public class VmHeartGame : VmGameInfo
    {
        [JsonProperty("hearttingPlayers")]
        public long HearttingPlayers { get; set; }
    }
    
    public class VmGameSearch
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
    }
}
