using System;
using System.Collections.Generic;

namespace Enterprise.Models;

public partial class Userlog
{
    public int Id { get; set; }

    public string? Descr { get; set; }

    public int? Emplid { get; set; }

    public string? Fullname { get; set; }

    public string? Logdate { get; set; }

    public int? Secpriority { get; set; }

    public string? Noccomments { get; set; }

    public int? NocOpId { get; set; }

    public int? EscalationId { get; set; }

    public string? Triagecasenumber { get; set; }

    public int? Userid { get; set; }

    public string? Role { get; set; }
}
