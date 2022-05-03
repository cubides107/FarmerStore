using FarmerStore.Data;
using FarmerStore.Models.Entities;
using System.Linq.Expressions;

namespace FarmerStore.Models.Repositories
{
    public class FarmerStoreSQL : IRepository
    {
        protected readonly FarmerStoreContext context;

        public FarmerStoreSQL(FarmerStoreContext context)
        {
            this.context = context;
        }

        public async Task Commit()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }

        public bool Exists<T>(Expression<Func<T, bool>> expression) where T : Entity
        {
            try
            {
                return context.Set<T>()
                    .AsQueryable()
                    .Any(expression);
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }

        public async Task Save<T>(T obj) where T : Entity
        {
            try
            {
                await context.Set<T>().AddAsync(obj);
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }

        public void Update<T>(T obj) where T : Entity
        {
            try
            {
                context.Update<T>(obj);
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }
    }
}
