using System.ComponentModel.DataAnnotations;

namespace Application.Dtos;

public class CreateAndUpdateProductDto
{

    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }


    public int CategoryId { get; set; }
}
