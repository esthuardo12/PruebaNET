using System;
using System.Collections.Generic;

namespace PruebaNET.DAL.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public int Status { get; set; }

    public int? Stock { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public virtual Status StatusNavigation { get; set; } = null!;
}
