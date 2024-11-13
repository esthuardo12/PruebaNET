using System;
using System.Collections.Generic;

namespace PruebaNET.DAL.Models;

public partial class Status
{
    public int Status1 { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
