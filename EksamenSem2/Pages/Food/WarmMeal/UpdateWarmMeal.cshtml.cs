using EksamenProjekt2Sem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EksamenProjekt2Sem.Pages.Food.WarmMeal
{
    public class UpdateWarmMealModel : PageModel
    {
        private WarmMealService _warmMealService;

        public UpdateWarmMealModel(WarmMealService warmMealService)
        {
            _warmMealService = warmMealService;
        }

        [BindProperty]
        public Models.WarmMeal WarmMeal { get; set; }

        public IActionResult OnGet(int id)
        {
            WarmMeal = _warmMealService.ReadWarmMeal(id);
            if (WarmMeal == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _warmMealService.UpdateWarmMeal(WarmMeal);
            return RedirectToPage("ReadAllWarmMeals");
        }
    }
}
