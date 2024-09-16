using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zenny_Api.Models;


[Table("subscription_types")]
public partial class SubscriptionType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("subscription_type")]
    public string SubscriptionType1 { get; set; } = null!;

}
