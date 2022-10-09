using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
