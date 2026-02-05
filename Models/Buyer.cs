using System;
using System.Collections.Generic;

namespace Pharmacy.Models;

public partial class Buyer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateTime? Date { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
