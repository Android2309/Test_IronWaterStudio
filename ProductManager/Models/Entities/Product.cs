using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductManager.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Необходимо название товара")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Необходимо описание")]
        public string? Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Цена должна быть > 0")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
    }
}
