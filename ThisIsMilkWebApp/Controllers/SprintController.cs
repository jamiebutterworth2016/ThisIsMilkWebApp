using Microsoft.AspNetCore.Mvc;
using ThisIsMilkWebApp.Interfaces;

namespace ThisIsMilkWebApp.Controllers
{
    public class SprintController : Controller
    {
        private readonly ILog _log;
        private readonly ISprintCreator _sprintCreator;

        public SprintController(ILog log, ISprintCreator sprintCreator)
        {
            _log = log;
            _sprintCreator = sprintCreator;
        }

        public async Task<IActionResult> Create(CreateSprintRequest request, CancellationToken cancellationToken)
        {
            await _log.WriteAsync("Start Sprint");

            if (request.NumberOfDaysInSprint < 1 || request.NumberOfDaysInSprint > 5)
                throw new ArgumentException("Sprint must be one to five days long"); //convert to front end validation with bootstrap

            var story = new Story("new story", 3); //change to drop down - 1, 3, 5, 8, 13

            var stories = new List<Story> { story };

            request.NumberOfDaysInSprint = 1;

            await _sprintCreator.CreateSprintAsync(stories, request.NumberOfDaysInSprint, DateTime.Now, cancellationToken);

            return View();
        }
    }

    public class CreateSprintRequest
    {
        public int NumberOfDaysInSprint { get; set; }
    }
}
