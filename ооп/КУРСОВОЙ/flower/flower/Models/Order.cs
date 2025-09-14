using System;
using System.Collections.Generic;

namespace flower.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public int IdUser { get; set; }

    public int TotalAmount { get; set; }

    public float TatalPrice { get; set; }

    public string OrderStatus { get; set; } = null!;

    public string DeliveryAdres { get; set; } = null!;

    public string? ReciverPhoneNumber { get; set; }

    public DateOnly DeliveryDate { get; set; }

    public string DeliveryTime { get; set; } = null!;

    public string? ReciverFio { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
