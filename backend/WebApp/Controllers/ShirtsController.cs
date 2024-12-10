using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Models;

using WebApp.Models.Repositories;


namespace WebApp.Controllers
{
    public class ShirtsController : Controller
    {

        private readonly IWebApiExecuter webApiExecuter;

        public ShirtsController(IWebApiExecuter webApiExecuter)
        {
            this.webApiExecuter = webApiExecuter;
        }
        public  async Task<IActionResult> Index()
        {
            var shirts = await webApiExecuter.InvokeGet<List<Shirt>>("shirts");
            return View(shirts);
        }


        public IActionResult CreateShirt()
        {
            return View();
        }

        [HttpPost]

        public IActionResult CreateShirt(Shirt shirt)
        {
            return View(shirt);
        }

    }
}
