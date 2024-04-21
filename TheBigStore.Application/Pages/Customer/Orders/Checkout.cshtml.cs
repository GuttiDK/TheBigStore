using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Application.SessionHelper;
using TheBigStore.Service.Interfaces.UserInterfaces;

namespace TheBigStore.Application.Pages.Customer.Orders
{
    public class CheckoutModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Phone number is required")]
        public string Phone { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please select a payment method")]
        public string PaymentMethod { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Street name is required")]
        public string StreetName { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Street number is required")]
        public string StreetNumber { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        public string ZipCode { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }


        public List<ItemDto> Items { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string Handler { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        private readonly IUserService _userService;
        public UserDto User { get; set; }


        private readonly ICustomerService _customerService;
        public CustomerDto Customer { get; set; }


        private readonly IAddressService _addressService;
        public AddressDto Address { get; set; }


        public CheckoutModel(IUserService userService, ICustomerService customerService, IAddressService addressService)
        {
            _userService=userService;
            _customerService=customerService;
            _addressService=addressService;
        }

        // Get the products from the cart/session
        public async void OnGet()
        {
            if (Handler == "RemoveFromCart")
            {
                RemoveItemFromCart(Id);
            }
            else if (Handler == "IncreaseQuantity")
            {
                UpdateCartItemQuantity(Id, 1);
            }
            else if (Handler == "DecreaseQuantity")
            {
                UpdateCartItemQuantity(Id, -1);
            }
            Items = GetCart();
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
        public async Task<IActionResult> OnPost()
        {
            // Purchase logic here
            var id = HttpContext.Session.GetInt32("id");
            if (id == null)
            {
                RedirectToPage("/Login/Login");
            }
            var user = await _userService.GetByIdAsync((int)id);
            var cart = GetCart();
            if (cart.Count == 0)
            {
                return RedirectToPage("/Index");
            }
            CustomerDto customer = new CustomerDto
            {
                FirstName = FirstName,
                LastName = LastName,
                Phone = Phone,
                Email = Email,
            };
            AddressDto address = new AddressDto
            {
                StreetName = StreetName,
                City = City,
                ZipCode = ZipCode,
                Country = Country,
                StreetNumber = StreetNumber,
            };
            await _customerService.AddToCart(cart, (int)id, Customer, address);
            return RedirectToPage("/Index");
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
