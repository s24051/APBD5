using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace AnimalWebService.Models;

public class Animal
{
    public int IdAnimal { get; set; }
    
    [Required] 
    [MaxLength(200)] 
    public String Name { get; set; }
    
    [Required] 
    [MaxLength(200)] 
    public String Description { get; set; }
    
    [MaxLength(200)] 
    public String Category { get; set; }
    
    [Required]
    [MaxLength(200)]
    public String Area { get; set; }
}