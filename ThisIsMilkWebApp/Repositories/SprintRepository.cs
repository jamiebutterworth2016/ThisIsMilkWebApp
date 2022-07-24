using System.Text.Json;
using ThisIsMilkWebApp.Interfaces;
using ThisIsMilkWebApp.Models;

namespace ThisIsMilkWebApp.Repositories
{
	public class SprintRepository : IRepository<Sprint>
    {
        private readonly string _dataFilePath;

		public SprintRepository(string dataFilePath)
		{
            _dataFilePath = dataFilePath;
        }

        public async Task<IEnumerable<Sprint>> GetAsync(CancellationToken cancellationToken)
        {
            using (var stream = File.Open(_dataFilePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                var result = stream.Length == 0 ? new SprintsJsonFile() { Sprints = new List<Sprint>() } : await JsonSerializer.DeserializeAsync<SprintsJsonFile>(stream);
                return result.Sprints;
            }
        }

        public async Task<IEnumerable<Sprint>> SaveAsync(Sprint sprint, CancellationToken cancellationToken)
        {
            using (var stream = File.Open(_dataFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                var sprintsJsonFile = stream.Length == 0 ? new SprintsJsonFile() : await JsonSerializer.DeserializeAsync<SprintsJsonFile>(stream);

                if (sprintsJsonFile.Sprints == null)
                    sprintsJsonFile.Sprints = new List<Sprint>();

                stream.SetLength(0); //delete existing data so it can be replaced by existing data plus the new sprint.

                var newSprintId = sprintsJsonFile.Sprints.Any() ? sprintsJsonFile.Sprints.Max(x => x.SprintId) + 1 : 1;

                sprint.SprintId = newSprintId;
                sprintsJsonFile.Sprints.Add(sprint);

                await JsonSerializer.SerializeAsync(stream, sprintsJsonFile, cancellationToken: cancellationToken);

                return sprintsJsonFile.Sprints;
            }
        }
    }
}