

using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class OrderDetails
    {
        [Key]
        public int IdOrderDetail { get; set; } // Уникальный идентификатор элемента заказа

        public int OrderId { get; set; } // Идентификатор заказа

        public int ProductId { get; set; } // Идентификатор продукта

        public int Amount { get; set; } // Количество данного продукта в заказе

        // Navigation properties

        public Order Order { get; set; } // Связанный заказ

        public Product Product { get; set; } // Связанный продукт
    }
}
