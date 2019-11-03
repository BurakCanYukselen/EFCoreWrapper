using EFCoreWrapper.Abstract.Entity.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreWrapper.Abstract.Entity
{
    public abstract class AuditableEntity : BaseEntity, IAuditableEntity
    {
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
