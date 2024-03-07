namespace Circustrein;

class Program
{
    static void Main()
    {
        Train train = new Train();

        List<Animal> temporaryAnimalList = new List<Animal>();

        bool addingAnimals = true;

        while (addingAnimals)
        {
            Console.WriteLine("Wilt u een dier toevoegen? y/n");
            string? answer = Console.ReadLine();

            if (string.Equals(answer, "y", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Wat is het soort dier?");
                string? speciesInput = Console.ReadLine();
                Species species;

                switch (speciesInput!.ToLower())
                {
                    case "carnivoor":
                        species = Species.Carnivore;
                        break;
                    case "herbivoor":
                        species = Species.Herbivore;
                        break;
                    default:
                        Console.WriteLine("Ongeldige diersoort ingevoerd. Dier wordt als carnivoor beschouwd.");
                        species = Species.Carnivore;
                        break;
                }

                Console.WriteLine("Hoe groot is het dier? Klein, middel of groot");
                string? sizeInput = Console.ReadLine();
                Size size;

                switch (sizeInput!.ToLower())
                {
                    case "klein":
                        size = Size.Small;
                        break;
                    case "middel":
                        size = Size.Medium;
                        break;
                    case "groot":
                        size = Size.Large;
                        break;
                    default:
                        Console.WriteLine("Ongeldige grootte ingevoerd. Dier wordt als middel beschouwd.");
                        size = Size.Medium;
                        break;
                }

                Animal newAnimal = new Animal(species, size);
                temporaryAnimalList.Add(newAnimal);
            }
            else if (string.Equals(answer, "n", StringComparison.OrdinalIgnoreCase))
            {
                addingAnimals = false;
            }
            else
            {
                Console.WriteLine("Ongeldige invoer. Antwoord alstublieft met 'y' of 'n'.");
            }
        }

        train.CheckBetterDistribution(temporaryAnimalList);

        PrintAnimalsInWagons(train);
    }

    public static void PrintAnimalsInWagons(Train train)
    {
        Console.WriteLine("Overzicht van alle dieren in de wagons:");
        foreach (var wagon in train.Wagons)
        {
            Console.WriteLine($"Wagon {wagon.Id} bevat de volgende dieren:");
            foreach (var animal in wagon.Animals)
            {
                Console.WriteLine($"- Soort: {animal.Species}, Grootte: {animal.Size}");
            }
        }
    }
}