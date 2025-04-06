using System;
using System.Collections.Generic;

namespace Enterprise.Models;

public partial class Region
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public int? Bu { get; set; }

    public string? Hqaddress1 { get; set; }

    public string? Hqaddress2 { get; set; }

    public string? Hqcity { get; set; }

    public string? Hqstate { get; set; }

    public string? Hqzipcode { get; set; }
}
