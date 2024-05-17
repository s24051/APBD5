using AnimalWebService.Models;

namespace AnimalWebService.Repositories;

public interface IAnimalsRepository
{
    IEnumerable<Animal> GetAnimals();
    int CreateAnimal(Animal animal);
    Animal? GetAnimal(int id);
    int UpdateAnimal(int id, Animal animal);
    int DeleteAnimal(int id);
}