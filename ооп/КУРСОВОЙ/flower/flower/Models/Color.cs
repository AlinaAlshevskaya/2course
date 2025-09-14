using System;
using System.Collections.Generic;

namespace flower.Models;

public partial class Color
{
    public int IdColorName { get; set; }

    public string ColorName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
