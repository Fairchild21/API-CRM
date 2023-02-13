using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRM.Models;
using CRM;

[ApiController]
[Route("[controller]")]

public class ApiController : ControllerBase
{
    public static CrmContext _context = new();
    public static List<User> sUser = new();
  

    public ApiController()
    {
        
    }
        [HttpGet]
        public List<User> Get()
        {
            return _context.Users.ToList();
        }

        [HttpGet]
        [Route("{id}")]

        public User Get(int id)
        {
            return _context.Users.Find(id);
        }

        // [HttpPost]
        // public string Post(User tmp)
        // {
        //     _context.Users.Add(tmp);
        //     _context.SaveChanges();
        //     System.Console.WriteLine("product added");
        //     return "Prodcut added";
        // }

        // [HttpPut]
        // public Utilisateur Put(int id, [FromBody] User tmp)
        // {
        //     Utilisateur db = _context.Users.Find(tmp.IdUtilisateur);
        //     db = tmp;
        //     // _context.Utilisateur.Update(tmp);
        //     _context.SaveChanges();
        //     using (var transaction = _context.Database.BeginTransaction())
        //     {
        //         try
        //         {
        //             System.Console.WriteLine("Update saved");
        //             _context.SaveChanges();
        //             transaction.Commit();
        //         }
        //         catch (Exception)
        //         {
        //             transaction.Rollback();
        //         }
        //     }
    
        //     return tmp;
        // }

        // [HttpDelete ("{id}")]
        // public string Delete(int id)
        // {
        //     _context.Utilisateur.Remove(sUser[id -1]);
        //     _context.SaveChanges();
        //     // list.Remove(list[id -1]);
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