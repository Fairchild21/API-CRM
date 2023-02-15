using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRM.Models;
using CRM;

[ApiController]
[Route("[controller]")]

public class OrderController : ControllerBase
{
    public static CrmContext _context = new();
    
    public static List<Client> lClients = new();
  

    public OrderController()
    {
        
    }
    [HttpGet]
    public List<Order> Get()
    {
        return _context.Orders.ToList();
    }

    [HttpGet]
    [Route("{id}")]

        public Order Get(int id)
        {
            return _context.Orders.Find(id);
        }

        [HttpPost]
        public string Post(Order tmp)
        {
            _context.Orders.Add(tmp);
            System.Console.WriteLine("order added");
            _context.SaveChanges();
            return "order added";
        }
     

        [HttpPut ("{id}")]
    
        public Order Put(int id, [FromBody] Order tmp)
        {
            Order db = _context.Orders.Find(id);
            db.TypePresta = tmp.TypePresta;
            db.IdClient = tmp.IdClient;
            db.NbJours = tmp.NbJours;
            db.Tva = tmp.Tva;
            db.State = tmp.State;
            db.Tva = tmp.Tva;
            db.Comment = tmp.Comment;
            System.Console.WriteLine("MAJ");
            _context.SaveChanges();
    
            return tmp;
        }

        [HttpDelete ("{id}")]
        public Order Delete(int id)
        {
             Order dbR = _context.Orders.Find(id);
            _context.Orders.Remove(dbR);
            _context.SaveChanges();
            System.Console.WriteLine("User deleted");
            return dbR;
        }
}
