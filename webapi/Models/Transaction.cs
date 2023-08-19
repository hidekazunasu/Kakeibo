using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Transaction
{
    public long Id { get; set; }

    public double? Amount { get; set; }

    public string? Date { get; set; }

    public string? Description { get; set; }

    public bool? Type {get;set;} 

    public int? PaymentMethodId {get; set;}
    public PaymentMethod? PaymentMethod {get; set;}

    public long? CategoryId { get; set; }
    public Category? Category {get; set;}

}
