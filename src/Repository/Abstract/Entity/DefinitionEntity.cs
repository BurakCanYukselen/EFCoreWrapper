using Repository.Abstract.Entity.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Abstract.Entity
{
    public abstract class DefinitionEntity : AuditableEntity, IDefinitionEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
