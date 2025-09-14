

using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Color
    {

        [Key]
        public int ColorId { get; set; } // Уникальный идентификатор для цвета
        public string ColorName { get; set; }
        // Изменения: навигационное свойство для отношений многие-ко-многим
        public ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();
    }
}
