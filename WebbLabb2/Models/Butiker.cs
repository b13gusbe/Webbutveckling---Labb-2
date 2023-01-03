using System;
using System.Collections.Generic;

namespace WebbLabb2.Models;

public partial class Butiker
{
    public int Id { get; set; }

    public string? Butiksnamn { get; set; }

    public string? Adress { get; set; }

    public virtual ICollection<LagerSaldo> LagerSaldos { get; } = new List<LagerSaldo>();
}
