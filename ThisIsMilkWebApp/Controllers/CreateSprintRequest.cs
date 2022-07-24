namespace ThisIsMilkWebApp.Controllers
{
	public class CreateSprintRequest
    {
        public string SprintDescription { get; set; }
        public int SprintLengthInDays { get; set; }
        public string SprintStartDate { get; set; }
    }
}
