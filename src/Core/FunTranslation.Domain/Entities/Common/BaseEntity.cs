using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Domain.Entities.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
