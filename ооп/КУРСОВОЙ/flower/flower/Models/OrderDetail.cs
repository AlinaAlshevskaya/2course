using System;
using System.Collections.Generic;

namespace flower.Models;

public partial class OrderDetail
{
    public int IdOrder { get; set; }

    public int IdProduct { get; set; }

    public int Amount { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
