using gesteventos.Domain.Models;
using gesteventos.Persistence.Database;
using gesteventos.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace gesteventos.Persistence.Implementations
{
    public class PersistenceImplemetations : IPersistenceContract
    {
        private readonly GestEvetosDbContext dbContext;

        public PersistenceImplemetations(GestEvetosDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add<T>(T entity) where T : class
        {
            this.dbContext.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            this.dbContext.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            this.dbContext.Remove(entity);
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
            this.dbContext.RemoveRange(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await this.dbContext.SaveChangesAsync()) > 0;
        }
    }
}