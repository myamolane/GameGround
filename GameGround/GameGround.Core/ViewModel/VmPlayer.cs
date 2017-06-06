using FluentValidation.Attributes;
using GameGround.ViewModel.Validator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace GameGround.ViewModel
{
    [Validator(typeof(PlayerValidator<VmPlayer>))]
    public class VmPlayer
    {
        [JsonProperty("id")]
        public long? Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("sex")]
        public Sex Sex { get; set; }
        [JsonProperty("birth")]
        public String Birth { get; set; }
        
    }
}
