using System;
using System.Collections.Generic;

namespace Enterprise.Models;

public partial class Usersession
{
    public int Id { get; set; }

    public int? Userid { get; set; }

    public string? Token { get; set; }

    public byte? Acknowledged { get; set; }

    public int? Actionpriority { get; set; }

    public DateTime? Sessionstart { get; set; }

    public DateTime? Sessionend { get; set; }

    public int? Sessionrecorded { get; set; }

    public string? Sessionrecordurl { get; set; }
}
