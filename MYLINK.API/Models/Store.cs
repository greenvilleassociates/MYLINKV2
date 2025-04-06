using System;
using System.Collections.Generic;

namespace Enterprise.Models;

public partial class Store
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public int? Regionid { get; set; }

    public int? Bu { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zipcode { get; set; }
}
