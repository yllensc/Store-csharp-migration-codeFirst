using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
  public class GenericRepository<T> : IGenericDemo<T> where T : BaseEntity
  {
    private readonly StoreContext _context;
  
    public GenericRepository(StoreContext context)
    {
        _context = context;
    }
  
    public virtual void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }
  
    public virtual void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }
  
    public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }


        public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
  
    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }
  
    public virtual Task<T> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }
  
    public virtual void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
  
    public virtual void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }
  
    public virtual void Update(T entity)
    {
        _context.Set<T>()
            .Update(entity);
    }
  }
}