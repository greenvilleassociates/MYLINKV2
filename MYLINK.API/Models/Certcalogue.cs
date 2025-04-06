using System;
using System.Collections.Generic;

namespace Enterprise.Models;

public partial class Certcalogue
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public int? Certtype { get; set; }

    public string? Vendor { get; set; }

    public string? Version { get; set; }

    public byte? Endoflife { get; set; }

    public string? Enddate { get; set; }

    public int? Trainingid { get; set; }

    public string? Precursortraining1 { get; set; }

    public string? Precursortraining2 { get; set; }

    public string? Sku { get; set; }

    public double? Certlistcost { get; set; }

    public double? Certlistdiscountstd { get; set; }

    public double? Certlistdiscountvprate { get; set; }

    public string? Certlevel { get; set; }
}
