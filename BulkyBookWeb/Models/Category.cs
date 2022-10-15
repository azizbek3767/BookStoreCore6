using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Порядковый номер")]
        [Range(1, 100, ErrorMessage = "Порядковый номер должен быть от 1 до 100.")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
