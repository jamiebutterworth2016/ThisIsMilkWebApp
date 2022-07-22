using Microsoft.AspNetCore.Mvc;
using ThisIsMilkWebApp.Interfaces;

namespace ThisIsMilkWebApp.Controllers
{
    public class SprintController : Controller
    {
        private readonly ILog _log;
        private readonly ISprintCreator _sprintCreator;

        public SprintController(ILog log)
        {
            _log = log;
            _sprintCreator = new SprintCreator();
        }

        public async Task<IActionResult> Start(StartSprintRequest request)
        {
            await _log.WriteAsync("Start Sprint");

            if (request.NumberOfDaysInSprint > 5) //change to frontend validation
                throw new Exception($"{nameof(StartSprintRequest.NumberOfDaysInSprint)} must be 5 days or under");

            var story = new Story("new story", 3); //change to drop down - 1, 3, 5, 8, 13

            var stories = new List<Story> { story };

            _sprintCreator.CreateSprint(stories, request.NumberOfDaysInSprint, DateTime.Now);

            return View();
        }
    }

    public class StartSprintRequest
    {
        public int NumberOfDaysInSprint { get; set; }
    }
}
