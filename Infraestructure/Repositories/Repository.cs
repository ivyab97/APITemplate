using Application.DTO.Pagination;
using Application.Interfaces;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        internal DbSet<T> dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }
        public async Task<T> Insert(T entity)
        {
            await dbSet.AddAsync(entity);
            await SaveChanges();
            return entity;
        }

        public async Task<Paged<T>> RecoveryAll(Parameters parameters)
        {
            //return await dbSet.ToListAsync();
            return Paged<T>.ToPaged(dbSet, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<T> RecoveryById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task Remove(T entity)
        {
            dbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
