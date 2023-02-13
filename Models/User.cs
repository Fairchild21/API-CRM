using System;
using System.Collections.Generic;

namespace CRM;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Confirmedpassword { get; set; } = null!;

    public string Grants { get; set; } = null!;
    public User()
    {

    }
    public User(int Id, string Email,string Password,string FirstName,string LastName,string Confirmedpassword,string Grants)
    {
        this.Email= Email;
        this.Password = Password;
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Confirmedpassword = Confirmedpassword;
        this.Grants = Grants;
    }
}
