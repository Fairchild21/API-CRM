using System;
using System.Collections.Generic;

namespace CRM;

public partial class Order
{
    public int Id { get; set; }

    public string TypePresta { get; set; } = null!;

    public int IdClient { get; set; }

    public decimal? NbJours { get; set; }

    public decimal? TjmHt { get; set; }

    public decimal? Tva { get; set; }

    public string? State { get; set; }
    public string? Comment { get; set;}
    
     [System.Text.Json.Serialization.JsonIgnore]
    public virtual Client IdClientNavigation { get; set; } = null!;
    public Order()
    {

    }
    public Order(string TypePresta,int IdClient,decimal NbJours, decimal TjmHt,decimal Tva,string State, string Comment)
    {
        this.TypePresta = TypePresta;
        this.IdClient = IdClient; 
        this.NbJours = NbJours;
        this.TjmHt = TjmHt;
        this.Tva = Tva;
        this.State = State;
        this.Comment = Comment;
        // this.IdClientNavigation = client;
        // this.IdClient = client.Id;

    }
}
