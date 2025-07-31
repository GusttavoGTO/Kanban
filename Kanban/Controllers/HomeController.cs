using System.Diagnostics;
using Kanban.Services.Atividade;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Controllers;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }   
