using System;
using System.Collections.Generic;

namespace shared.Models;

public partial class Transaction
{
    public long Id { get; set; }

    public long? CategoryId { get; set; }

    public double? Amount { get; set; }

    public string? Date { get; set; }

    public string? Description { get; set; }
}
