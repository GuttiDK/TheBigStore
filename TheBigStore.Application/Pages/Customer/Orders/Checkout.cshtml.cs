using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Application.SessionHelper;

namespace TheBigStore.Application.Pages.Customer.Orders
{
    public class CheckoutModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please select a payment method")]
        public string PaymentMethod { get; set; }

        public List<ItemDto> Items { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Handler { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public CheckoutModel()
        {
        }

        // Get the products from the cart/session
        public void OnGet()
        {
            if(Handler == null)
            {
                Items = GetCart();
            }
            else if(Handler == "RemoveFromCart")
            {
                RemoveItemFromCart(Id);
                Items = GetCart();
            }
            else if(Handler == "IncreaseQuantity")
            {
                UpdateCartItemQuantity(Id, 1);
                Items = GetCart();
            }
            else if(Handler == "DecreaseQuantity")
            {
                UpdateCartItemQuantity(Id, -1);
                Items = GetCart();
            }
        }

        // Handle the increasing of the quantity of a product in the cart
        public IActionResult OnPostIncreaseQuantity(int id)
        {
            UpdateCartItemQuantity(id, 1);
            return RedirectToPage();
        }

        // Handle the decreasing of the quantity of a product in the cart
        public IActionResult OnPostDecreaseQuantity(int id)
        {
            UpdateCartItemQuantity(id, -1);
            return RedirectToPage();
        }

        // Handle the removal of a product from the cart
        public IActionResult OnGetRemoveFromCart(int id)
        {
            RemoveItemFromCart(id);
            return RedirectToPage();
        }

        // Helper method to remove an item from the cart
        private void RemoveItemFromCart(int id)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                cart.Remove(item);
                HttpContext.Session.Set("cart", cart);
            }
        }

        // Handle form submission (purchase)
        public IActionResult OnPost()
        {
            // Your purchase logic here
            return RedirectToPage("/Confirmation");
        }

        // Helper method to get the cart from session
        private List<ItemDto> GetCart()
        {
            return HttpContext.Session.Get<List<ItemDto>>("cart") ?? new List<ItemDto>();
        }

        // Helper method to update quantity of an item in the cart
        private void UpdateCartItemQuantity(int id, int change)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.Quantity += change;
                HttpContext.Session.Set("cart", cart);
            }
        }

       
    }
}
