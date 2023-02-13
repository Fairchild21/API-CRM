using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class Order
{
    public int Id { get; set; }

    public int IdClient { get; set; }

    public string TypePresta { get; set; } = null!;

    public string Client { get; set; } = null!;

    public decimal? NbJours { get; set; }

    public decimal TjmHt { get; set; }

    public decimal? Tva { get; set; }

    public string State { get; set; } = null!;

    public string Comment { get; set; } = null!;

    public virtual Client IdClientNavigation { get; set; } = null!;
}
