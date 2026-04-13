using Microsoft.AspNetCore.Mvc;

public class Customer_Controller : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
// IactionResult --> a return type that represents the result of an action method in an ASP.NET MVC controller. It is a base class for various types of results, such as ViewResult, JsonResult, RedirectResult, etc., which are used to generate different types of responses to the client.