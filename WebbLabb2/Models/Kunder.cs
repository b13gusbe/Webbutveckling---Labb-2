using System;
using System.Collections.Generic;

namespace WebbLabb2.Models;

public partial class Kunder
{
    public string Epost { get; set; } = null!;

    public string? Förnamn { get; set; }

    public string? Efternamn { get; set; }

    public string? Adress { get; set; }

    public virtual ICollection<Ordrar> Ordrars { get; } = new List<Ordrar>();
}
