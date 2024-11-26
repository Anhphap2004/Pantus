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

    public string? FullName { get; set; }
    public int? Phone { get; set; }
    public int? People { get; set; }
    public DateTime? CreateDate { get; set; }
    public string? Hour {  get; set; }

    public virtual ICollection<TbOrder> TbOrders { get; set; } = new List<TbOrder>();
}
