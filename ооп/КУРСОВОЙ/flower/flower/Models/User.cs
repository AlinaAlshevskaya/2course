using System;
using System.Collections.Generic;

namespace flower.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string Name { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public int PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string Password { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public string? ImagePath { get; set; }

    public string? Adres { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
