public class SprintCreator : ISprintCreator
{
    public Sprint CreateSprint(IEnumerable<Story> stories, int numberOfDaysInSprint, DateTime sprintStartDate)
    {
        var sprint = new Sprint(stories, numberOfDaysInSprint, sprintStartDate);
        return sprint;
    }
}