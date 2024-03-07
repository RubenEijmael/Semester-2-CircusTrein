using Circustrein;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TrainTests
{
    [TestClass]
    public class CircusTrainTests
    {
        [TestMethod]
        public void TestAddAnimalToWagon()
        {
            // Arrange
            Train train = new Train();
            Animal smallHerbivore = new Animal(Species.Herbivore, Size.Small);

            // Act
            train.AddAnimalToWagon(smallHerbivore);

            // Assert
            Assert.AreEqual(1, train.Wagons.Count);
            Assert.AreEqual(1, train.Wagons[0].Animals.Count);
        }

        [TestMethod]
        public void TestCheckIfPossibleToAddAnimal()
        {
            // Arrange
            Wagon wagon = new Wagon(1);
            Animal largeCarnivore = new Animal(Species.Carnivore, Size.Large);

            // Act
            bool canAddAnimal = wagon.CheckIfPossibleToAddAnimal(largeCarnivore);

            // Assert
            Assert.IsTrue(canAddAnimal);
        }

        [TestMethod]
        public void TestCheckBetterDistributionCase1()
        {
            // Arrange
            Train train = new Train();
            List<Animal> animals = new List<Animal>
            {
                new Animal(Species.Carnivore, Size.Small),
                new Animal(Species.Herbivore, Size.Large),
                new Animal(Species.Herbivore, Size.Large),
                new Animal(Species.Herbivore, Size.Medium),
                new Animal(Species.Herbivore, Size.Medium),
                new Animal(Species.Herbivore, Size.Medium),
            };

            // Act
            train.CheckBetterDistribution(animals);

            // Assert
            Assert.AreEqual(2, train.Wagons.Count);

            int carnivoresCount = train.Wagons.Sum(wagon => wagon.Animals.Count(animal => animal.Species == Species.Carnivore));
            int herbivoresCount = train.Wagons.Sum(wagon => wagon.Animals.Count(animal => animal.Species == Species.Herbivore));

            // Assuming logic distributes Carnivores first and then Herbivores
            Assert.AreEqual(1, carnivoresCount);
            Assert.AreEqual(5, herbivoresCount);
        }

        [TestMethod]
        public void TestCheckBetterDistributionCase2()
        {
            // Arrange
            Train train = new Train();
            List<Animal> animals = new List<Animal>
            {
                new Animal(Species.Carnivore, Size.Small),
                new Animal(Species.Herbivore, Size.Large),
                new Animal(Species.Herbivore, Size.Medium),
                new Animal(Species.Herbivore, Size.Medium),
                new Animal(Species.Herbivore, Size.Small),
                new Animal(Species.Herbivore, Size.Small),
            };

            // Act
            train.CheckBetterDistribution(animals);

            // Assert
            Assert.AreEqual(2, train.Wagons.Count);

            int carnivoresCount = train.Wagons.Sum(wagon => wagon.Animals.Count(animal => animal.Species == Species.Carnivore));
            int herbivoresCount = train.Wagons.Sum(wagon => wagon.Animals.Count(animal => animal.Species == Species.Herbivore));

            // Assuming logic distributes Carnivores first and then Herbivores
            Assert.AreEqual(1, carnivoresCount);
            Assert.AreEqual(5, herbivoresCount);
        }

        [TestMethod]
        public void TestCheckBetterDistributionCase3()
        {
            // Arrange
            Train train = new Train();
            List<Animal> animals = new List<Animal>
            {
                new Animal(Species.Carnivore, Size.Large),
                new Animal(Species.Carnivore, Size.Medium),
                new Animal(Species.Carnivore, Size.Small),
                new Animal(Species.Herbivore, Size.Large),
                new Animal(Species.Herbivore, Size.Medium),
                new Animal(Species.Herbivore, Size.Small),
            };

            // Act
            train.CheckBetterDistribution(animals);

            // Assert
            Assert.AreEqual(4, train.Wagons.Count);

            int carnivoresCount = train.Wagons.Sum(wagon => wagon.Animals.Count(animal => animal.Species == Species.Carnivore));
            int herbivoresCount = train.Wagons.Sum(wagon => wagon.Animals.Count(animal => animal.Species == Species.Herbivore));

            // Assuming logic distributes Carnivores first and then Herbivores
            Assert.AreEqual(3, carnivoresCount);
            Assert.AreEqual(3, herbivoresCount);
        }

        [TestMethod]
        public void TestCheckBetterDistributionCase4()
        {
            // Arrange
            Train train = new Train();
            List<Animal> animals = new List<Animal>
            {
                new Animal(Species.Carnivore, Size.Large),
                new Animal(Species.Carnivore, Size.Large),
                new Animal(Species.Carnivore, Size.Medium),
                new Animal(Species.Carnivore, Size.Small),
                new Animal(Species.Herbivore, Size.Large),
                new Animal(Species.Herbivore, Size.Medium),
                new Animal(Species.Herbivore, Size.Medium),
                new Animal(Species.Herbivore, Size.Medium),
                new Animal(Species.Herbivore, Size.Medium),
                new Animal(Species.Herbivore, Size.Medium),
                new Animal(Species.Herbivore, Size.Small),
            };

            // Act
            train.CheckBetterDistribution(animals);

            // Assert
            Assert.AreEqual(5, train.Wagons.Count);

            int carnivoresCount = train.Wagons.Sum(wagon => wagon.Animals.Count(animal => animal.Species == Species.Carnivore));
            int herbivoresCount = train.Wagons.Sum(wagon => wagon.Animals.Count(animal => animal.Species == Species.Herbivore));

            // Assuming logic distributes Carnivores first and then Herbivores
            Assert.AreEqual(4, carnivoresCount);
            Assert.AreEqual(7, herbivoresCount);
        }

        [TestMethod]
        public void TestCheckBetterDistributionCase5()
        {
            // Arrange
            Train train = new Train();
            List<Animal> animals = new List<Animal>
            {
                new Animal(Species.Carnivore, Size.Small),
                new Animal(Species.Carnivore, Size.Small),
                new Animal(Species.Carnivore, Size.Small),
                new Animal(Species.Herbivore, Size.Large),
                new Animal(Species.Herbivore, Size.Large),
                new Animal(Species.Herbivore, Size.Large),
                new Animal(Species.Herbivore, Size.Medium),
                new Animal(Species.Herbivore, Size.Medium),
                new Animal(Species.Herbivore, Size.Medium),
            };

            // Act
            train.CheckBetterDistribution(animals);

            // Assert
            Assert.AreEqual(3, train.Wagons.Count);

            int carnivoresCount = train.Wagons.Sum(wagon => wagon.Animals.Count(animal => animal.Species == Species.Carnivore));
            int herbivoresCount = train.Wagons.Sum(wagon => wagon.Animals.Count(animal => animal.Species == Species.Herbivore));

            // Assuming logic distributes Carnivores first and then Herbivores
            Assert.AreEqual(3, carnivoresCount);
            Assert.AreEqual(6, herbivoresCount);
        }

        [TestMethod]
        public void TestCheckBetterDistributionCase6()
        {
            // Arrange
            Train train = new Train();
            List<Animal> animals = new List<Animal>
            {
                new Animal(Species.Carnivore, Size.Large),
                new Animal(Species.Carnivore, Size.Large),
                new Animal(Species.Carnivore, Size.Large),
                new Animal(Species.Carnivore, Size.Medium),
                new Animal(Species.Carnivore, Size.Medium),
                new Animal(Species.Carnivore, Size.Medium),
                new Animal(Species.Carnivore, Size.Small),
                new Animal(Species.Carnivore, Size.Small),
                new Animal(Species.Carnivore, Size.Small),
                new Animal(Species.Carnivore, Size.Small),
                new Animal(Species.Carnivore, Size.Small),
                new Animal(Species.Carnivore, Size.Small),
                new Animal(Species.Carnivore, Size.Small),
                new Animal(Species.Herbivore, Size.Large),
                new Animal(Species.Herbivore, Size.Large),
                new Animal(Species.Herbivore, Size.Large),
                new Animal(Species.Herbivore, Size.Large),
                new Animal(Species.Herbivore, Size.Large),
                new Animal(Species.Herbivore, Size.Large),
                new Animal(Species.Herbivore, Size.Medium),
                new Animal(Species.Herbivore, Size.Medium),
                new Animal(Species.Herbivore, Size.Medium),
                new Animal(Species.Herbivore, Size.Medium),
                new Animal(Species.Herbivore, Size.Medium),
            };

            // Act
            train.CheckBetterDistribution(animals);

            // Assert
            Assert.AreEqual(13, train.Wagons.Count);

            int carnivoresCount = train.Wagons.Sum(wagon => wagon.Animals.Count(animal => animal.Species == Species.Carnivore));
            int herbivoresCount = train.Wagons.Sum(wagon => wagon.Animals.Count(animal => animal.Species == Species.Herbivore));

            // Assuming logic distributes Carnivores first and then Herbivores
            Assert.AreEqual(13, carnivoresCount);
            Assert.AreEqual(11, herbivoresCount);
        }
    }
}