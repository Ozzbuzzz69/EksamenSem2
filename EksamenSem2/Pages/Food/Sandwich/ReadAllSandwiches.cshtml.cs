using EksamenProjekt2Sem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EksamenProjekt2Sem.Pages.Food.Sandwich
{
    public class ReadAllSandwichesModel : PageModel
    {
        private SandwichService _sandwichService;

        public ReadAllSandwichesModel(SandwichService sandwichService)
        {
            _sandwichService = sandwichService;
        }

        public List<Models.Sandwich>? Sandwiches { get; private set; }

        public void OnGet()
        {
            Sandwiches = _sandwichService.ReadAllSandwiches();
        }
    }
}
