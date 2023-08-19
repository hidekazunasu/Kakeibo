using System;
using System.Collections.Generic;

namespace shared.Models;

public partial class Account
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public double? Balance { get; set; }
}
