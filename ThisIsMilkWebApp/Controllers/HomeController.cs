using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ThisIsMilkWebApp.Interfaces;
using ThisIsMilkWebApp.Models;

namespace ThisIsMilkWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog _log;
        private readonly ISprintLogic _sprintLogic;

        public HomeController(ILog log, ISprintLogic sprintLogic)
        {
            _log = log;
            _sprintLogic = sprintLogic;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            await _log.WriteAsync("Home");

            var storyPoints = new List<int>();

            for (int i = 2; i < 9; i++)
            {
                var storyPoint = Fibonacci(i);

                storyPoints.Add(storyPoint);
            }

            var model = new HomeModel();

            var storyPointListItems = new List<SelectListItem>();

            storyPoints.ForEach(x => storyPointListItems.Add(new SelectListItem { Value = x.ToString(), Text = x.ToString() }));

            model.StoryPointListItems = storyPointListItems;

            //store as json
            //read json file and show list on page of existing ones. show items

            var sprints = await _sprintLogic.GetSprintsAsync(cancellationToken);
            model.Sprints = sprints;

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public int Fibonacci(int n)
        {
            var a = 0;
            var b = 1;

            for (var i = 0; i < n; i++)
            {
                var temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }
    }

    public class HomeModel
    {
        public IEnumerable<SelectListItem> StoryPointListItems { get; set; }

        public IEnumerable<Sprint> Sprints { get; set; }
    }
}