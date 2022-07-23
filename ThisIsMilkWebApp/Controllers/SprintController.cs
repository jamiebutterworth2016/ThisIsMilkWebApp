using Microsoft.AspNetCore.Mvc;
using ThisIsMilkWebApp.Interfaces;

namespace ThisIsMilkWebApp.Controllers
{
    public class SprintController : Controller
    {
        private readonly ILog _log;
        private readonly ISprintLogic _sprintCreator;

        public SprintController(ILog log, ISprintLogic sprintCreator)
        {
            _log = log;
            _sprintCreator = sprintCreator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSprint(CreateSprintRequest request, CancellationToken cancellationToken)
        {
			try
			{
                await _log.WriteAsync("Start Sprint");

                if (request.NumberOfDaysInSprint < 1 || request.NumberOfDaysInSprint > 5)
                    throw new ArgumentException("Sprint must be one to five days long"); //convert to front end validation with bootstrap

                //check fibonacci

                var story = new Story("new story", request.StoryPoints);

                var stories = new List<Story> { story };

                var model = await _sprintCreator.CreateSprintAsync(stories, request.NumberOfDaysInSprint, DateTime.Now, cancellationToken);

                return PartialView("~/Views/Home/Sprints.cshtml", model);
            }
            catch (Exception ex)
			{
				throw;
			}
        }
    }

    public class CreateSprintRequest
    {
        public int StoryPoints { get; set; }
        public int NumberOfDaysInSprint { get; set; }
    }

    public class CreateStoryRequest
    {
        public int StoryPoints { get; set; }
    }
}
