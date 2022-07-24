namespace ThisIsMilkWebApp.Interfaces
{
	public interface IRepository<T>
	{
		Task<IEnumerable<T>> GetAsync(CancellationToken cancellationToken);
		Task<IEnumerable<T>> SaveAsync(T sprint, CancellationToken cancellationToken);
	}
}