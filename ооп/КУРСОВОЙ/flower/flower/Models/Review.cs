using System;
using System.Collections.Generic;

namespace flower.Models;

public partial class Review
{
    public int IdReview { get; set; }

    public int IdUser { get; set; }

    public int IdOrder { get; set; }

    public string? Text { get; set; }

    public float Rate { get; set; }

    public DateOnly Date { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
