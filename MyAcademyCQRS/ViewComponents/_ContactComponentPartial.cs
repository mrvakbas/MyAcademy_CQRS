using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCQRS.ViewComponents
{
    public class _ContactComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
