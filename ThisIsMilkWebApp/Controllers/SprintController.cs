using Microsoft.AspNetCore.Mvc;
using ThisIsMilkWebApp.Interfaces;

namespace ThisIsMilkWebApp.Controllers
{
	public class SprintController : Controller
    {
        private readonly ILog _log;
        private readonly ISprintLogic _sprintLogic;

        public SprintController(ILog log, ISprintLogic sprintLogic)
        {
            _log = log;
            _sprintLogic = sprintLogic;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSprint(CreateSprintRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.SprintLengthInDays < 1 || request.SprintLengthInDays > 5)
                    throw new ArgumentException("Sprint length must be one to five days long");

                if (!DateTime.TryParse(request.SprintStartDate, out var sprintStartDate))
                    throw new ArgumentException("Sprint start date must be in dd/MM/yyyy format");

                var model = await _sprintLogic.CreateSprintAsync(request.SprintDescription, sprintStartDate, request.SprintLengthInDays, cancellationToken);
                await _log.WriteAsync("Created sprint");

                return PartialView("~/Views/Home/Sprints.cshtml", model);
            }
            catch (ArgumentException ex)
            {
                await _log.WriteAsync(ex.ToString());
                return StatusCode(400); //hide exception from user
            }
            catch (Exception ex)
            {
                await _log.WriteAsync(ex.ToString());
                return StatusCode(500); //hide exception from user
            }
        }
    }
}
