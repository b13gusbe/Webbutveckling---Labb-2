using System;
using System.Collections.Generic;

namespace WebbLabb2.Models;

public partial class Ordrar
{
    public int Id { get; set; }

    public int OrderNummer { get; set; }

    public string? Kund { get; set; }

    public string? Bok { get; set; }

    public int? Antal { get; set; }

    public virtual Böcker? BokNavigation { get; set; }

    public virtual Kunder? KundNavigation { get; set; }
}
