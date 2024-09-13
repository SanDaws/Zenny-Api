using System;
using System.Collections.Generic;

namespace Zenny_Api.Models;

public partial class Movement
{
    public uint Id { get; set; }

    public DateTime MovementDate { get; set; }

    public int UserId { get; set; }

    public double Value { get; set; }

    public int CategoriesId { get; set; }

    public int TransactionTypesId { get; set; }
}
