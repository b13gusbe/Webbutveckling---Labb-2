using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebbLabb2.Models;

public partial class BokhandelContext : DbContext
{
    public BokhandelContext()
    {
    }

    public BokhandelContext(DbContextOptions<BokhandelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Butiker> Butikers { get; set; }

    public virtual DbSet<Böcker> Böckers { get; set; }

    public virtual DbSet<Författare> Författares { get; set; }

    public virtual DbSet<Kunder> Kunders { get; set; }

    public virtual DbSet<LagerSaldo> LagerSaldos { get; set; }

    public virtual DbSet<Ordrar> Ordrars { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\;Database=Bokhandel;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Butiker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Butiker__3214EC271DB61FF0");

            entity.ToTable("Butiker");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Adress).HasMaxLength(100);
            entity.Property(e => e.Butiksnamn).HasMaxLength(100);
        });

        modelBuilder.Entity<Böcker>(entity =>
        {
            entity.HasKey(e => e.Isbn13).HasName("PK__Böcker__3BF79E039AA8CE48");

            entity.ToTable("Böcker");

            entity.Property(e => e.Isbn13)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISBN13");
            entity.Property(e => e.FörfattareId).HasColumnName("FörfattareID");
            entity.Property(e => e.Språk).HasMaxLength(30);
            entity.Property(e => e.Titel).HasMaxLength(100);
            entity.Property(e => e.Utgivningsdatum).HasColumnType("date");

            entity.HasOne(d => d.Författare).WithMany(p => p.Böckers)
                .HasForeignKey(d => d.FörfattareId)
                .HasConstraintName("FK__Böcker__Författa__267ABA7A");
        });

        modelBuilder.Entity<Författare>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Författa__3214EC27BAF939AB");

            entity.ToTable("Författare");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Efternamn).HasMaxLength(40);
            entity.Property(e => e.Födelsedatum).HasColumnType("date");
            entity.Property(e => e.Förnamn).HasMaxLength(40);
        });

        modelBuilder.Entity<Kunder>(entity =>
        {
            entity.HasKey(e => e.Epost).HasName("PK__Kunder__0CCE4D1693DEDDD4");

            entity.ToTable("Kunder");

            entity.Property(e => e.Epost).HasMaxLength(50);
            entity.Property(e => e.Adress).HasMaxLength(100);
            entity.Property(e => e.Efternamn).HasMaxLength(50);
            entity.Property(e => e.Förnamn).HasMaxLength(30);
        });

        modelBuilder.Entity<LagerSaldo>(entity =>
        {
            entity.HasKey(e => new { e.ButikId, e.Isbn }).HasName("PK__LagerSal__1191B8947A1A2B41");

            entity.ToTable("LagerSaldo");

            entity.Property(e => e.ButikId).HasColumnName("ButikID");
            entity.Property(e => e.Isbn)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISBN");

            entity.HasOne(d => d.Butik).WithMany(p => p.LagerSaldos)
                .HasForeignKey(d => d.ButikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LagerSald__Butik__2B3F6F97");

            entity.HasOne(d => d.IsbnNavigation).WithMany(p => p.LagerSaldos)
                .HasForeignKey(d => d.Isbn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LagerSaldo__ISBN__2C3393D0");
        });

        modelBuilder.Entity<Ordrar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ordrar__3214EC27324C16C0");

            entity.ToTable("Ordrar");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Bok)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Kund).HasMaxLength(50);

            entity.HasOne(d => d.BokNavigation).WithMany(p => p.Ordrars)
                .HasForeignKey(d => d.Bok)
                .HasConstraintName("FK__Ordrar__Bok__31EC6D26");

            entity.HasOne(d => d.KundNavigation).WithMany(p => p.Ordrars)
                .HasForeignKey(d => d.Kund)
                .HasConstraintName("FK__Ordrar__Kund__30F848ED");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
