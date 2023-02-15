using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRM.Models;
using CRM;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("[controller]")]

public class ClientController : ControllerBase
{
    public static CrmContext _context = new();
    
    private readonly JwtAuthenticationManager jwtAuthenticationManager;
  

    public ClientController(JwtAuthenticationManager jwtAuthenticationManager)
    {
        this.jwtAuthenticationManager = jwtAuthenticationManager;
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

    
    [Authorize]
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
    [HttpDelete ("{id}")]
    public Client Delete(int id)
    {
         Client dbR = _context.Clients.Find(id);
        _context.Clients.Remove(dbR);
        _context.SaveChanges();
        System.Console.WriteLine("User deleted");
        return dbR;
    }
}
