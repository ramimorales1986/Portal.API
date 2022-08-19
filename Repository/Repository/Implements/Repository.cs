using Microsoft.EntityFrameworkCore;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Implements
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }
        public async Task<TEntity> Get(int id) => await _context.Set<TEntity>().FindAsync(id);
        public IEnumerable<TEntity> GetAll() => _context.Set<TEntity>().ToList();
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) =>
            _context.Set<TEntity>().Where(predicate).ToList();
        public void Add(TEntity entity) => _context.Set<TEntity>().Add(entity);
        public void AddRange(IEnumerable<TEntity> entities) => _context.Set<TEntity>().AddRange(entities);
        public void Remove(TEntity entity) => _context.Set<TEntity>().Remove(entity);
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate) =>
            _context.Set<TEntity>().SingleOrDefault(predicate);
    }
}
