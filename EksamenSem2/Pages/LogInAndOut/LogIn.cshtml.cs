using EksamenProjekt2Sem.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using EksamenProjekt2Sem.Models;
using EksamenProjekt2Sem.Services;

namespace EksamenProjekt2Sem.Pages.LogInAndOut
{
    public class LogInPageModel : PageModel
    {
        private UserService _userService;


        [BindProperty]
        public string Email { get; set; }
        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }
        public string Message { get; set; }

        public LogInPageModel(UserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {

            List<Models.User> users = _userService._users;
            foreach (Models.User user in users)
            {

                if (Email == user.Email)
                {
                    var passwordHasher = new PasswordHasher<string>();
                    if (passwordHasher.VerifyHashedPassword(null, user.Password, Password) == PasswordVerificationResult.Success)
                    {


                        var claims = new List<Claim> { new Claim(ClaimTypes.Name, Email) };

                        if (Email == "admin@admin.com") claims.Add(new Claim(ClaimTypes.Role, "admin"));
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                        return RedirectToPage("/Index");
                    }
                }

            }

            Message = "Invalid attempt";
            return Page();
        }
    }
}
