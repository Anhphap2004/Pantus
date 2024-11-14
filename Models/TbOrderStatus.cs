using System;
using System.Collections.Generic;

namespace Pantus.Models;

public partial class TbOrderStatus
{
    public int OrderStatusId { get; set; }

    public string? StatusName { get; set; }

    public virtual ICollection<TbOrder> TbOrders { get; set; } = new List<TbOrder>();
}
