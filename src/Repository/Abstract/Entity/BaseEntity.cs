using EFCoreWrapper.Abstract.Entity.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreWrapper.Abstract.Entity
{
    public abstract class BaseEntity : IConsistentEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
