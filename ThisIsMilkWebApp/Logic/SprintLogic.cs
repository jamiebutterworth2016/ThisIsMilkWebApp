using ThisIsMilkWebApp.Interfaces;

public class SprintLogic : ISprintLogic
{
    private readonly ISprintRepository _sprintRepository;

    public SprintLogic(ISprintRepository sprintRepository)
    {
        _sprintRepository = sprintRepository;
    }

    public async Task<IEnumerable<Sprint>> CreateSprintAsync(IEnumerable<Story> stories, int numberOfDaysInSprint, DateTime sprintStartDate, CancellationToken cancellationToken)
    {
        var sprint = new Sprint(stories, numberOfDaysInSprint, sprintStartDate);
        var sprints = await _sprintRepository.SaveSprintAsync(sprint, cancellationToken);
        return sprints;
    }

    public async Task<IEnumerable<Sprint>> GetSprintsAsync(CancellationToken cancellationToken)
    {
        var result = await _sprintRepository.GetSprintsAsync(cancellationToken);
        return result;
    }
}