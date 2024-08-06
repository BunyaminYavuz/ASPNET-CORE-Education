using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities.Models;
using Services.Contracts;

namespace StoreApp.Pages
{
    public class CompleteModel : PageModel
    {
        private readonly IServiceManager _manager;

        public CompleteModel(IServiceManager manager)
        {
            _manager = manager;
        }

        [BindProperty(SupportsGet = true)]
        public Order? Order { get; set; }

        public IActionResult OnGet(int orderId)
        {
            Order = _manager.OrderService.GetOneOrder(orderId);
            if (Order == null)
            {
                return RedirectToPage("/Error");
            }
            return Page();
        }
    }
}
