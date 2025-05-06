using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EksamenProjekt2Sem.Pages.Order
{
    public class CreateOrderModel : PageModel
    {
        private Services.OrderService _orderService;
        public CreateOrderModel(Services.OrderService orderService)
        {
            _orderService = orderService;
        }
        [BindProperty]
        public Models.Order Order { get; set; }
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
            _orderService.CreateOrder(Order);
            return RedirectToPage("./Index");
        }
    }
}
