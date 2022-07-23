public class Story
{
    public Story()
    {

    }

    public Story(string description, int points)
    {
        Description = description;
        Points = points;
    }

    public string Description { get; set; }
    public int Points { get; set; }
}
