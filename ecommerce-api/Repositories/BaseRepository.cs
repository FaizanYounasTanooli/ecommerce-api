using ecommerce_api.Models;
using ecommerce_api.Services;
using Microsoft.EntityFrameworkCore;
using PosCommon.Repositories.Interfaces;
using System.Linq.Expressions;

namespace ecommerce_api.Repositories
{
    //I created a base repository to have basic functions already included in all repositories
    public class BaseRepository<Model> : IBaseRepository<Model> where Model : BaseEntity
    {
        protected readonly EcommeranceContext _context;
        protected readonly DbSet<Model> _dbSet;
        protected readonly UserService _userService;

        IQueryable<Model> BaseQuery;
        public BaseRepository(EcommeranceContext context,UserService userService)
        {
            _context = context;
            _userService = userService;
            _dbSet = _context.Set<Model>();
            BaseQuery = _dbSet.Where(y => !y.Deleted && y.Active);

        }

        public IQueryable<Model> GetAll()
        {
            return BaseQuery.AsQueryable();
        }

        public  Guid Add(Model entity)
        {
            entity.User = _userService.LoggedInUser;
            _dbSet.Add(entity);
            return entity.Id;
        }

        public bool Delete(Model entity)
        {
            entity.Deleted = true;
            _dbSet.Update(entity);
            return true;
        }
        public  bool DeleteById(Guid id)
        {
            var entityToDel = _dbSet.Find(id);
            Delete(entityToDel);
            return true;
            
        }
        public Model First(Expression<Func<Model, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }
        public Model UsersFirst(Expression<Func<Model, bool>>? predicate = null)
        {
            var query = _dbSet.Where(data => data.userId == _userService.LoggedInUser.Id);

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.FirstOrDefault();
        }
        public bool Any(Expression<Func<Model, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }
    }
}
