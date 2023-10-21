using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BoardGames.Models.ViewComponents
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private UserManager<IdentityUser> userManager;

        public NavigationMenuViewComponent(UserManager<IdentityUser> userMgr)
        {
            userManager = userMgr;
        }
        public IViewComponentResult Invoke()
        {
            IdentityUser user = userManager.GetUserAsync(HttpContext.User).Result;
            if (user != null)
            {
                ViewBag.Email = user.UserName;
            }
            return View();
        }
    }
}
