using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace MVC;

public class StudentController : Controller
{
    public IActionResult Index()
    {
        ViewData["Message"] = "Hello World!";
        ViewData["PersonName"] = "John Doe";
        return View();
    }
}
