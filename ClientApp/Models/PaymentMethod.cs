using System;
using System.Collections.Generic;

namespace webapi.Models;

public class PaymentMethod
{
    public int id {get; set;}
    public string? Method {get; set;}

    public ICollection<Transaction>? Transactions {get; set;}
}