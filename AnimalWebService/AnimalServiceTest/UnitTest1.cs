using AnimalWebService.Models;
using TestProject1.Mocks;

namespace TestProject1;
using AnimalWebService.Services;

public class UnitTest1
{
    [Fact]
    public void CreateAnimalTest()
    {
        var service = new AnimalsService(new TestAnimalRepository());
        var result = service.CreateAnimal(new Animal
        {
            IdAnimal = 1,
            Name = "Cate",
            Description = "Black Cate",
            Category = "Cats",
            Area = "EU"
        });
        Assert.Equal(1, result);
    }
    
    [Fact]
    public void GetAnimalTest()
    {
        var service = new AnimalsService(new TestAnimalRepository());
        int id = 1;
        String name = "TestName";
        String description = "TestDescription";
        String category = "TestCategory";
        String area = "TestArea";
        var result = service.CreateAnimal(new Animal
        {
            IdAnimal = id,
            Name = name,
            Description = description,
            Category = category,
            Area = area
        });
        Assert.Equal(1, result);

        var _animal = service.GetAnimal(id);
        Assert.NotNull(_animal);
        Assert.Equal(_animal.Name, name);
        Assert.Equal(_animal.Description, description);
        Assert.Equal(_animal.Category, category);
        Assert.Equal(_animal.Area, area);
    }
    
    [Fact]
    public void GetAnimalsTest()
    {
        var service = new AnimalsService(new TestAnimalRepository());
        int id = 1;
        String name = "TestName";
        String description = "TestDescription";
        String category = "TestCategory";
        String area = "TestArea";
        var result = service.CreateAnimal(new Animal
        {
            IdAnimal = id,
            Name = name,
            Description = description,
            Category = category,
            Area = area
        });
        Assert.Equal(1, result);

        var _animals = service.GetAnimals();
        Assert.NotNull(_animals);
        Assert.NotEmpty(_animals);
        Assert.Equal(_animals.First().Name, name);

        Assert.Equal(_animals.First().Name, name);
        Assert.Equal(_animals.First().Description, description);
        Assert.Equal(_animals.First().Category, category);
        Assert.Equal(_animals.First().Area, area);
    }
    
    [Fact]
    public void DeleteAnimalsTest()
    {
        var service = new AnimalsService(new TestAnimalRepository());
        int id = 1;
        String name = "TestName";
        String description = "TestDescription";
        String category = "TestCategory";
        String area = "TestArea";
        var result = service.CreateAnimal(new Animal
        {
            IdAnimal = id,
            Name = name,
            Description = description,
            Category = category,
            Area = area
        });
        Assert.Equal(1, result);

        var delResult = service.DeleteAnimal(id);
        Assert.Equal(1, result);
        
        var _animals = service.GetAnimals();
        Assert.Empty(_animals);
    }

    [Fact]
    public void UpdateAnimalsTest()
    {
        var service = new AnimalsService(new TestAnimalRepository());
        int id = 1;
        String name = "TestName";
        String description = "TestDescription";
        String area = "TestArea";

        String upName = "UpdName";
        String upCategory = "UpdCategory";
        String upDescription = "UpdDescription";
        String upArea = "UpdArea";

        var result = service.CreateAnimal(new Animal
        {
            IdAnimal = id,
            Name = name,
            Description = description,
            Area = area
        });
        Assert.Equal(1, result);

        var updateResult = service.UpdateAnimal(id, new Animal
        {
            Name = upName,
            Description = upDescription,
            Category = upCategory,
            Area = upArea
        });
        Assert.Equal(1, updateResult);

        var _animal = service.GetAnimal(id);
        Assert.NotNull(_animal);
        Assert.Equal(_animal.Name, upName);
        Assert.Equal(_animal.Description, upDescription);
        Assert.Equal(_animal.Category, upCategory);
        Assert.Equal(_animal.Area, upArea);
    }
}