using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EksamenProjekt2Sem.Pages.User
{
    public class DeleteUserModel : PageModel
    {
        private Services.UserService _userService;
        public DeleteUserModel(Services.UserService userService)
        {
            _userService = userService;
        }
        [BindProperty]
        public Models.User User { get; set; }
        public IActionResult OnGet(int id)
        {
            // Get the user by id
            User = _userService.ReadUser(id);
            if (User == null)
            {
                // Handle not found case
                return NotFound();
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            Models.User deletedUser = _userService.DeleteUser(User.Id);
            if (!ModelState.IsValid)
            {
                // Handle invalid model state
                RedirectToPage("./Index");
            }
            
            return RedirectToPage("./Index");
        }
    }
}
