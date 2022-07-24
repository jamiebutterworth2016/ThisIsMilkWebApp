using ThisIsMilkWebApp.Interfaces;

public class SprintLogic : ISprintLogic
{
    private readonly IRepository<Sprint> _sprintRepository;

    public SprintLogic(IRepository<Sprint> sprintRepository)
    {
        _sprintRepository = sprintRepository;
    }

    public async Task<IEnumerable<Sprint>> CreateSprintAsync(string sprintDescription, DateTime sprintStartDate, int sprintLengthInDays, CancellationToken cancellationToken)
    {
        var sprint = new Sprint(sprintDescription, sprintStartDate, sprintLengthInDays);
        var sprints = await _sprintRepository.SaveAsync(sprint, cancellationToken);
        return sprints;
    }

    public async Task<IEnumerable<Sprint>> GetSprintsAsync(CancellationToken cancellationToken)
    {
        var result = await _sprintRepository.GetAsync(cancellationToken);
        return result;
    }
}