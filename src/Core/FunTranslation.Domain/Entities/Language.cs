using FunTranslation.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Domain.Entities
{
    public class Language : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<PastText> Texts { get; set; }
    }
}
