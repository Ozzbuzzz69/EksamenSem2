using EksamenProjekt2Sem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EksamenProjekt2Sem.Pages.Food.WarmMeal
{
    public class CreateWarmMealModel : PageModel
    {
        private WarmMealService _warmMealService;

        public CreateWarmMealModel(WarmMealService warmMealService)
        {
            _warmMealService = warmMealService;
        }

        [BindProperty]
        public Models.WarmMeal WarmMeal { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _warmMealService.CreateWarmMeal(WarmMeal);
            return RedirectToPage("ReadAllWarmMeals");
        }
    }
}
