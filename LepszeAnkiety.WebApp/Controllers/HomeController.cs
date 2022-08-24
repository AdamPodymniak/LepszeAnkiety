using LepszeAnkiety.Repository.Entities;
using LepszeAnkiety.WebApp.Models;
using LepszeAnkiety.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LepszeAnkiety.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFormService _formService;

        public HomeController(ILogger<HomeController> logger, IFormService formService)
        {
            _formService = formService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var forms = _formService.GetAllForms();
            return View(forms);
        }

        [Route("DeleteForm/{key}")]
        public IActionResult DeleteForm(Guid key)
        {
            _formService.DeleteResultByFormKey(key);
            _formService.DeleteForm(key);
            _formService.DeleteFieldByKey(key);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AddForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddForm(Form e)
        {
            if(e.Name != null)
            {
                _formService.AddForm(e);
                return RedirectToAction("Index");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}