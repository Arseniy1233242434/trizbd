using System;
using System.Collections.Generic;

namespace Pharmacy.Models;

public partial class Unit
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Medicine> MedicineUnitins { get; set; } = new List<Medicine>();

    public virtual ICollection<Medicine> MedicineUnits { get; set; } = new List<Medicine>();
}
