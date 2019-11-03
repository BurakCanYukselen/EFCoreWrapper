using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreWrapper.Abstract.Entity.Interface
{
    public interface IAuditableEntity
    {
        DateTimeOffset CreatedAt { get; set; }
        DateTimeOffset UpdatedAt { get; set; }
    }
}
