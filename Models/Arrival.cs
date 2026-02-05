using System;
using System.Collections.Generic;

namespace Pharmacy.Models;

public partial class Arrival
{
    public int Id { get; set; }

    public int? MedicineId { get; set; }

    public int? SupplierId { get; set; }

    public int? OrderNumber { get; set; }

    public DateTime? Date { get; set; }

    public decimal? Price { get; set; }

    public decimal? PricePackage { get; set; }

    public virtual Medicine? Medicine { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual Supplier? Supplier { get; set; }
}
