using EksamenProjekt2Sem.Models;

namespace EksamenProjekt2Sem.Services
{
    public class FoodService : GenericDbService<Food>
    {
        private List<Food> _sandwiches;

        private GenericDbService<Food> _dbService;

        public FoodService(GenericDbService<Food> dbService)
        {
            _dbService = dbService;

            _sandwiches = _dbService.GetObjectsAsync().Result.ToList();
            _dbService.SaveObjects(_sandwiches);
        }

        /// <summary>
        /// Adds the food object from argument to the database, and the _sandwiches list.
        /// </summary>
        /// <param name="food"></param>
        public void CreateFood(Food food)
        {
            _sandwiches.Add(food);
            _dbService.AddObjectAsync(food);
        }

        /// <summary>
        /// Reads the food object from the database by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Returns the food object from the database.
        /// </returns>
        public Food ReadFood(int id)
        {
            return _dbService.GetObjectByIdAsync(id).Result;
        }

        /// <summary>
        /// Reads all food objects from the database.
        /// </summary>
        /// <returns>
        /// A list of food objects from the database.
        /// </returns>
        public List<Food> ReadAllFood()
        {
            return _dbService.GetObjectsAsync().Result.ToList();
        }


        public void UpdateFood(Food food)
        {
            if (food != null)
            {
                foreach (Food f in _sandwiches)
                {

                }
            }
        }
        public Food DeleteFood(int id)
        {
            // Delete food from Database
            return new Sandwich(); // Placeholder return
        }

        //+ FilterFoodByType(string str) : List<Food>
        //+ SpecialOffer(Food food, double price, DateTime dateFrom, DateTime dateTo) : void  
        //+ FilterFoodByCriteria(?) : List<Food>
    }
}
