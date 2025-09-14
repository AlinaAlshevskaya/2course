using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; } // Уникальный идентификатор для категории
        public string CategoryName { get; set; }
        // Изменения: навигационное свойство для отношений многие-ко-многим
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }
}
