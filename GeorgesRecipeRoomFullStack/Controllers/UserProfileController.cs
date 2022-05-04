using Microsoft.AspNetCore.Mvc;

namespace GeorgesRecipeRoomFullStack.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
