using System;
using System.Collections.Generic;

namespace Pantus.Models;

public partial class TbCustomer
{
    public int CustomerId { get; set; }

    public string? FullName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Image { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<TbOrder> TbOrders { get; set; } = new List<TbOrder>();
}
