using System;
using System.Collections.Generic;

namespace Zenny_Api.Models;

public partial class Movement
{
    public int Id { get; set; }

    public DateOnly MovementDate { get; set; }

    public int UserId { get; set; }

    public double Value { get; set; }

    public int? TransactionTypesId { get; set; }

    public int? CategoriesId { get; set; }

    public virtual Category? Categories { get; set; }

    public virtual TransactionType? TransactionTypes { get; set; }
}
