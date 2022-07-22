public interface ISprintCreator
{
    Sprint CreateSprint(IEnumerable<Story> stories, int numberOfDaysInSprint, DateTime sprintStartDate);
}