using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EksamenProjekt2Sem.Pages.Order
{
    public class DeleteOrderModel : PageModel
    {
        private Services.OrderService _orderService;
        public DeleteOrderModel(Services.OrderService orderService)
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
                RedirectToPage("./Index");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            Models.Order deletedOrder = _orderService.DeleteOrder(Order.Id);
            if (deletedOrder == null)
            {
                // Handle not found case
                RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }
    }
}
