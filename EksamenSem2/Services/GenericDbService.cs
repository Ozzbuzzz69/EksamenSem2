using EksamenProjektTest.EFDbContext;
using Microsoft.EntityFrameworkCore;
namespace EksamenProjekt2Sem.Services
{
    public class GenericDbService<T> where T : class
    {
        public async Task<IEnumerable<T>> GetObjectsAsync()
        {
            using (var context = new FoodContext())
            {
                return await context.Set<T>().AsNoTracking().ToListAsync();
            }
        }
        public async Task AddObjectAsync(T obj)
        {
            using (var context = new FoodContext())
            {
                context.Set<T>().Add(obj);
                await context.SaveChangesAsync();
            }
        }
        public async Task SaveObjects(List<T> objs)
        {
            using (var context = new FoodContext())
            {
                foreach (T obj in objs)
                {
                    context.Set<T>().Add(obj);
                    context.SaveChanges();
                }

                context.SaveChanges();
            }
        }
        public async Task DeleteObjectAsync(T obj)
        {
            using (var context = new FoodContext())
            {
                context.Set<T>().Remove(obj);
                await context.SaveChangesAsync();
            }
        }
        public async Task UpdateObjectAsync(T obj)
        {
            using (var context = new FoodContext())
            {
                context.Set<T>().Update(obj);
                await context.SaveChangesAsync();
            }
        }
        public async Task<T> GetObjectByIdAsync(int id)
        {
            using (var context = new FoodContext())
            {
                return await context.Set<T>().FindAsync(id);
            }
        }


    }
}
