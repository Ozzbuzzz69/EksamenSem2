using EksamenProjekt2Sem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EksamenProjekt2Sem.Pages.Food.WarmMeal
{
    public class DeleteWarmMealModel : PageModel
    {
        private WarmMealService _warmMealService;

        public DeleteWarmMealModel(WarmMealService warmMealService)
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
            Models.WarmMeal deletedWarmMeal = _warmMealService.DeleteWarmMeal(WarmMeal.Id);
            if (deletedWarmMeal == null)
            {
                return RedirectToPage("/NotFound");
            }
            return RedirectToPage("ReadAllWarmMeals");
        }
    }
}
