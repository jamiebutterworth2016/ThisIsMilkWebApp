using System.Text.Json;
using ThisIsMilkWebApp.Interfaces;

namespace ThisIsMilkWebApp.Repositories
{
    public class SprintRepository : ISprintRepository
    {
        public string DataFilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"sprints.json");

        public async Task<IEnumerable<Sprint>> GetSprintsAsync(CancellationToken cancellationToken)
        {
            using (var stream = File.OpenRead(DataFilePath))
            {
                var result = await JsonSerializer.DeserializeAsync<IEnumerable<Sprint>>(stream, cancellationToken: cancellationToken);
                return result;
            }
        }

        public async Task SaveSprintAsync(Sprint sprint, CancellationToken cancellationToken)
        {
            using (var stream = File.Open(DataFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                var sprints = stream.Length == 0 ? new List<Sprint>() : await JsonSerializer.DeserializeAsync<ICollection<Sprint>>(stream);
                sprints.Add(sprint);
                await JsonSerializer.SerializeAsync(stream, sprints, cancellationToken: cancellationToken);
            }
        }
    }
}