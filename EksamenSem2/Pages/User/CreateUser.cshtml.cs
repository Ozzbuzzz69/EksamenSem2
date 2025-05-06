using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EksamenProjekt2Sem.Pages.User
{
    public class CreateUserModel : PageModel
    {
        private Services.UserService _userService;
        public CreateUserModel(Services.UserService userService)
        {
            _userService = userService;
        }
        [BindProperty]
        public Models.User User { get; set; }
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
            _userService.CreateUser(User);
            return RedirectToPage("./Index");
        }
    }
}
