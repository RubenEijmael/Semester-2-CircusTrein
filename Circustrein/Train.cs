public class Train
{
    private readonly List<Wagon> wagons;

    public Train()
    {
        wagons = new List<Wagon>();
    }

    public void CheckBetterDistribution(List<Animal> animals)
    {
        var sortedDescendingAnimals = animals
            .OrderByDescending(a => a.Species == Species.Carnivore)
            .ThenByDescending(a => a.Size)
            .ToList();

        var sortedAscendingAnimals = animals
            .OrderBy(a => a.Species == Species.Carnivore)
            .ThenBy(a => a.Size)
            .ToList();

        var descendingTrain = new Train();
        foreach (var animal in sortedDescendingAnimals)
        {
            descendingTrain.AddAnimalToWagon(animal);
        }

        var ascendingTrain = new Train();
        foreach (var animal in sortedAscendingAnimals)
        {
            ascendingTrain.AddAnimalToWagon(animal);
        }

        var betterTrain = ChooseBetterTrain(descendingTrain, ascendingTrain);

        AddAnimalsOfCorrectTrain(betterTrain);
    }

    private Train ChooseBetterTrain(Train train1, Train train2)
    {
        int wagonsNeeded1 = train1.Wagons.Count;
        int wagonsNeeded2 = train2.Wagons.Count;

        return wagonsNeeded1 <= wagonsNeeded2 ? train1 : train2;
    }

    private void AddAnimalsOfCorrectTrain(Train sourceTrain)
    {
        foreach (var wagon in sourceTrain.Wagons)
        {
            foreach (var animal in wagon.Animals)
            {
                AddAnimalToWagon(animal);
            }
        }
    }

    public void AddAnimalToWagon(Animal animal)
    {
        Wagon? suitableWagon = wagons.FirstOrDefault(wagon => wagon.CheckIfPossibleToAddAnimal(animal));

        if (suitableWagon != null)
        {
            suitableWagon.AddAnimal(animal);
        }
        else
        {
            Wagon newWagon = new Wagon(wagons.Count + 1);
            newWagon.AddAnimal(animal);
            wagons.Add(newWagon);
        }
    }

    public IReadOnlyList<Wagon> Wagons
    {
        get { return wagons.AsReadOnly(); }
    }
}