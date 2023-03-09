using System.Collections.Generic;
using System.Linq;

namespace Mission10_ajames26.Models
{
    public class Cart
    {
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public void AddCartItem(Book book, int quantity)
        {
            if (!CartItems.Any(i => i.Book.BookId == book.BookId))
            {
                CartItems.Add(new CartItem { Book = book, Quantity = quantity });
            }
            else
            {
                CartItems.Single(i => i.Book.BookId == book.BookId).Quantity += quantity;
            }
        }
    }

    public class CartItem
    {
        public int LineId { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
