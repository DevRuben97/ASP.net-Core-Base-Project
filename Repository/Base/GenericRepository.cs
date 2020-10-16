using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IAuditableEntity
    {
        protected AppDbContext _Dbcontext;

        public GenericRepository(AppDbContext dbContext)
        {
            this._Dbcontext = dbContext;
        }
        public async Task<IEnumerable<T>> All()
        {
            return await this._Dbcontext.Set<T>().ToListAsync();
        }

        public async Task CreateOne(T Item)
        {
            await this._Dbcontext.Set<T>().AddAsync(Item);
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> filter)
        {
            return await this._Dbcontext.Set<T>().Where(filter).ToListAsync();
        }

        public async Task Update(T item)
        {
            item.ModifierDate = DateTime.Now;
            this._Dbcontext.Set<T>().Update(item);

            await Task.CompletedTask; 
        }
    }
}
