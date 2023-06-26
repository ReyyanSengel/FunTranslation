using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FunTranslation.Application.Dtos
{
    public class ErrorDto
    {
        [JsonProperty("error")]
        public Error Error { get; set; }
    }
    public class Error
    { 
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
