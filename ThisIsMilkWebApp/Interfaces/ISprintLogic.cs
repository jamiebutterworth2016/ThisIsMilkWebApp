public interface ISprintLogic
{
    Task<IEnumerable<Sprint>> CreateSprintAsync(string sprintDescription, DateTime sprintStartDate, int sprintLengthInDays, CancellationToken cancellationToken);
    Task<IEnumerable<Sprint>> GetSprintsAsync(CancellationToken cancellationToken);
}