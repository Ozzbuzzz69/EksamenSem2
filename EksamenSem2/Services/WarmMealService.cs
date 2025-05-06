using EksamenProjekt2Sem.Models;

namespace EksamenProjekt2Sem.Services
{
    public class WarmMealService : GenericDbService<WarmMeal>
    {
        private List<WarmMeal> _warmMeals;

        private GenericDbService<WarmMeal> _dbService;

        public WarmMealService(GenericDbService<WarmMeal> dbService)
        {
            _dbService = dbService;
            _warmMeals = _dbService.GetObjectsAsync().Result.ToList();
            _dbService.SaveObjects(_warmMeals);
        }

        /// <summary>
        /// Creates the warm meal from argument.
        /// </summary>
        /// <param name="warmMeal"></param>
        public void CreateWarmMeal(WarmMeal warmMeal)
        {
            _warmMeals.Add(warmMeal);
            _dbService.AddObjectAsync(warmMeal);
        }

        /// <summary>
        /// Reads the warm meal with same id as argument.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Returns the matching warm meal.
        /// </returns>
        public WarmMeal ReadWarmMeal(int id)
        {
            return _warmMeals.Find(w => w.Id == id);
        }

        /// <summary>
        /// Reads all warm meals.
        /// </summary>
        /// <returns>
        /// Returns the list of warm meals.
        /// </returns>
        public List<WarmMeal> ReadAllWarmMeals()
        {
            return _warmMeals;
        }

        /// <summary>
        /// Updates the warm meal's properties to the same as the warm meal given in argument.
        /// </summary>
        /// <param name="warmMeal"></param>
        public void UpdateWarmMeal(WarmMeal warmMeal)
        {
            if (warmMeal != null)
            {
                foreach (WarmMeal w in _warmMeals)
                {
                    if (w.Id == warmMeal.Id)
                    {
                        w.Ingredients = warmMeal.Ingredients;
                        w.InSeason = warmMeal.InSeason;
                        w.MeatType = warmMeal.MeatType;
                        w.Price = warmMeal.Price;
                        w.MinPersonAmount = warmMeal.MinPersonAmount;
                    }
                }
                _dbService.SaveObjects(_warmMeals);
            }
        }

        /// <summary>
        /// Deletes the warm meal with same id as in argument.
        /// </summary>
        /// <param name="id"></param>
        public WarmMeal DeleteWarmMeal(int? id)
        {
            WarmMeal warmMealToBeDeleted = null;

            foreach (WarmMeal warmMeal in _warmMeals)
            {
                if (warmMeal.Id == id)
                {
                    warmMealToBeDeleted = warmMeal;
                    break;
                } 
            }

            if (warmMealToBeDeleted != null)
            {
                _warmMeals.Remove(warmMealToBeDeleted);
                _dbService.SaveObjects(_warmMeals);
            }
            return warmMealToBeDeleted;
        }

        /// <summary>
        /// Filters warm meals by criteria given in argument.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns>
        /// Returns all matching warm meals.
        /// </returns>
        public List<WarmMeal> FilterWarmMealByCriteria(string criteria)
        {
            return _warmMeals.FindAll(w => w.Ingredients.Contains(criteria));
        }

        /// <summary>
        /// // mangler
        /// </summary>
        /// <param name = "warmMeal" ></ param >
        /// < param name="offerPrice"></param>
        /// <param name = "dateFrom" ></ param >
        /// < param name="dateTo"></param>
        //public void WarmMealSpecialOffer(WarmMeal warmMeal, double offerPrice, DateTime dateFrom, DateTime dateTo)
        //{
        //    // mangler
        //}
    }
}