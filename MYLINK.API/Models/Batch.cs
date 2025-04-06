using System;
using System.Collections.Generic;

namespace Enterprise.Models;

public partial class Batch
{
    public int Id { get; set; }

    public string? Batchname { get; set; }

    public string? Filelocationpath { get; set; }

    public int? Batchtype { get; set; }

    public int? Batchstatus { get; set; }
}
