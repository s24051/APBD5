using AnimalWebService.Models;

namespace AnimalWebService.Services;

public interface IAnimalsService
{
    IEnumerable<Animal> GetAnimals();
    int CreateAnimal(Animal animal);
    Animal? GetAnimal(int id);
    int UpdateAnimal(int id, Animal animal);
    int DeleteAnimal(int id);
}