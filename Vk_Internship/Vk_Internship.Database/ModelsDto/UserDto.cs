using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vk_Internship.Database.Models;

namespace Vk_Internship.Database.ModelsDto
{
    [JsonObject]
    public class UserDto
    {
        [JsonProperty("Login")]
        public string Login { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("Created_Date")]
        public DateTime Created_Date { get; set; }

        [JsonProperty("Code_group")]
        public string Code_group { get; set; }

        [JsonProperty("GroupDescription")]
        public string GroupDescription { get; set; }

        [JsonProperty("Code_state")]
        public string Code_state { get; set; }

        [JsonProperty("StateDescription")]
        public string StateDescription { get; set; }
    }
}
