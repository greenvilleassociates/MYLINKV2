using System;
using System.Collections.Generic;

namespace Enterprise.Models;

public partial class Manager
{
    public int Id { get; set; }

    public string? Fullname { get; set; }

    public int? Emplid { get; set; }

    public int? Userid { get; set; }

    public int? Storeid { get; set; }

    public string? Saddress1 { get; set; }

    public string? Saddress2 { get; set; }

    public string? Scity { get; set; }

    public string? Sstate { get; set; }

    public string? Szipcode { get; set; }

    public int? Companyid { get; set; }
}
