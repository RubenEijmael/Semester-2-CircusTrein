public class Wagon
{
    public int Id { get; private set; }
    public int TotalPoints { get; private set; }
    private readonly List<Animal> animals;
    private const int MaxPoints = 10;

    public Wagon(int id)
    {
        Id = id;
        animals = new List<Animal>();
    }

    public bool CheckIfPossibleToAddAnimal(Animal newAnimal)
    {
        int newAnimalPoints = (int)newAnimal.Size;
        if (TotalPoints + newAnimalPoints > MaxPoints) return false;

        bool hasBiggerOrEqualCarnivore = animals.Any(a => a.Species == Species.Carnivore && a.Size >= newAnimal.Size);

        if (!hasBiggerOrEqualCarnivore)
        {
            if (newAnimal.Species == Species.Carnivore)
            {
                return !animals.Any(a => a.Size <= newAnimal.Size);
            }
            else
            {
                return !animals.Any(a => a.Species == Species.Carnivore && a.Size >= newAnimal.Size);
            }
        }

        return false;
    }

    public void AddAnimal(Animal animal)
    {
        if (CheckIfPossibleToAddAnimal(animal))
        {
            animals.Add(animal);
            TotalPoints += (int)animal.Size;
        }
        else
        {
            throw new InvalidOperationException("Kan dier niet toevoegen: overtreding van de regels.");
        }
    }

    public IReadOnlyList<Animal> Animals
    {
        get { return animals.AsReadOnly(); }
    }
}