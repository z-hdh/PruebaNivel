using System;
using System.Collections.Generic;
using System.Text;

namespace Prueba.Domain.DbHelper
{
    public class AuditEntity
    {
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }

        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }

        public DateTime? DeleteAt { get; set; }
        public string DeleteBy { get; set; }
    }
}
