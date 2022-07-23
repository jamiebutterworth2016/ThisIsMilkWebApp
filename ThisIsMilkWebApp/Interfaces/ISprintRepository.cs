namespace ThisIsMilkWebApp.Interfaces
{
    public interface ISprintRepository
    {
        Task<IEnumerable<Sprint>> GetSprintsAsync(CancellationToken cancellationToken);
        Task SaveSprintAsync(Sprint sprint, CancellationToken cancellationToken);
    }
}