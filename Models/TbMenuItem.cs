using System;
using System.Collections.Generic;

namespace Pantus.Models;

public partial class TbMenuItem
{
    public int MenuItemId { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public string? Description { get; set; }

    public int? Price { get; set; }

    public string? Image { get; set; }

    public int? CategoryId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    public int PriceSale { get; set; }

    public int Quantity { get; set; }

    public int Star { get; set; }

    public string? Detail { get; set; }

    public virtual TbMenuCategory? Category { get; set; }

    public virtual ICollection<TbMenuReview> TbMenuReviews { get; set; } = new List<TbMenuReview>();

    public virtual ICollection<TbOrderDetail> TbOrderDetails { get; set; } = new List<TbOrderDetail>();
}
