using EksamenProjekt2Sem.Models;
using Microsoft.EntityFrameworkCore;

namespace EksamenProjektTest.EFDbContext
{
    public class FoodContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FoodContentDB; Integrated Security=True; Connect Timeout=30; Encrypt=False");
        }
        public DbSet<CampaignOffer> CampaignOffers { get; set; }
        public DbSet<Sandwich> Sandwiches { get; set; }
        public DbSet<WarmMeal> WarmMeals { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
