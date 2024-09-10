using System;
using System.Collections.Generic;
//
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zenny_Api.Models;


[Table("users")]
public partial class User
{

    [Key]
    [Column("id")]
    public int Id { get; set; } 
    //public int Id { get; set; }

    public string Name { get; set; } = null!;

    [Column("last_name")]
    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    [Column("subscription_types_id")]
    public int? SubscriptionTypesId { get; set; }

    public virtual SubscriptionType? SubscriptionTypes { get; set; }
}
