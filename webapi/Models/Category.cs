using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Category
{
    public long Id { get; set; }
    public string? Name { get; set; }

    public ICollection<Transaction>? Transactions {get; set;}

}
