using System;
using System.Collections.Generic;

namespace ProgramowanieProj3.Models;

public partial class Place
{
    public int IdPlac { get; set; }

    public int? IdPracownika { get; set; }

    public double? StawkaGodzinowa { get; set; }

    public double? WyplataNetto { get; set; }

    public double? WyplataBrutto { get; set; }

    public int? IloscGodzin { get; set; }

    public virtual Pracownicy? IdPracownikaNavigation { get; set; }

    public virtual ICollection<Skladki> Skladkis { get; set; } = new List<Skladki>();
}
