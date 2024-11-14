using System;
using System.Collections.Generic;

namespace Pantus.Models;

public partial class TbOrderDetail
{
    public int OrderDetailId { get; set; }

    public int? OrderId { get; set; }

    public int? MenuItemId { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public decimal? Total { get; set; }

    public bool IsActive { get; set; }

    public virtual TbMenuItem? MenuItem { get; set; }

    public virtual TbOrder? Order { get; set; }
}
