// Regroupe les types représentant les concepts du monde.
namespace LivingElsewhere.Domain;

public class Adventurer
{
    public string Name { get; set; }
    public int Level { get; private set; }
    public Adventurer(string name, int level)
    {
        Name = name;
        Level = level;
    }

    public void LevelUp()
    {
        Level++;
    }

}
