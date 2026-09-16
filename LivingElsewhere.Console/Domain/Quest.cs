namespace LivingElsewhere.Domain;

public class Quest
{
    public string Title { get; set; }
    public int Difficulty { get; set; }
    public Quest(string title, int difficulty)
    {
        Title = title;
        Difficulty = difficulty;
    }
}