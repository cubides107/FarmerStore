using Microsoft.EntityFrameworkCore;

namespace FarmerStore.Data
{
    public class FarmerStoreContext : DbContext
    {

        public FarmerStoreContext(DbContextOptions<FarmerStoreContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Nombre del squema
            modelBuilder.HasDefaultSchema("FarmerStore");
        }
    }
}
