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
            System.Console.WriteLine("client added");
            _context.SaveChanges();
            return "client added";
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
            System.Console.WriteLine("MAJ");
            _context.SaveChanges();
    
            return tmp;
        }

        // [HttpDelete ("{id}")]
        // public string Delete(int id)
        // {
        //     _context.Users.Remove(sUser[id -1]);
        //     _context.SaveChanges();
        //     System.Console.WriteLine("User deleted");
        //     return "User removed";
        // }

    // [HttpDelete ("{id}")]
    // public string Delete(int id)
    // {
    //     using (var transaction = _context.Database.BeginTransaction())
    //     {
    //         try
    //         {
    //             Utilisateur db = _context.Utilisateur.Find(id);
    //             _context.Utilisateur.Remove(db);
    //             _context.SaveChanges();
    //             transaction.Commit();
    //             System.Console.WriteLine("User deleted");
    //             return "User deleted";
    //         }
    //             catch (Exception)
    //         {
    //             transaction.Rollback();
    //             return "Error deleting user";
    //         }
    //     }
    // }
}
