using System;
using System.Collections.Generic;

namespace Pantus.Models;

public partial class TbOrder
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public int? TableId { get; set; }

    public decimal? TotalAmount { get; set; }

    public int? OrderStatusId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual TbCustomer? Customer { get; set; }

    public virtual TbOrderStatus? OrderStatus { get; set; }

    public virtual TbTable? Table { get; set; }

    public virtual ICollection<TbInvoice> TbInvoices { get; set; } = new List<TbInvoice>();

    public virtual ICollection<TbOrderDetail> TbOrderDetails { get; set; } = new List<TbOrderDetail>();
}
