using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EksamenProjekt2Sem.Pages.User
{
    public class ReadAllUsersModel : PageModel
    {
        private Services.UserService _userService;
        public ReadAllUsersModel(Services.UserService userService)
        {
            _userService = userService;
        }
        public List<Models.User> Users { get; set; }
        [BindProperty]
        public string SearchString { get; set; }
        // Other search criteria properties can be added here:
        //

        public void OnGet()
        {
            // Get all users
            Users = _userService.ReadAllUsers();
            if (Users == null)
            {
                // Handle not found case
                RedirectToPage("./Index");
            }
        }
        // Other onget methods such as sorting order can be added here:
        //

        public IActionResult OnPost()
        {
            // Handle search input
            if (!string.IsNullOrEmpty(SearchString))
            {
                Users = _userService.ReadAllUsers().ToList();
            }
            return Page();
        }
        // Other onpost methods such as filtering can be added here:
        //

    }
}
