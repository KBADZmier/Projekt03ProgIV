using System;
using System.Collections.Generic;

namespace ProgramowanieProj3.Models;

public partial class Pracownicy
{
    public int IdPracownika { get; set; }

    public string? Imie { get; set; }

    public string? Nazwisko { get; set; }

    public string? Plec { get; set; }

    public string? Adres { get; set; }

    public string? NrKonta { get; set; }

    public string? TelefonKontaktowy { get; set; }

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();
}
