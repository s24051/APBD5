using AnimalWebService.Exceptions;
using AnimalWebService.Models;

namespace AnimalWebService.Services;

public class OrderingService: IOrderingService
{
    
    public IEnumerable<Animal> OrderAnimals(IEnumerable<Animal> animals, String? property)
    {
        // Gdyby chcieć aby oryginał był nie naruszony
        // IEnumerable<Animal> copy = animals.toList();
        // i cały switch na kopii
        switch (property)
        {
            case "IdAnimal":
                return animals.OrderBy(animal => animal.IdAnimal);
            case "Name":
                return animals.OrderBy(animal => animal.Name);
            case "Description":
                return animals.OrderBy(animal => animal.Description);
            case "Category":
                return animals.OrderBy(animal => animal.Category);
            case "Area":
                return animals.OrderBy(animal => animal.Area);
            default:
                if (String.IsNullOrEmpty(property))
                    return animals.OrderBy(animal => animal.Name);
                throw new InvalidPropertyException();
        }
    }
}