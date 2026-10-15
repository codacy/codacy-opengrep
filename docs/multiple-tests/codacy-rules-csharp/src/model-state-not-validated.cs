using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Web
{
    public class Movie { public string Title { get; set; } }

    public class MoviesController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Create(Movie movie) // Noncompliant
        {
            await Task.Yield();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateChecked(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }
            await Task.Yield();
            return RedirectToAction("Index");
        }
    }
}
