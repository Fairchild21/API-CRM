using System;
using System.Collections.Generic;

namespace CRM.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string ConfirmedPassword { get; set; } = null!;

    public string Grants { get; set; } = null!;
}
