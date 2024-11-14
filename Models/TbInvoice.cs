using System;
using System.Collections.Generic;

namespace Pantus.Models;

public partial class TbInvoice
{
    public int InvoiceId { get; set; }

    public int? OrderId { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? PaymentMethod { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual TbOrder? Order { get; set; }
}
