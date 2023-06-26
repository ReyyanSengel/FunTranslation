using FunTranslation.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Domain.Entities
{
    public class PastText : BaseEntity
    {
        public string MainText { get; set; }
        public string TranslateText { get; set; }
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
    }
}
