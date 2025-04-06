using System;
using System.Collections.Generic;

namespace Enterprise.Models;

public partial class Company
{
    public int Id { get; set; }

    public string? Companyname { get; set; }

    public string? Dynamicsid { get; set; }

    public string? Ncralohaid { get; set; }

    public string? Oracleid { get; set; }

    public string? CertAuthority { get; set; }
}
