using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class Client
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? State { get; set; }

    public decimal Tva { get; set; }

    public int TotalCaHt { get; set; }

    public string Comment { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
