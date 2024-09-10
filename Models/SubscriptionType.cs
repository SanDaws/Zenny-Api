using System;
using System.Collections.Generic;

namespace Zenny_Api.Models;

public partial class SubscriptionType
{
    public int Id { get; set; }

    public string SubscriptionType1 { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
