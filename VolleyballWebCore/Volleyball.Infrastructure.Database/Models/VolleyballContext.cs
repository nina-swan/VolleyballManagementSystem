using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Volleyball.Infrastructure.Database.Models;

public partial class VolleyballContext : DbContext
{
    public VolleyballContext()
    {
    }

    public VolleyballContext(DbContextOptions<VolleyballContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artykul> Artykuls { get; set; }

   

    public virtual DbSet<Druzyna> Druzynas { get; set; }

    public virtual DbSet<DruzynaZwodnik> DruzynaZwodniks { get; set; }

    public virtual DbSet<Kategorium> Kategoria { get; set; }

    public virtual DbSet<Kolejka> Kolejkas { get; set; }

    public virtual DbSet<Komentarz> Komentarzs { get; set; }

    public virtual DbSet<Liga> Ligas { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<LogPersonalny> LogPersonalnies { get; set; }

    public virtual DbSet<Mecz> Meczs { get; set; }

    public virtual DbSet<MiejsceKomentarza> MiejsceKomentarzas { get; set; }



    public virtual DbSet<ObiektSportowy> ObiektSportowies { get; set; }

    public virtual DbSet<Pozycja> Pozycjas { get; set; }

    public virtual DbSet<Program> Programs { get; set; }

    public virtual DbSet<PrywatneWiadomosci> PrywatneWiadomoscis { get; set; }

    public virtual DbSet<Sezon> Sezons { get; set; }

    public virtual DbSet<StatystykiDruzyny> StatystykiDruzynies { get; set; }

    public virtual DbSet<Temat> Temats { get; set; }

    public virtual DbSet<Uzytkownik> Uzytkowniks { get; set; }

 

    public virtual DbSet<WynikTypowany> WynikTypowanies { get; set; }

    public virtual DbSet<Zaproszenie> Zaproszenies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=VolleyballDatabaseOld");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("tomasz1_ligasiatkowki");

        modelBuilder.Entity<Artykul>(entity =>
        {
            entity.HasKey(e => e.IdArtykulu);

            entity.ToTable("Artykul", "dbo");

            entity.Property(e => e.IdArtykulu).HasColumnName("idArtykulu");
            entity.Property(e => e.Aktywny)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("aktywny");
            entity.Property(e => e.DataUtworzenia)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dataUtworzenia");
            entity.Property(e => e.IdAutora).HasColumnName("idAutora");
            entity.Property(e => e.Tresc)
                .HasColumnType("text")
                .HasColumnName("tresc");
            entity.Property(e => e.Tytul)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tytul");
            entity.Property(e => e.Zdjecie)
                .HasColumnType("image")
                .HasColumnName("zdjecie");

            entity.HasOne(d => d.IdAutoraNavigation).WithMany(p => p.Artykuls)
                .HasForeignKey(d => d.IdAutora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Artykul_Uzytkownik");
        });

      
        modelBuilder.Entity<Druzyna>(entity =>
        {
            entity.HasKey(e => e.IdDruzyny);

            entity.ToTable("Druzyna", "dbo");

            entity.HasIndex(e => e.IdKapitana, "IX_Druzyna").IsUnique();

            entity.HasIndex(e => e.Nazwa, "nazwa").IsUnique();

            entity.Property(e => e.IdDruzyny).HasColumnName("idDruzyny");
            entity.Property(e => e.DataUtworzenia)
                .HasColumnType("datetime")
                .HasColumnName("dataUtworzenia");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdKapitana).HasColumnName("idKapitana");
            entity.Property(e => e.IdLigi).HasColumnName("idLigi");
            entity.Property(e => e.IleZmian).HasColumnName("ileZmian");
            entity.Property(e => e.KorekcjaPunktow).HasColumnName("korekcjaPunktow");
            entity.Property(e => e.Logo)
                .HasColumnType("image")
                .HasColumnName("logo");
            entity.Property(e => e.LogoHeight).HasColumnName("logoHeight");
            entity.Property(e => e.LogoWidth).HasColumnName("logoWidth");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nazwa");
            entity.Property(e => e.OpisDruzyny)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("opisDruzyny");
            entity.Property(e => e.StronaWww)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("stronaWWW");
            entity.Property(e => e.Telefon)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("telefon");
            entity.Property(e => e.Zaakceptowana).HasColumnName("zaakceptowana");
            entity.Property(e => e.Zdjecie)
                .HasColumnType("image")
                .HasColumnName("zdjecie");
            entity.Property(e => e.ZdjecieHeight).HasColumnName("zdjecieHeight");
            entity.Property(e => e.ZdjecieWidth).HasColumnName("zdjecieWidth");
            entity.Property(e => e.Zgloszona)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("zgloszona");

            entity.HasOne(d => d.IdKapitanaNavigation).WithOne(p => p.Druzyna)
                .HasForeignKey<Druzyna>(d => d.IdKapitana)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Druzyna_Uzytkownik");

            entity.HasOne(d => d.IdLigiNavigation).WithMany(p => p.Druzynas)
                .HasForeignKey(d => d.IdLigi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Druzyna_Liga");
        });

        modelBuilder.Entity<DruzynaZwodnik>(entity =>
        {
            entity.HasKey(e => e.IdDruzynyZawodnika);

            entity.ToTable("DruzynaZwodnik", "dbo");

            entity.Property(e => e.IdDruzynyZawodnika).HasColumnName("idDruzynyZawodnika");
            entity.Property(e => e.DataDolaczenia)
                .HasColumnType("datetime")
                .HasColumnName("dataDolaczenia");
            entity.Property(e => e.IdDruzyny).HasColumnName("idDruzyny");
            entity.Property(e => e.IdZawodnika).HasColumnName("idZawodnika");

            entity.HasOne(d => d.IdDruzynyNavigation).WithMany(p => p.DruzynaZwodniks)
                .HasForeignKey(d => d.IdDruzyny)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DruzynaZwodnik_Druzyna");

            entity.HasOne(d => d.IdZawodnikaNavigation).WithMany(p => p.DruzynaZwodniks)
                .HasForeignKey(d => d.IdZawodnika)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DruzynaZwodnik_Uzytkownik");
        });

        modelBuilder.Entity<Kategorium>(entity =>
        {
            entity.HasKey(e => e.IdKategorii);

            entity.ToTable("Kategoria", "dbo");

            entity.Property(e => e.IdKategorii).HasColumnName("idKategorii");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nazwa");
        });

        modelBuilder.Entity<Kolejka>(entity =>
        {
            entity.HasKey(e => e.IdKolejki);

            entity.ToTable("Kolejka", "dbo");

            entity.Property(e => e.IdKolejki).HasColumnName("idKolejki");
            entity.Property(e => e.IdSezonu).HasColumnName("idSezonu");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nazwa");

            entity.HasOne(d => d.IdSezonuNavigation).WithMany(p => p.Kolejkas)
                .HasForeignKey(d => d.IdSezonu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Kolejka_Sezon");
        });

        modelBuilder.Entity<Komentarz>(entity =>
        {
            entity.HasKey(e => e.IdKomentarza);

            entity.ToTable("Komentarz", "dbo");

            entity.Property(e => e.IdKomentarza).HasColumnName("idKomentarza");
            entity.Property(e => e.Aktywny).HasColumnName("aktywny");
            entity.Property(e => e.DataUtworzenia)
                .HasColumnType("datetime")
                .HasColumnName("dataUtworzenia");
            entity.Property(e => e.IdAutora).HasColumnName("idAutora");
            entity.Property(e => e.IdMiejscaKomentarza)
                .HasDefaultValueSql("((1))")
                .HasColumnName("idMiejscaKomentarza");
            entity.Property(e => e.IdTresci).HasColumnName("idTresci");
            entity.Property(e => e.Tresc)
                .HasMaxLength(3000)
                .IsUnicode(false)
                .HasColumnName("tresc");

            entity.HasOne(d => d.IdAutoraNavigation).WithMany(p => p.Komentarzs)
                .HasForeignKey(d => d.IdAutora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Komentarz_Uzytkownik");

            entity.HasOne(d => d.IdMiejscaKomentarzaNavigation).WithMany(p => p.Komentarzs)
                .HasForeignKey(d => d.IdMiejscaKomentarza)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Komentarz_MiejsceKomentarza");
        });

        modelBuilder.Entity<Liga>(entity =>
        {
            entity.HasKey(e => e.IdLigi);

            entity.ToTable("Liga", "dbo");

            entity.HasIndex(e => e.Nazwa, "IX_Liga").IsUnique();

            entity.Property(e => e.IdLigi).HasColumnName("idLigi");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nazwa");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.IdLogu);

            entity.ToTable("Log", "dbo");

            entity.Property(e => e.IdLogu).HasColumnName("idLogu");
            entity.Property(e => e.Admin).HasColumnName("admin");
            entity.Property(e => e.Data)
                .HasColumnType("datetime")
                .HasColumnName("data");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("link");
            entity.Property(e => e.Opis)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("opis");
        });

        modelBuilder.Entity<LogPersonalny>(entity =>
        {
            entity.HasKey(e => e.IdPersonLogu);

            entity.ToTable("LogPersonalny", "dbo");

            entity.Property(e => e.IdPersonLogu).HasColumnName("idPersonLogu");
            entity.Property(e => e.IdLogu).HasColumnName("idLogu");
            entity.Property(e => e.IdUzytkownika).HasColumnName("idUzytkownika");

            entity.HasOne(d => d.IdLoguNavigation).WithMany(p => p.LogPersonalnies)
                .HasForeignKey(d => d.IdLogu)
                .HasConstraintName("FK_LogPersonalny_Log");

            entity.HasOne(d => d.IdUzytkownikaNavigation).WithMany(p => p.LogPersonalnies)
                .HasForeignKey(d => d.IdUzytkownika)
                .HasConstraintName("FK_LogPersonalny_Uzytkownik");
        });

        modelBuilder.Entity<Mecz>(entity =>
        {
            entity.HasKey(e => e.IdMeczu);

            entity.ToTable("Mecz", "dbo");

            entity.Property(e => e.IdMeczu).HasColumnName("idMeczu");
            entity.Property(e => e.DataUtworzenia)
                .HasColumnType("datetime")
                .HasColumnName("dataUtworzenia");
            entity.Property(e => e.IdDruzyny1).HasColumnName("idDruzyny1");
            entity.Property(e => e.IdDruzyny2).HasColumnName("idDruzyny2");
            entity.Property(e => e.IdKolejki).HasColumnName("idKolejki");
            entity.Property(e => e.IdLigi).HasColumnName("idLigi");
            entity.Property(e => e.IdMiejsca).HasColumnName("idMiejsca");
            entity.Property(e => e.IdMvp)
                .HasDefaultValueSql("((39))")
                .HasColumnName("idMVP");
            entity.Property(e => e.IdSedziego).HasColumnName("idSedziego");
            entity.Property(e => e.InfoOmeczu)
                .HasMaxLength(3000)
                .IsUnicode(false)
                .HasColumnName("infoOMeczu");
            entity.Property(e => e.LigaMeczu)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ligaMeczu");
            entity.Property(e => e.NazwaNieznanegoSedziego)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nazwaNieznanegoSedziego");
            entity.Property(e => e.Sektor).HasColumnName("sektor");
            entity.Property(e => e.Termin)
                .HasColumnType("datetime")
                .HasColumnName("termin");
            entity.Property(e => e.W1s1).HasColumnName("w1s1");
            entity.Property(e => e.W1s2).HasColumnName("w1s2");
            entity.Property(e => e.W1s3).HasColumnName("w1s3");
            entity.Property(e => e.W1s4).HasColumnName("w1s4");
            entity.Property(e => e.W1s5).HasColumnName("w1s5");
            entity.Property(e => e.W2s1).HasColumnName("w2s1");
            entity.Property(e => e.W2s2).HasColumnName("w2s2");
            entity.Property(e => e.W2s3).HasColumnName("w2s3");
            entity.Property(e => e.W2s4).HasColumnName("w2s4");
            entity.Property(e => e.W2s5).HasColumnName("w2s5");
            entity.Property(e => e.WynikDruzyny1).HasColumnName("wynikDruzyny1");
            entity.Property(e => e.WynikDruzyny2).HasColumnName("wynikDruzyny2");

            entity.HasOne(d => d.IdDruzyny1Navigation).WithMany(p => p.MeczIdDruzyny1Navigations)
                .HasForeignKey(d => d.IdDruzyny1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mecz_Druzyna");

            entity.HasOne(d => d.IdDruzyny2Navigation).WithMany(p => p.MeczIdDruzyny2Navigations)
                .HasForeignKey(d => d.IdDruzyny2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mecz_Druzyna1");

            entity.HasOne(d => d.IdKolejkiNavigation).WithMany(p => p.Meczs)
                .HasForeignKey(d => d.IdKolejki)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mecz_Kolejka");

            entity.HasOne(d => d.IdLigiNavigation).WithMany(p => p.Meczs)
                .HasForeignKey(d => d.IdLigi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mecz_Liga");

            entity.HasOne(d => d.IdMiejscaNavigation).WithMany(p => p.Meczs)
                .HasForeignKey(d => d.IdMiejsca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mecz_ObiektSportowy");

            entity.HasOne(d => d.IdMvpNavigation).WithMany(p => p.MeczIdMvpNavigations)
                .HasForeignKey(d => d.IdMvp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mecz_Uzytkownik1");

            entity.HasOne(d => d.IdSedziegoNavigation).WithMany(p => p.MeczIdSedziegoNavigations)
                .HasForeignKey(d => d.IdSedziego)
                .HasConstraintName("FK_Mecz_Uzytkownik");
        });

        modelBuilder.Entity<MiejsceKomentarza>(entity =>
        {
            entity.HasKey(e => e.IdMiejscaKomentarza);

            entity.ToTable("MiejsceKomentarza", "dbo");

            entity.Property(e => e.IdMiejscaKomentarza).HasColumnName("idMiejscaKomentarza");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nazwa");
        });

       

        modelBuilder.Entity<ObiektSportowy>(entity =>
        {
            entity.HasKey(e => e.IdObiektu);

            entity.ToTable("ObiektSportowy", "dbo");

            entity.Property(e => e.IdObiektu).HasColumnName("idObiektu");
            entity.Property(e => e.InfoDodatkowe)
                .HasMaxLength(3000)
                .IsUnicode(false)
                .HasColumnName("infoDodatkowe");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nazwa");
        });

        modelBuilder.Entity<Pozycja>(entity =>
        {
            entity.HasKey(e => e.IdPozycji);

            entity.ToTable("Pozycja", "dbo");

            entity.Property(e => e.IdPozycji).HasColumnName("idPozycji");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nazwa");
        });

        modelBuilder.Entity<Program>(entity =>
        {
            entity.HasKey(e => e.IdWersji);

            entity.ToTable("Program", "dbo");

            entity.Property(e => e.IdWersji).HasColumnName("idWersji");
            entity.Property(e => e.Wersja).HasColumnName("wersja");
        });

        modelBuilder.Entity<PrywatneWiadomosci>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("PrywatneWiadomosci", "dbo");

            entity.Property(e => e.Aktywny).HasColumnName("aktywny");
            entity.Property(e => e.Data).HasMaxLength(4000);
            entity.Property(e => e.Nadawca)
                .HasMaxLength(511)
                .IsUnicode(false);
            entity.Property(e => e.Odbiorca)
                .HasMaxLength(511)
                .IsUnicode(false);
            entity.Property(e => e.Treść)
                .HasMaxLength(3000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sezon>(entity =>
        {
            entity.HasKey(e => e.IdSezonu);

            entity.ToTable("Sezon", "dbo");

            entity.Property(e => e.IdSezonu).HasColumnName("idSezonu");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nazwa");
        });

        modelBuilder.Entity<StatystykiDruzyny>(entity =>
        {
            entity.HasKey(e => e.IdDruzyny).HasName("PK__Table__1FC2B9FD4F9F5C67");

            entity.ToTable("StatystykiDruzyny", "dbo");

            entity.Property(e => e.IdDruzyny)
                .ValueGeneratedNever()
                .HasColumnName("idDruzyny");
            entity.Property(e => e.MiejsceGlobalne).HasColumnName("miejsceGlobalne");
            entity.Property(e => e.Przegrane23).HasColumnName("przegrane23");
            entity.Property(e => e.PrzegraneMecze).HasColumnName("przegraneMecze");
            entity.Property(e => e.Punkty).HasColumnName("punkty");
            entity.Property(e => e.RozegraneMecze).HasColumnName("rozegraneMecze");
            entity.Property(e => e.Wygrane32).HasColumnName("wygrane32");
            entity.Property(e => e.WygraneMecze).HasColumnName("wygraneMecze");

            entity.HasOne(d => d.IdDruzynyNavigation).WithOne(p => p.StatystykiDruzyny)
                .HasForeignKey<StatystykiDruzyny>(d => d.IdDruzyny)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StatystykiDruzyny_Druzyna");
        });

        modelBuilder.Entity<Temat>(entity =>
        {
            entity.HasKey(e => e.IdTematu);

            entity.ToTable("Temat", "dbo");

            entity.Property(e => e.IdTematu).HasColumnName("idTematu");
            entity.Property(e => e.Aktywny)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("aktywny");
            entity.Property(e => e.DataUtworzenia).HasColumnName("dataUtworzenia");
            entity.Property(e => e.IdAutora).HasColumnName("idAutora");
            entity.Property(e => e.IdKategorii).HasColumnName("idKategorii");
            entity.Property(e => e.Tresc)
                .HasMaxLength(3000)
                .IsUnicode(false)
                .HasColumnName("tresc");
            entity.Property(e => e.Tytul)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tytul");

            entity.HasOne(d => d.IdAutoraNavigation).WithMany(p => p.Temats)
                .HasForeignKey(d => d.IdAutora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Temat_Uzytkownik");

            entity.HasOne(d => d.IdKategoriiNavigation).WithMany(p => p.Temats)
                .HasForeignKey(d => d.IdKategorii)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Temat_Kategoria");
        });

        modelBuilder.Entity<Uzytkownik>(entity =>
        {
            entity.HasKey(e => e.IdUzytkownika);

            entity.ToTable("Uzytkownik", "dbo");

            entity.Property(e => e.IdUzytkownika).HasColumnName("idUzytkownika");
            entity.Property(e => e.EmailDodatkowy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("emailDodatkowy");
            entity.Property(e => e.Hobby)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("hobby");
            entity.Property(e => e.IdKonta).HasColumnName("idKonta");
            entity.Property(e => e.IdPozycji).HasColumnName("idPozycji");
            entity.Property(e => e.Imie)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imie");
            entity.Property(e => e.InfoOsobie)
                .HasMaxLength(3000)
                .IsUnicode(false)
                .HasColumnName("infoOSobie");
            entity.Property(e => e.Miasto)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("miasto");
            entity.Property(e => e.Nazwisko)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nazwisko");
            entity.Property(e => e.NrNaKoszulce).HasColumnName("nrNaKoszulce");
            entity.Property(e => e.Plec).HasColumnName("plec");
            entity.Property(e => e.RokUrodzenia).HasColumnName("rokUrodzenia");
            entity.Property(e => e.SiatkarskiIdol)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("siatkarskiIdol");
            entity.Property(e => e.Telefon)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("telefon");
            entity.Property(e => e.Waga).HasColumnName("waga");
            entity.Property(e => e.Wzrost).HasColumnName("wzrost");
            entity.Property(e => e.ZasiegAtak).HasColumnName("zasiegAtak");
            entity.Property(e => e.ZasiegBlok).HasColumnName("zasiegBlok");
            entity.Property(e => e.Zdjecie)
                .HasColumnType("image")
                .HasColumnName("zdjecie");
            entity.Property(e => e.ZdjecieHeight).HasColumnName("zdjecieHeight");
            entity.Property(e => e.ZdjecieWidth).HasColumnName("zdjecieWidth");

          

            entity.HasOne(d => d.IdPozycjiNavigation).WithMany(p => p.Uzytkowniks)
                .HasForeignKey(d => d.IdPozycji)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Uzytkownik_Pozycja");
        });

     
        modelBuilder.Entity<WynikTypowany>(entity =>
        {
            entity.HasKey(e => e.IdWynikuTypowanego);

            entity.ToTable("WynikTypowany", "dbo");

            entity.Property(e => e.IdWynikuTypowanego).HasColumnName("idWynikuTypowanego");
            entity.Property(e => e.IdMeczu).HasColumnName("idMeczu");
            entity.Property(e => e.IdUzytkownika).HasColumnName("idUzytkownika");
            entity.Property(e => e.Wynik1).HasColumnName("wynik1");
            entity.Property(e => e.Wynik2).HasColumnName("wynik2");

            entity.HasOne(d => d.IdMeczuNavigation).WithMany(p => p.WynikTypowanies)
                .HasForeignKey(d => d.IdMeczu)
                .HasConstraintName("FK_WynikTypowany_Mecz");

            entity.HasOne(d => d.IdUzytkownikaNavigation).WithMany(p => p.WynikTypowanies)
                .HasForeignKey(d => d.IdUzytkownika)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WynikTypowany_Uzytkownik");
        });

        modelBuilder.Entity<Zaproszenie>(entity =>
        {
            entity.HasKey(e => e.IdZaproszenia);

            entity.ToTable("Zaproszenie", "dbo");

            entity.Property(e => e.IdZaproszenia).HasColumnName("idZaproszenia");
            entity.Property(e => e.DataUtworzenia)
                .HasColumnType("datetime")
                .HasColumnName("dataUtworzenia");
            entity.Property(e => e.IdDruzyny).HasColumnName("idDruzyny");
            entity.Property(e => e.IdZawodnika).HasColumnName("idZawodnika");

            entity.HasOne(d => d.IdDruzynyNavigation).WithMany(p => p.Zaproszenies)
                .HasForeignKey(d => d.IdDruzyny)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Zaproszenie_Druzyna");

            entity.HasOne(d => d.IdZawodnikaNavigation).WithMany(p => p.Zaproszenies)
                .HasForeignKey(d => d.IdZawodnika)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Zaproszenie_Uzytkownik");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
