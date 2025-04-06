using System;
using System.Collections.Generic;

namespace Enterprise.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public byte? Employee { get; set; }

    public string? Employeeid { get; set; }

    public string? Microsoftid { get; set; }

    public string? Ncrid { get; set; }

    public string? Oracleid { get; set; }

    public string? Azureid { get; set; }

    public string? Plainpassword { get; set; }

    public string? Hashedpassword { get; set; }

    public int? Passwordtype { get; set; }

    public int? Jid { get; set; }

    public string? Profileurl { get; set; }

    public string? Role { get; set; }

    public string? Fullname { get; set; }

    public int? Companyid { get; set; }
    public string? ResetToken { get; set; }
    public DateTime? ResetTokenExpiration { get; set; }
}
