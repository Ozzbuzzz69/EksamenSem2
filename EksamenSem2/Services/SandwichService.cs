using EksamenProjekt2Sem.Models;

namespace EksamenProjekt2Sem.Services
{
    public class SandwichService : GenericDbService<Sandwich>
    {
        private List<Sandwich> _sandwiches;

        private GenericDbService<Sandwich> _dbService;

        public SandwichService(GenericDbService<Sandwich> dbService)
        {
            _dbService = dbService;
            _sandwiches = _dbService.GetObjectsAsync().Result.ToList();
            _dbService.SaveObjects(_sandwiches);
        }

        /// <summary>
        /// Creates the sandwich from the argument.
        /// </summary>
        /// <param name="sandwich"></param>
        public void CreateFood(Sandwich sandwich)
        {
            _sandwiches.Add(sandwich);
            _dbService.AddObjectAsync(sandwich);
        }

        /// <summary>
        /// Finds the sandwich with same id as in argument.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// A sandwich with matching id.
        /// </returns>
        public Sandwich ReadSandwich(int id)
        {
            return _sandwiches.Find(s => s.Id == id);
        }

        /// <summary>
        /// Reads all sandwiches.
        /// </summary>
        /// <returns>
        /// Returns the list of sandwiches.
        /// </returns>
        public List<Sandwich> ReadAllSandwiches()
        {
            return _sandwiches;
        }

        /// <summary>
        /// Updates the sandwiches properties, so it matches the sandwich in the argument.
        /// </summary>
        /// <param name="sandwich"></param>
        public void UpdateSandwich(Sandwich sandwich)
        {
            if (sandwich != null)
            {
                foreach (Sandwich s in _sandwiches)
                {
                    if (s.Id == sandwich.Id)
                    {
                        s.Ingredients = sandwich.Ingredients;
                        s.InSeason = sandwich.InSeason;
                        s.MeatType = sandwich.MeatType;
                        s.Price = sandwich.Price;
                    }
                }
                _dbService.SaveObjects(_sandwiches);
            }
        }

        /// <summary>
        /// Deletes the sandwich with the same id as given in argument.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Returns the sandwich to be deleted.
        /// </returns>
        public Sandwich DeleteSandwich(int? id)
        {
            Sandwich sandwichToBeDeleted = null;
            foreach (Sandwich sandwich in _sandwiches)
            {
                if (sandwich.Id == id)
                {
                    sandwichToBeDeleted = sandwich;
                    break;
                }
            }

            if (sandwichToBeDeleted != null)
            {
                _sandwiches.Remove(sandwichToBeDeleted);
                _dbService.SaveObjects(_sandwiches);
            }
            return sandwichToBeDeleted;
        }

        /// <summary>
        /// Filters sandwiches by specified category.
        /// </summary>
        /// <param name="category"></param>
        /// <returns>
        /// Returns a list of sandwiches with the category as given in argument.
        /// </returns>
        public List<Sandwich> FilterSandwichByCategory(string category)
        {
            return _sandwiches.FindAll(s => s.Category == category);
        }

        /// <summary>
        /// Filters food by given criteria.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns>
        /// Returns a list of sandwiches that matches the criteria.
        /// </returns>
        public List<Sandwich> FilterSandwichByCriteria(string criteria)
        {
            return _sandwiches.FindAll(s => s.Ingredients.Contains(criteria));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sandwich"></param>
        /// <param name="offerPrice"></param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        //public void SpecialSandwichOffer(Sandwich sandwich, double offerPrice, DateTime dateFrom, DateTime dateTo)
        //{
        //    var findSandwich = _sandwiches.FindAll(s => s.Category == sandwich.Category);

        //    double normalPrice = sandwich.Price;

        //    foreach (Sandwich sa in findSandwich)
        //    {
        //        sa.Price == offerPrice;
        //    }
        //}
    }
}