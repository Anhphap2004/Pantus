using System;
using System.Collections.Generic;

namespace Pantus.Models;

public partial class TbMenuReview
{
    public int MenuReviewId { get; set; }

    public int MenuItemId { get; set; }

    public string? Name { get; set; }

    public int? Phone { get; set; }

    public int? Rating { get; set; }

    public string? Detail { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? Image { get; set; }

    public bool IsActive { get; set; }

    public virtual TbMenuItem MenuItem { get; set; } = null!;
}
