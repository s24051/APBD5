using AnimalWebService.Models;
using AnimalWebService.Repositories;

namespace AnimalWebService.Services;

public class AnimalsService: IAnimalsService
{
    private readonly IAnimalsRepository _animalsRepository;

    public AnimalsService(IAnimalsRepository animalsRepository)
    {
        _animalsRepository = animalsRepository;
    }
    public IEnumerable<Animal> GetAnimals()
    {
        return _animalsRepository.GetAnimals();
    }

    public int CreateAnimal(Animal animal)
    {
        return _animalsRepository.CreateAnimal(animal);
    }

    public Animal? GetAnimal(int id)
    {
        return _animalsRepository.GetAnimal(id);
    }

    public int UpdateAnimal(int id, Animal animal)
    {
        return _animalsRepository.UpdateAnimal(id, animal);
    }

    public int DeleteAnimal(int id)
    {
        return _animalsRepository.DeleteAnimal(id);
    }
}