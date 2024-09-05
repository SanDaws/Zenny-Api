using System;
using System.Collections.Generic;

namespace Zenny_Api.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? SubscriptionTypesId { get; set; }

    public virtual SubscriptionType? SubscriptionTypes { get; set; }
}
