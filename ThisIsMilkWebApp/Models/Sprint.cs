using System.Text.RegularExpressions;

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

        var sprintDescriptionIsValid = Regex.IsMatch(sprintDescription.Replace(" ", ""), "^[a-zA-Z0-9_]{1,24}$");

        if (!sprintDescriptionIsValid)
            throw new ArgumentException("Sprint description must be alphanumeric, between 1 and 24 characters");

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
