using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProgramowanieProj3.Models;

public partial class ProgProj3Context : DbContext
{
    public ProgProj3Context()
    {
    }

    public ProgProj3Context(DbContextOptions<ProgProj3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Place> Place{ get; set; }

    public virtual DbSet<Pracownicy> Pracownik{ get; set; }

    public virtual DbSet<Skladki> Skladki { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ProgProj3;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Place>(entity =>
        {
            entity.HasKey(e => e.IdPlac);

            entity.ToTable("Place");

            entity.Property(e => e.IdPlac)
                .ValueGeneratedNever()
                .HasColumnName("ID_Plac");
            entity.Property(e => e.IdPracownika).HasColumnName("ID_Pracownika");
            entity.Property(e => e.IloscGodzin).HasColumnName("Ilosc_Godzin");
            entity.Property(e => e.StawkaGodzinowa).HasColumnName("Stawka_Godzinowa");
            entity.Property(e => e.WyplataBrutto).HasColumnName("Wyplata_Brutto");
            entity.Property(e => e.WyplataNetto).HasColumnName("Wyplata_Netto");

            entity.HasOne(d => d.IdPracownikaNavigation).WithMany(p => p.Places)
                .HasForeignKey(d => d.IdPracownika)
                .HasConstraintName("FK_Place_Pracownicy");
        });

        modelBuilder.Entity<Pracownicy>(entity =>
        {
            entity.HasKey(e => e.IdPracownika);

            entity.ToTable("Pracownicy");

            entity.Property(e => e.IdPracownika)
                .ValueGeneratedNever()
                .HasColumnName("ID_Pracownika");
            entity.Property(e => e.Adres).HasMaxLength(50);
            entity.Property(e => e.Imie).HasMaxLength(50);
            entity.Property(e => e.Nazwisko).HasMaxLength(50);
            entity.Property(e => e.NrKonta)
                .HasMaxLength(50)
                .HasColumnName("Nr_Konta");
            entity.Property(e => e.Plec).HasMaxLength(50);
            entity.Property(e => e.TelefonKontaktowy)
                .HasMaxLength(50)
                .HasColumnName("Telefon_Kontaktowy");
        });

        modelBuilder.Entity<Skladki>(entity =>
        {
            entity.HasKey(e => e.IdSkladki);

            entity.ToTable("Skladki");

            entity.Property(e => e.IdSkladki)
                .ValueGeneratedNever()
                .HasColumnName("ID_Skladki");
            entity.Property(e => e.IdPlace).HasColumnName("ID_Place");
            entity.Property(e => e.Rodzaj).HasMaxLength(50);

            entity.HasOne(d => d.IdPlaceNavigation).WithMany(p => p.Skladkis)
                .HasForeignKey(d => d.IdPlace)
                .HasConstraintName("FK_Skladki_Place");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
