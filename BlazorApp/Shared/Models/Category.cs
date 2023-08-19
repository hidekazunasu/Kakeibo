using System;
using System.Collections.Generic;

namespace shared.Models;

public partial class Category
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public int? Type { get; set; }
}
