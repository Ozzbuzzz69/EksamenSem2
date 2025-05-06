using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EksamenProjekt2Sem.Pages.Order
{
    public class ReadAllOrdersModel : PageModel
    {
        private Services.OrderService _orderService;
        public ReadAllOrdersModel(Services.OrderService orderService)
        {
            _orderService = orderService;
        }
        public List<Models.Order> Orders { get; set; }
        [BindProperty]
        public string SearchString { get; set; }
        // Other search criteria properties can be added here:
        //

        public void OnGet()
        {
            // Get all orders
            Orders = _orderService.ReadAllOrders();
            if (Orders == null)
            {
                // Handle not found case
                RedirectToPage("./Index");
            }
        }
        public IActionResult OnPost()
        {
            // Handle search input
            if (!string.IsNullOrEmpty(SearchString))
            {
                Orders = _orderService.ReadAllOrders().ToList();
            }
            return Page();
        }
        // Other onpost methods such as filtering can be added here:
        //

    }
}
