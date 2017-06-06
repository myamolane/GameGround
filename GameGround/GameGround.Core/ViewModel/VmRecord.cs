using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace GameGround.Core.ViewModel
{
    public class VmRecord
    {
        [JsonProperty("player")]
        public string Player { get; set; }
        [JsonProperty("game")]
        public string Game { get; set; }
        [JsonProperty("score")]
        public long Score { get; set; }
        [JsonProperty("result")]
        public GameResult Result { get; set; }
    }
}
