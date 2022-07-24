using Microsoft.AspNetCore.Mvc;
using ThisIsMilkWebApp.Interfaces;

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
			try
			{
                var model = new HomeModel();

                var sprints = await _sprintLogic.GetSprintsAsync(cancellationToken);
                model.Sprints = sprints;

                return View(model);
            }
			catch (Exception ex)
			{
                await _log.WriteAsync(ex.ToString());
				return StatusCode(500); //hide exception from user
            }
        }
    }

    public class HomeModel
    {
        public IEnumerable<Sprint> Sprints { get; set; }
    }
}