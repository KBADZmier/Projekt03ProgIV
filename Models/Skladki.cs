using System;
using System.Collections.Generic;

namespace ProgramowanieProj3.Models;

public partial class Skladki
{
    public int IdSkladki { get; set; }

    public int? IdPlace { get; set; }

    public string? Rodzaj { get; set; }

    public double? Stawka { get; set; }

    public virtual Place? IdPlaceNavigation { get; set; }
}
