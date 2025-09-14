using System.ComponentModel.DataAnnotations;


namespace Models
{
    public class Order
    {
        [Key]
        public int OrderId {  get; set; }

        public int UserId { get; set; }
        public int TotalAmount {  get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public User User { get; set; }
        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>(); // Коллекция деталей заказа


        public Order(int TotalAmount, decimal TotalPrice,string OrderStatus)
        {
            this.TotalAmount = TotalAmount;
            this.TotalPrice = TotalPrice;
            this.OrderStatus = OrderStatus;

        }

        public Order()
        {

        }
    }
}
