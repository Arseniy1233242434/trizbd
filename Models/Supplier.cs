using System;
using System.Collections.Generic;

namespace Pharmacy.Models;

public partial class Supplier
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ContactPerson { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Arrival> Arrivals { get; set; } = new List<Arrival>();
}
