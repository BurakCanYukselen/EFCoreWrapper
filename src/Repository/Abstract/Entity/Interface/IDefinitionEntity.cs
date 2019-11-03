using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Abstract.Entity.Interface
{
    public interface IDefinitionEntity
    {
        string Key { get; set; }
        string Value { get; set; }
    }
}
