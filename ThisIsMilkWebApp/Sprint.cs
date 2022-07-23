
public class Sprint
{
    public int SprintId { get; set; }
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
