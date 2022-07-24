using ThisIsMilkWebApp.Repositories;

namespace ThisIsMilkWebAppTests
{
	public class Tests
    {
        private readonly string DataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sprints_test.json");

        [OneTimeSetUp]
        public void Setup()
        {
            var file = File.Create(DataFilePath);
            file.Close();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            if (File.Exists(DataFilePath))
                File.Delete(DataFilePath);
        }

        [Test]
        public async Task SavingASprintToSprintFile_And_GettingSprintsFromUpdatedSprintFile()
        {
            var sprintRepository = new SprintRepository(DataFilePath);

            const string SprintDescription = "test";
            var startDate = DateTime.Now;
            const int SprintLengthInDays = 2;

            var sprint = new Sprint(SprintDescription, startDate, SprintLengthInDays);

            var saveResult = await sprintRepository.SaveAsync(sprint, new CancellationToken());

            var getSprintsResult = await sprintRepository.GetAsync(new CancellationToken());

            var sprintResult = getSprintsResult.Single();

            Assert.That(getSprintsResult.Count() == 1);
            Assert.That(sprintResult.SprintId == 1);
            Assert.That(sprintResult.SprintDescription == SprintDescription);
            Assert.That(sprintResult.SprintDays.Count() == SprintLengthInDays);

            var firstSprintDay = sprintResult.SprintDays.ElementAt(0);
            var secondSprintDay = sprintResult.SprintDays.ElementAt(1);

            Assert.That(firstSprintDay.SprintDayNumber == 1);
            Assert.That(firstSprintDay.SprintDayDate == startDate.Date);

            Assert.That(secondSprintDay.SprintDayNumber == 2);
            Assert.That(secondSprintDay.SprintDayDate == startDate.Date.AddDays(1));
        }
    }
}