using AnimalWebService.Models;

namespace TestProject1.Mocks;
using AnimalWebService.Repositories;

public class TestAnimalRepository: IAnimalsRepository
{
    private List<Animal> _animals;

    public TestAnimalRepository()
    {
        _animals = new List<Animal>();
    }
    public IEnumerable<Animal> GetAnimals()
    {
        return _animals;
    }

    public int CreateAnimal(Animal animal)
    {
        if (_animals.Find(item => item.IdAnimal == animal.IdAnimal) != null)
            return 0;
        _animals.Add(animal);
        return 1;
    }

    public Animal? GetAnimal(int id)
    {
        return _animals.Find(item => item.IdAnimal == id);
    }

    public int UpdateAnimal(int id, Animal animal)
    {
        Animal _animal = _animals.Find(item => item.IdAnimal == id);
        if (_animal == null)
            return 0;
        _animal.Name = animal.Name;
        _animal.Description = animal.Description;
        _animal.Category = animal.Category;
        _animal.Area = animal.Area;
        return 1;
    }

    public int DeleteAnimal(int id)
    {
        Animal animal = _animals.Find(item => item.IdAnimal == id);
        if (animal == null)
            return 0;
        _animals.Remove(animal);
        return 1;
    }
}