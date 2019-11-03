using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Abstract.Repository.Interface;
using Repository.Context;
using Repository.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract.Repository
{
    public abstract class BaseRepository<DBContext, Entity>: IBaseRepository<Entity>
        where DBContext : DbContext
        where Entity : class, new()
    {
        private readonly DBContext _context;
        public BaseRepository(DBContext context)
        {
            this._context = context;
        }

        public async Task<Entity> GetEntity(Expression<Func<Entity, bool>> filter)
        {
            return await _context.Set<Entity>().AsNoTracking().FirstOrDefaultAsync(filter);
        }
        public async Task<Entity> GetEntityIncluding(Expression<Func<Entity, bool>> filter, params Expression<Func<Entity, object>>[] properties)
        {
            var entities = _context.Set<Entity>().AsNoTracking();
            entities = properties.Aggregate(entities, (current, includeProperty) => current.Include(includeProperty));
            return await entities.FirstOrDefaultAsync(filter);
        }
        public async Task<IList<Entity>> GetList(Expression<Func<Entity, bool>> filter = null, bool IsIncludedNavigationProperties = false)
        {
            var query = _context.Set<Entity>().AsNoTracking();

            if (IsIncludedNavigationProperties)
                foreach (var item in _context.Model.FindEntityType(typeof(Entity)).GetNavigations())
                    query = query.Include(item.Name);

            if (filter == null)
                return await query.ToListAsync();
            else
                return await query.Where(filter).ToListAsync();
        }
               
        public async Task<DBResponseModel> Add(Entity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            return await SaveChanges();
        }
        public async Task<DBResponseModel> Remove(Entity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            return await SaveChanges();
        }
        public async Task<DBResponseModel> Update(Entity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await SaveChanges();
        }
        public async Task<DBResponseModel> UpdateProperties(Entity entity, ICollection<Expression<Func<Entity, object>>> properties)
        {
            _context.Set<Entity>().Attach(entity);
            var entityToUpdate = _context.Entry(entity);
            foreach (var property in properties)
            {
                entityToUpdate.Property(property).IsModified = true;
                await _context.SaveChangesAsync();
            }
            return await SaveChanges();
        }
        public async Task<DBResponseModel> UpdateProperties(Entity entity, params Expression<Func<Entity, object>>[] properties)
        {
            _context.Set<Entity>().Attach(entity);
            var entityToUpdate = _context.Entry(entity);
            foreach (var property in properties)
            {
                entityToUpdate.Property(property).IsModified = true;
                await _context.SaveChangesAsync();
            }
            return await SaveChanges();
        }

        private async Task<DBResponseModel> SaveChanges()
        {
            try
            {
                await _context.SaveChangesAsync();
                return new DBResponseModel() { IsSucces = true };
            }
            catch (Exception exception)
            {
                var sb = new StringBuilder();
                sb.AppendLine(exception.Message);
                sb.AppendLine(exception.InnerException.Message);
                return new DBResponseModel()
                {
                    IsSucces = false,
                    ErrorMessage = sb.ToString()
                };
            }
        }
    }
}
