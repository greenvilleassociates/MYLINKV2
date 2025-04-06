using System;
using System.Collections.Generic;

namespace Enterprise.Models;

public partial class Resdetail
{
    public int Id { get; set; }

    public string? Descr { get; set; }

    public string? Category { get; set; }

    public string? Startdate { get; set; }

    public string? Enddate { get; set; }

    public string? Certauthority { get; set; }

    public string? Status { get; set; }

    public int? Emplid { get; set; }

    public string? Location { get; set; }

    public int? Userid { get; set; }

    public byte? Employee { get; set; }

    public string? Fullname { get; set; }
}
