using System.ComponentModel.DataAnnotations;

namespace SmartRecruit.Application.DTO.Category
{
    public class UpdateCategoryDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}