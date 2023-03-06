using System.Linq;

namespace Mission10_ajames26.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
