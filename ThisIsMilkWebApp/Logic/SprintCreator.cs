using ThisIsMilkWebApp.Interfaces;

public class SprintCreator : ISprintCreator
{
    private readonly ISprintRepository _sprintRepository;

    public SprintCreator(ISprintRepository sprintRepository)
    {
        _sprintRepository = sprintRepository;
    }

    public async Task CreateSprintAsync(IEnumerable<Story> stories, int numberOfDaysInSprint, DateTime sprintStartDate, CancellationToken cancellationToken)
    {
        var sprint = new Sprint(stories, numberOfDaysInSprint, sprintStartDate);

        await _sprintRepository.SaveSprintAsync(sprint, cancellationToken);
    }
}