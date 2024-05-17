using AnimalWebService.Exceptions;
using AnimalWebService.Models;
using AnimalWebService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimalWebService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalsController: ControllerBase
{
    private IAnimalsService _animalsService;
    private IOrderingService _orderingService;

    public AnimalsController(IAnimalsService animalsService, IOrderingService orderingService)
    {
        _animalsService = animalsService;
        _orderingService = orderingService;
    }

    /// <summary>
    /// Endpoint used to return list of animals.
    /// </summary>
    /// <returns>List of animals</returns>
    [HttpGet]
    public IActionResult GetAnimal([FromQuery] string? orderBy)
    {
        var animals = _animalsService.GetAnimals();
        try
        {
            return Ok(_orderingService.OrderAnimals(animals, orderBy));
        }
        catch (InvalidPropertyException e)
        {
            // nie wiem czy to błąd klienta 400,
            // czy nie jakiś precondition failed
            return BadRequest();
        }
    }

    /// <summary>
    /// Endpoint used to create an animal.
    /// </summary>
    /// <param name="animal">New animal data</param>
    /// <returns>201 Created</returns>
    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        var id = _animalsService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    /// <summary>
    /// Endpoint used to return an animal.
    /// </summary>
    /// <param name="id">Id of an animal</param>
    /// <returns>animal</returns>
    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = _animalsService.GetAnimal(id);

        if (animal == null)
            return NotFound($"Animal {id} not found");
        return Ok(animal);
    }
    
    /// <summary>
    /// Endpoint used to update an animal.
    /// </summary>
    /// <param name="id">Id of an animal</param>
    /// <param name="animal">204 No Content</param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    public IActionResult UpdateStudent(int id, Animal animal)
    {
        var count = _animalsService.UpdateAnimal(id, animal);
        if (count == 0)
            return NotFound($"Animal {id} not found");
        return NoContent();
    }
    
    /// <summary>
    /// Endpoint used to delete an animal.
    /// </summary>
    /// <param name="id">Id of an animal</param>
    /// <returns>204 No Content</returns>
    [HttpDelete("{id:int}")]
    public IActionResult DeleteStudent(int id)
    {
        var count = _animalsService.DeleteAnimal(id);
        if (count == 0)
            return NotFound($"Animal {id} not found");
        return NoContent();
    }
}