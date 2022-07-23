public interface ISprintCreator
{
    Task CreateSprintAsync(IEnumerable<Story> stories, int numberOfDaysInSprint, DateTime sprintStartDate, CancellationToken cancellationToken);
}