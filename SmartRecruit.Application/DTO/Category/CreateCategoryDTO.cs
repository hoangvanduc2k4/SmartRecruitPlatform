using System.ComponentModel.DataAnnotations;

namespace SmartRecruit.Application.DTO.Category
{
    public class CreateCategoryDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
