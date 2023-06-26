using FunTranslation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Application.ViewModels
{
    public class PastTextViewModel
    {
        public PastTextViewModel()
        {
            this.PastTranslations = new List<PastText>();
        }
        public List<PastText> PastTranslations { get; set; }
        public string UserId { get; set; }
        public string LanguageId { get; set; }
    }
}
