using System;
using System.Collections.Generic;

namespace Pharmacy.Models;

public partial class Seller
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsAdmin { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
