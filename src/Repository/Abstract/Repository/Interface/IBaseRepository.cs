using EFCoreWrapper.Response;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreWrapper.Abstract.EFCoreWrapper.Interface
{
    public interface IBaseRepository<Entity>
        where Entity : class, new()
    {
        Task<Entity> GetEntity(Expression<Func<Entity, bool>> filter);
        Task<Entity> GetEntityIncluding(Expression<Func<Entity, bool>> filter, params Expression<Func<Entity, object>>[] properties);
        Task<IList<Entity>> GetList(Expression<Func<Entity, bool>> filter = null, bool IsIncludedNavigationProperties = false);
        Task<DBResponseModel> Add(Entity entity);
        Task<DBResponseModel> Remove(Entity entity);
        Task<DBResponseModel> Update(Entity entity);
        Task<DBResponseModel> UpdateProperties(Entity entity, ICollection<Expression<Func<Entity, object>>> properties);
        Task<DBResponseModel> UpdateProperties(Entity entity, params Expression<Func<Entity, object>>[] properties);
    }
}
