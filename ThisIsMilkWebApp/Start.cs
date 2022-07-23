public class Start
{
    public void StartLogic() //inject logger
    {
        var logger = new Log();

        var numberOfStoryPoints = 5;
        var story = new Story("New Neve feature", numberOfStoryPoints);
        var stories = new List<Story> { story };

        var numberOfDaysInSprint = 5;
        var sprint = new Sprint(stories, numberOfDaysInSprint, DateTime.Now);

        foreach (var sprintDay in sprint.SprintDays)
        {
            if (sprintDay == null)
                continue;

            logger.WriteAsync($"Start sprint day {sprintDay.SprintDayNumber} on {sprintDay.SprintDayDate.ToShortDateString()}");
        }

        logger.WriteAsync("Sprint complete");
    }
}

public class Story
{
    public Story()
    {

    }

    public Story(string description, int points)
    {
        Description = description;
        Points = points;
    }

    public string Description { get; set; }
    public int Points { get; set; }
}

public class Sprint
{
    public IEnumerable<Story> Stories { get; set; }

    public IEnumerable<SprintDay> SprintDays { get; set; }

    public Sprint()
    {

    }

    public Sprint(IEnumerable<Story> stories, int numberOfDaysInSprint, DateTime sprintStartDate)
    {
        Stories = stories;

        if (numberOfDaysInSprint < 1 || numberOfDaysInSprint > 5)
            throw new ArgumentException("Sprint must be one to five days long"); //convert to custom exception

        var sprintDays = new List<SprintDay>();

        for (int dayNumber = 1; dayNumber <= numberOfDaysInSprint; dayNumber++)
        {
            var sprintDayDate = sprintStartDate.AddDays(dayNumber - 1).Date;
            var sprintDay = new SprintDay { SprintDayNumber = dayNumber, SprintDayDate = sprintDayDate };
            sprintDays.Add(sprintDay);
        }

        SprintDays = sprintDays;
    }
}

public class SprintDay
{
    public SprintDay()
    {

    }

    public int SprintDayNumber { get; set; }
    public DateTime SprintDayDate { get; set; }
}