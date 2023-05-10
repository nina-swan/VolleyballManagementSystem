using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VolleyballDomain.Shared.Models;

public partial class VolleyballSysDbContext : DbContext
{
    private string connStringLocal = "Server=127.0.0.1;Database=siatkowka;Integrated Security=True;";

    public VolleyballSysDbContext()
    {
    }

    public VolleyballSysDbContext(DbContextOptions<VolleyballSysDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artykul> Artykul { get; set; }

    public virtual DbSet<Team> Druzyna { get; set; }

    public virtual DbSet<Team> DruzynaZwodnik { get; set; }

    public virtual DbSet<Kategoria> Kategoria { get; set; }

    public virtual DbSet<Round> Kolejka { get; set; }

    public virtual DbSet<Comment> Komentarz { get; set; }

    public virtual DbSet<League> Liga { get; set; }

    public virtual DbSet<Log> Log { get; set; }

    public virtual DbSet<PersonalLog> LogPersonalny { get; set; }

    public virtual DbSet<Game> Mecz { get; set; }

    public virtual DbSet<MiejsceKomentarza> MiejsceKomentarza { get; set; }

    public virtual DbSet<Place> ObiektSportowy { get; set; }

    public virtual DbSet<Pozycja> Pozycja { get; set; }

    public virtual DbSet<Season> Sezon { get; set; }

    public virtual DbSet<TeamStats> StatystykiDruzyny { get; set; }

    public virtual DbSet<Temat> Temat { get; set; }

    public virtual DbSet<Player> Uzytkownik { get; set; }

    public virtual DbSet<WynikTypowany> WynikTypowany { get; set; }

    public virtual DbSet<Invitation> Zaproszenie { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(connStringLocal);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artykul>(entity =>
        {
            entity.Property(e => e.Aktywny).HasDefaultValueSql("((1))");
            entity.Property(e => e.DataUtworzenia).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdAutoraNavigation).WithMany(p => p.Articles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Artykul_Uzytkownik");
        });


        modelBuilder.Entity<Team>(entity =>
        {
            entity.Property(e => e.SignedUp).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Captain).WithOne(p => p.TeamOwner)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.League).WithMany(p => p.Druzyna)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Druzyna_Liga");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasMany(d => d.Players).WithMany(p => p.TeamsPlayer);

        });

        modelBuilder.Entity<Round>(entity =>
        {
            entity.HasOne(d => d.Season).WithMany(p => p.Rounds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Kolejka_Sezon");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.Property(e => e.IdMiejscaKomentarza).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.IdAutoraNavigation).WithMany(p => p.Comments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Komentarz_Uzytkownik");

            entity.HasOne(d => d.IdMiejscaKomentarzaNavigation).WithMany(p => p.Komentarz)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Komentarz_MiejsceKomentarza");
        });

        modelBuilder.Entity<PersonalLog>(entity =>
        {
            entity.HasOne(d => d.IdLoguNavigation).WithMany(p => p.LogPersonalny).HasConstraintName("FK_LogPersonalny_Log");

            entity.HasOne(d => d.IdUzytkownikaNavigation).WithMany(p => p.PersonalLogs).HasConstraintName("FK_LogPersonalny_Uzytkownik");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.Property(e => e.IdMvp).HasDefaultValueSql("((39))");

            entity.HasOne(d => d.IdDruzyny1Navigation).WithMany(p => p.GamesTeam2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mecz_Druzyna");

            entity.HasOne(d => d.IdDruzyny2Navigation).WithMany(p => p.GamesTeam1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mecz_Druzyna1");

            entity.HasOne(d => d.IdKolejkiNavigation).WithMany(p => p.Mecz)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mecz_Kolejka");

            entity.HasOne(d => d.IdLigiNavigation).WithMany(p => p.Mecz)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mecz_Liga");

            entity.HasOne(d => d.IdMiejscaNavigation).WithMany(p => p.Games)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mecz_ObiektSportowy");

            entity.HasOne(d => d.IdMvpNavigation).WithMany(p => p.GamesMVP)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mecz_Uzytkownik1");

            entity.HasOne(d => d.IdSedziegoNavigation).WithMany(p => p.GamesUmpire).HasConstraintName("FK_Mecz_Uzytkownik");
        });

        modelBuilder.Entity<TeamStats>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table__1FC2B9FD4F9F5C67");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Team).WithOne(p => p.TeamStats)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StatystykiDruzyny_Druzyna");
        });

        modelBuilder.Entity<Temat>(entity =>
        {
            entity.Property(e => e.Aktywny).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.IdAutoraNavigation).WithMany(p => p.Topics)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Temat_Uzytkownik");

            entity.HasOne(d => d.IdKategoriiNavigation).WithMany(p => p.Temat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Temat_Kategoria");
        });


        modelBuilder.Entity<WynikTypowany>(entity =>
        {
            entity.HasOne(d => d.IdMeczuNavigation).WithMany(p => p.WynikTypowany).HasConstraintName("FK_WynikTypowany_Mecz");

            entity.HasOne(d => d.IdUzytkownikaNavigation).WithMany(p => p.BetScore)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WynikTypowany_Uzytkownik");
        });

        modelBuilder.Entity<Invitation>(entity =>
        {
            entity.HasOne(d => d.Team).WithMany(p => p.Invitations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Zaproszenie_Druzyna");

            entity.HasOne(d => d.IdZawodnikaNavigation).WithMany(p => p.Invites)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Zaproszenie_Uzytkownik");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
