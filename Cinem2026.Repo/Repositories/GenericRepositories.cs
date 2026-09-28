using Cinema2026.Repo.Data;
using Cinema2026.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cinema2026.Repo.Repositories
{
    public class GenericRepositories<T> : IGenericRepositories<T>
        where T : class
    {
        private readonly DatabaseContext context;
        private readonly DbSet<T> table;

        public GenericRepositories(DatabaseContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }

        public async Task<List<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task<T> Create(T entity)
        {
            await table.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Update(T entity)
        {
            table.Update(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            T? entity = await table.FindAsync(id);

            if (entity == null)
            {
                return false;
            }

            table.Remove(entity);
            await context.SaveChangesAsync();

            return true;
        }
    }
}