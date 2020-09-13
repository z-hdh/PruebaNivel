using System;
using Prueba.Domain.DbHelper;

namespace Prueba.Domain.Entities
{
    public class Product : AuditEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime ExpiryDate { get; set; }

        public bool Delete { get; set; }
    }
}
