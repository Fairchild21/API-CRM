using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace CRM;

public class JwtAuthenticationManager
{
    private readonly string key;
    private readonly IDictionary<string, string> users = new Dictionary<string, string>()
    {{"test", "password"}, {"test1", "pwd"}};

    public JwtAuthenticationManager(string key)
    {
        this.key = key;
    }

    public string Authenticate(string username, string password)
    {
        if(!users.Any(u => u.Key == username && u.Value == password))
        {return null;}
        
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.ASCII.GetBytes(key);

        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            
            {
                new Claim(ClaimTypes.Name, username)
            }),

            Expires = DateTime.Now.AddHours(1),
            SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(tokenKey),
            SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}