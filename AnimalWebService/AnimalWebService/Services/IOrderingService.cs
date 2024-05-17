using AnimalWebService.Models;

namespace AnimalWebService.Services;

public interface IOrderingService
{
    IEnumerable<Animal> OrderAnimals(IEnumerable<Animal> animals, String? property);
}