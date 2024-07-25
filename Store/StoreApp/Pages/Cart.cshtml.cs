using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;

        public CartModel(IServiceManager manager)
        {
            _manager = manager;
        }

        public Cart Cart { get; set; } // IoC

        public String ReturnUrl { get; set; } = "/";
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = _manager.ProductService.GetOneProduct(productId, false);
            if (product is not null)
            {
                Cart.AddItem(product, 1);
            }
            return Page();
        }

        public IActionResult OnPostRemove(int productId, string returnUrl)
        {
            Product? product = Cart.Lines.First(cartLine => cartLine.Product.ProductId.Equals(productId)).Product;
            if (product is not null)
            {
                Cart.RemoveLine(product);
            }
            return Page();
        }
    }
}