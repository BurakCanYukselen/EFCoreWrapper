using EFCoreWrapper.Abstract.Entity.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreWrapper.Abstract.Entity
{
    public abstract class DefinitionEntity : AuditableEntity, IDefinitionEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
