using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Application.Dtos
{
    public class TranslationDto
    {
        [JsonProperty("success")]
        public Success Success { get; set; }

        [JsonProperty("contents")]
        public Contents Contents { get; set; }
       
    }
    public class Success
    {
        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class Contents
    {
        [NotMapped]
        public int LanguageId { get; set; }

        [JsonProperty("translation")]
        public string LanguageName { get; set; }

        [JsonProperty("text")]
        public string MainText { get; set; }

        [JsonProperty("translated")]
        public string TranslateText { get; set; }
    }

}
