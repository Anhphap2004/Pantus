using System;
using System.Collections.Generic;

namespace Pantus.Models;

public partial class TbMenuCategory
{
    public int CategoryId { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<TbMenuItem> TbMenuItems { get; set; } = new List<TbMenuItem>();
}
