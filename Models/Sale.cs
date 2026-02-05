using System;
using System.Collections.Generic;

namespace Pharmacy.Models;

public partial class Sale
{
    public int Id { get; set; }

    public int OrderNumber { get; set; }

    public int ArrivalId { get; set; }

    public int Count { get; set; }

    public int SellerId { get; set; }

    public DateTime Date { get; set; }

    public int? BuyerId { get; set; }

    public decimal Price { get; set; }

    public bool Payment { get; set; }

    public virtual Arrival Arrival { get; set; } = null!;

    public virtual Buyer? Buyer { get; set; }

    public virtual Seller Seller { get; set; } = null!;
}
