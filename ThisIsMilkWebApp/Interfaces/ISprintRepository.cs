namespace ThisIsMilkWebApp.Interfaces
{
	public interface ISprintRepository
    {
        Task<IEnumerable<Sprint>> GetSprintsAsync(CancellationToken cancellationToken);
        Task<IEnumerable<Sprint>> SaveSprintAsync(Sprint sprint, CancellationToken cancellationToken);
    }
}