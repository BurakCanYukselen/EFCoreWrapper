using Repository.Abstract.Entity.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Abstract.Entity
{
    public abstract class AuditableEntity : BaseEntity, IAuditableEntity
    {
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
