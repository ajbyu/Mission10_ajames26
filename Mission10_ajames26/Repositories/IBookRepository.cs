using System.Linq;
using Mission10_ajames26.Models;

namespace Mission10_ajames26.Repositories
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
