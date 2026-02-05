using System;
using System.Collections.Generic;

namespace Pharmacy.Models;

public partial class Medicine
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int TypeId { get; set; }

    public int CategotyId { get; set; }

    public int ManufacturerId { get; set; }

    public bool Prescription { get; set; }

    public int ExpirationPeriod { get; set; }

    public decimal Dosage { get; set; }

    public int Count { get; set; }

    public int ConditionId { get; set; }

    public int UnitId { get; set; }

    public int? UnitinId { get; set; }

    public virtual ICollection<Arrival> Arrivals { get; set; } = new List<Arrival>();

    public virtual Category Categoty { get; set; } = null!;

    public virtual Condition Condition { get; set; } = null!;

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual Type Type { get; set; } = null!;

    public virtual Unit Unit { get; set; } = null!;

    public virtual Unit? Unitin { get; set; }
}
