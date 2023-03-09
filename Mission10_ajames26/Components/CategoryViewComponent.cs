using Microsoft.AspNetCore.Mvc;
using Mission10_ajames26.Repositories;
using System.Linq;

namespace Mission10_ajames26.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        public CategoryViewComponent(IBookRepository bookRepository)
        {
            _repo = bookRepository;
        }

        private IBookRepository _repo { get; set; }

        public IViewComponentResult Invoke()
        {
            //Get selected category
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            //Get book categories
            var categories = _repo
                .Books
                .Select(b => b.Category)
                .Distinct()
                .OrderBy(c => c);

            return View(categories);
        }
    }
}
