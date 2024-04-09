using AnimalREST.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimalREST.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{
    public static readonly List<Animal> _animals = new ()
    {
        new Animal { Id = 1, Name = "Katsu", Category = "Cat", Mass = 4.5f, FurColor = "Orange" },
        new Animal { Id = 2, Name = "Buddy", Category = "Dog", Mass = 10.2f, FurColor = "Brown" },
        new Animal { Id = 3, Name = "Spirit", Category = "Horse", Mass = 500.0f, FurColor = "Chestnut" },
        new Animal { Id = 4, Name = "Tweetie", Category = "Bird", Mass = 0.2f, FurColor = "Colorful" },
        new Animal { Id = 5, Name = "Splash", Category = "Fish", Mass = 0.1f, FurColor = "None" },
        new Animal { Id = 6, Name = "Slither", Category = "Snake", Mass = 2.3f, FurColor = "Brown" },
        new Animal { Id = 7, Name = "Hoppy", Category = "Frog", Mass = 0.05f, FurColor = "Green" },
        new Animal { Id = 8, Name = "Nibbles", Category = "Hamster", Mass = 0.1f, FurColor = "Brown" },
        new Animal { Id = 9, Name = "Whiskers", Category = "Rabbit", Mass = 1.5f, FurColor = "White" },
        new Animal { Id = 10, Name = "Cluckers", Category = "Chicken", Mass = 2.0f, FurColor = "Brown" }
    };
    
    
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animals);
    }

    [HttpGet("{Id:int}")]
    public IActionResult GetAnimal(int Id)
    {
        var animal = _animals.FirstOrDefault(a => a.Id == Id);
        if (animal == null)
        {
            return NotFound($"Animal with id {Id} was not found");
        }

        return Ok(animal);
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        _animals.Add(animal);
        return StatusCode((StatusCodes.Status201Created));
    }

    [HttpPut]
    public IActionResult UpdateAnimal(int Id, Animal animal)
    {
        var animalToEdit = _animals.FirstOrDefault(a => a.Id == Id);
        if (animalToEdit == null)
        {
            return NotFound($"Animal with id {Id} was not found");
        }

        _animals.Remove(animalToEdit);
        _animals.Add(animal);
        return NoContent();
    }
    
    [HttpDelete("{Id:int}")]
    public IActionResult DeleteAnimal(int Id)
    {
        var animalToDelete = _animals.FirstOrDefault(a => a.Id == Id);
        if (animalToDelete == null)
        {
            return NotFound($"Animal with id {Id} was not found");
        }

        _animals.Remove(animalToDelete);
        return NoContent();
    }
}