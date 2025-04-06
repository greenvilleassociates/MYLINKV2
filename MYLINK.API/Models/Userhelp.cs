using System;
using System.Collections.Generic;

namespace Enterprise.Models;

public partial class Userhelp
{
    public int? Id { get; set; }

    public string? Emplid { get; set; }

    public string? Descr { get; set; }

    public int? Severity { get; set; }

    public int? Userid { get; set; }

    public string? Email { get; set; }

    public string? Fullname { get; set; }

    public string? Bestcontactnumber { get; set; }

    public string? Replied { get; set; }

    public int? Repliedmanagerid { get; set; }

    public string? Repliedmanagerphone { get; set; }

    public string? Repliedmanageremail { get; set; }
}
