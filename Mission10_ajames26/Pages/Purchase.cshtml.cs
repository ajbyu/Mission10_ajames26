using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission10_ajames26.Infrastructure;
using Mission10_ajames26.Models;
using Mission10_ajames26.Repositories;
using System.Linq;

namespace Mission10_ajames26.Pages
{
    public class PurchaseModel : PageModel
    {
        public PurchaseModel(IBookRepository bookRepository)
        {
            _repo = bookRepository;
        }

        //Repository and cart object
        private IBookRepository _repo;
        public Cart cart { get; set; }

        public string ReturnUrl { get; set; }

        //GET and POST methods
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";

            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book book = _repo.Books.FirstOrDefault(b => b.BookId == bookId);

            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            cart.AddCartItem(book, 1);

            HttpContext.Session.SetJson("cart", cart);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
