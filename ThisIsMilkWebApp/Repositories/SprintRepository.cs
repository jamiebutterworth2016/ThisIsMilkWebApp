using System.Text.Json;
using ThisIsMilkWebApp.Interfaces;

namespace ThisIsMilkWebApp.Repositories
{
    public class SprintRepository : ISprintRepository
    {
        public string DataFilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"sprints.json");

        public async Task<IEnumerable<Sprint>> GetSprintsAsync(CancellationToken cancellationToken)
        {
            using (var stream = File.Open(DataFilePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                var result = stream.Length == 0 ? new SprintsJsonFile() { Sprints = new List<Sprint>() } : await JsonSerializer.DeserializeAsync<SprintsJsonFile>(stream);
                return result.Sprints;
            }
        }

        public async Task<IEnumerable<Sprint>> SaveSprintAsync(Sprint sprint, CancellationToken cancellationToken)
        {
            using (var stream = File.Open(DataFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                var sprintsJsonFile = stream.Length == 0 ? new SprintsJsonFile() { Sprints = new List<Sprint>() } : await JsonSerializer.DeserializeAsync<SprintsJsonFile>(stream);

                sprintsJsonFile.Sprints.Add(sprint);

                stream.SetLength(0); //delete existing data so it can be replaced by existing data plus the new story.

                await JsonSerializer.SerializeAsync(stream, sprintsJsonFile, cancellationToken: cancellationToken);

                return sprintsJsonFile.Sprints;
            }
        }
    }

    public class SprintsJsonFile
    {
        public ICollection<Sprint> Sprints { get; set; }
    }
}