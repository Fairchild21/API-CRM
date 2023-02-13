using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRM.Models;
using CRM;

[ApiController]
[Route("[controller]")]

public class ClientController : ControllerBase
{
    public static CrmContext _context = new();
    
    public static List<Client> lClients = new();
  

    public ClientController()
    {
        
    }
        [HttpGet]
        public List<Client> Get()
        {
            return _context.Clients.ToList();
        }

        [HttpGet]
        [Route("{id}")]

        public Client Get(int id)
        {
            return _context.Clients.Find(id);
        }

        [HttpPost]
        public string Post(Client tmp)
        {
            _context.Clients.Add(tmp);
            System.Console.WriteLine("client added");
            _context.SaveChanges();
            return "client added";
        }
     

        [HttpPut ("{id}")]
    
        public Client Put(int id, [FromBody] Client tmp)
        {
            Client db = _context.Clients.Find(id);
            db.Name = tmp.Name;
            db.State = tmp.State;
            db.Tva = tmp.Tva;
            db.Comment = tmp.Comment;
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
