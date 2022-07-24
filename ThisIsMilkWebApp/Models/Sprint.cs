public class Sprint
{
    public int SprintId { get; set; }
	public string SprintDescription { get; set; }
    public IEnumerable<SprintDay> SprintDays { get; set; }

    public Sprint() //required for json serialisation
    {
    }

    public Sprint(string sprintDescription, DateTime sprintStartDate, int sprintLengthInDays)
    {
        SprintDescription = sprintDescription;

        if (string.IsNullOrWhiteSpace(sprintDescription))
            throw new ArgumentException("Sprint description must not be empty");

        if (sprintLengthInDays < 1 || sprintLengthInDays > 5)
            throw new ArgumentException("Sprint length must be one to five days long");

        var sprintDays = new List<SprintDay>();

        for (int dayNumber = 1; dayNumber <= sprintLengthInDays; dayNumber++)
        {
            var sprintDayDate = sprintStartDate.AddDays(dayNumber - 1).Date;
            var sprintDay = new SprintDay { SprintDayNumber = dayNumber, SprintDayDate = sprintDayDate };
            sprintDays.Add(sprintDay);
        }

        SprintDays = sprintDays;
    }
}
