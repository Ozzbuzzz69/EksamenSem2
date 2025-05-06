using EksamenProjekt2Sem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EksamenProjekt2Sem.Pages.Food.Sandwich
{
    public class UpdateSandwichModel : PageModel
    {
        private SandwichService _sandwichService;

        public UpdateSandwichModel(SandwichService sandwichService)
        {
            _sandwichService = sandwichService;
        }

        [BindProperty]
        public Models.Sandwich Sandwich { get; set; }

        public IActionResult OnGet(int id)
        {
            Sandwich = _sandwichService.ReadSandwich(id);
            if (Sandwich == null)
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
            _sandwichService.UpdateSandwich(Sandwich);
            return RedirectToPage("ReadAllSandwiches");
        }
    }
}
