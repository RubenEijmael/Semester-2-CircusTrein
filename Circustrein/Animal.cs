public class Animal
{
    public Size Size { get; private set; }
    public Species Species { get; private set; }

    public Animal(Species species, Size size)
    {
        this.Size = size;
        this.Species = species;
    }
}

public enum Size
{
    Small = 1,
    Medium = 3,
    Large = 5,
}

public enum Species
{
    Carnivore,
    Herbivore,
    Omnivore
}