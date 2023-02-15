using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CRM.Models;
using CRM;

[ApiController]
[Route("[controller]")]

public class UserController : ControllerBase
{
    public static CrmContext _context = new();
    public static List<User> sUser = new();
    private readonly JwtAuthenticationManager jwtAuthenticationManager;
    
  

    public UserController(JwtAuthenticationManager jwtAuthenticationManager)
    {
        this.jwtAuthenticationManager = jwtAuthenticationManager;
    }
        [Authorize]
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

        [AllowAnonymous]
        [HttpPost("Authorize")]
        public string PostAuthenticate(User tmp)
        {
            var token = jwtAuthenticationManager.Authenticate(tmp.FirstName, tmp.Password);
            if(token == null)
            {
                return "Unauthorized";
            }
            return (token);
        }

        [Authorize]
        [HttpPost]

        public string Post(User tmp)
        {

            _context.Users.Add(tmp);
            System.Console.WriteLine("user added");
            _context.SaveChanges();
            return "user added";
        }
     

        [HttpPut ("{id}")]
    
        public User Put(int id, [FromBody] User tmp)
        {
            User db = _context.Users.Find(id);
            db.Email = tmp.Email;
            db.FirstName = tmp.FirstName;
            db.LastName = tmp.LastName;
            db.Password = tmp.Password;
            db.Confirmedpassword = tmp.Confirmedpassword;
            db.Grants = tmp.Grants;
            System.Console.WriteLine("MAJ");
            _context.SaveChanges();
            // using (var transaction = _context.Database.BeginTransaction())
            // {
            //     try
            //     {
            //         System.Console.WriteLine("Update saved");
            //         _context.SaveChanges();
            //         transaction.Commit();
            //     }
            //     catch (Exception)
            //     {
            //         System.Console.WriteLine("Rollback");
            //         transaction.Rollback();
            //     }
            // }
    
            return tmp;
        }

        [HttpDelete ("{id}")]
        public User Delete(int id)
        {
             User dbR = _context.Users.Find(id);
            _context.Users.Remove(dbR);
            _context.SaveChanges();
            System.Console.WriteLine("User deleted");
            return dbR;
        }
}
