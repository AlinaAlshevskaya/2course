using System;
using System.Collections.Generic;

namespace flower.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public string Name { get; set; } = null!;

    public string? Discription { get; set; }

    public int IdCategory { get; set; }

    public int IdColorName { get; set; }

    public int? Amount { get; set; }

    public float? Rating { get; set; }

    public int IsAvailable { get; set; }

    public float Price { get; set; }

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual Color IdColorNameNavigation { get; set; } = null!;
}
