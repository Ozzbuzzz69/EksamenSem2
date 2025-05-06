using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EksamenProjekt2Sem.Pages.Order
{
    public class UpdateOrderModel : PageModel
    {
        private Services.OrderService _orderService;
        public UpdateOrderModel(Services.OrderService orderService)
        {
            _orderService = orderService;
        }
        [BindProperty]
        public Models.Order Order { get; set; }
        public IActionResult OnGet(int id)
        {
            // Get the order by id
            Order = _orderService.ReadOrder(id);
            if (Order == null)
            {
                // Handle not found case
                RedirectToPage("./Index"); // Redirect to the index page if order not found
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _orderService.UpdateOrder(Order.Id, Order);
            return RedirectToPage("./Index"); // Redirect to the index page after updating
        }
    }
}
