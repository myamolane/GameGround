using FluentValidation.Attributes;
using GameGround.ViewModel.Validator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGround.ViewModel
{
    [Validator(typeof(LoginValidator<VmLogin>))]
    public class VmLogin
    {
        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
    public class VmAccount : VmPlayer
    {
        [JsonProperty("login")]
        public string Login { get; set; }
    }
    [Validator(typeof(RegistryValidator<VmRegistry>))]
    public class VmRegistry : VmAccount
    {
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("checkPassword")]
        public string CheckPassword { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }

    }
}
