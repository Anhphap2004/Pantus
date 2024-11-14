using System;
using System.Collections.Generic;

namespace Pantus.Models;

public partial class TbTable
{
    public int TableId { get; set; }

    public string? TableNumber { get; set; }

    public int? Capacity { get; set; }

    public string? Status { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<TbOrder> TbOrders { get; set; } = new List<TbOrder>();
}
