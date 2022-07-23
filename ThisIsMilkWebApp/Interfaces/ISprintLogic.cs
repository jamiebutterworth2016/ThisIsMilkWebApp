public interface ISprintLogic
{
    Task<IEnumerable<Sprint>> CreateSprintAsync(IEnumerable<Story> stories, int numberOfDaysInSprint, DateTime sprintStartDate, CancellationToken cancellationToken);
    Task<IEnumerable<Sprint>> GetSprintsAsync(CancellationToken cancellationToken);
}