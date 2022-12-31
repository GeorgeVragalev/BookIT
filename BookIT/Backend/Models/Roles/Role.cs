using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Roles;

public class Role
{
    [Required]
    public string Name { get; set; }
}