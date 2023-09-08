using Microsoft.AspNetCore.Mvc;

namespace AdressBook.Controllers
{
    public class AdressBookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
