using System;
using System.Collections.Generic;

namespace Pharmacy.Models;

public partial class Manufacturer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();
}
