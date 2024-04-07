using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

public partial class AcademyContext : DbContext
{
    public AcademyContext(DbContextOptions<AcademyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<RankingCriterion> RankingCriteria { get; set; }

    public virtual DbSet<RankingSystem> RankingSystems { get; set; }

    public virtual DbSet<University> Universities { get; set; }

    public virtual DbSet<UniversityRankingYear> UniversityRankingYears { get; set; }

    public virtual DbSet<UniversityYear> UniversityYears { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__country__3213E83FCB9511AA");

            entity.ToTable("country");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CountryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("country_name");
        });

        modelBuilder.Entity<RankingCriterion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ranking___3213E83F755FB18D");

            entity.ToTable("ranking_criteria");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CriteriaName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("criteria_name");
            entity.Property(e => e.RankingSystemId).HasColumnName("ranking_system_id");

            entity.HasOne(d => d.RankingSystem).WithMany(p => p.RankingCriteria)
                .HasForeignKey(d => d.RankingSystemId)
                .HasConstraintName("fk_rc_rs");
        });

        modelBuilder.Entity<RankingSystem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ranking___3213E83FA63C24AB");

            entity.ToTable("ranking_system");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.SystemName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("system_name");
        });

        modelBuilder.Entity<University>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__universi__3213E83FBBD129AA");

            entity.ToTable("university");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.UniversityName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("university_name");

            entity.HasOne(d => d.Country).WithMany(p => p.Universities)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("fk_uni_cnt");
        });

        modelBuilder.Entity<UniversityRankingYear>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("university_ranking_year");

            entity.Property(e => e.RankingCriteriaId).HasColumnName("ranking_criteria_id");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.UniversityId).HasColumnName("university_id");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.RankingCriteria).WithMany()
                .HasForeignKey(d => d.RankingCriteriaId)
                .HasConstraintName("fk_ury_rc");

            entity.HasOne(d => d.University).WithMany()
                .HasForeignKey(d => d.UniversityId)
                .HasConstraintName("fk_ury_uni");
        });

        modelBuilder.Entity<UniversityYear>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("university_year");

            entity.Property(e => e.NumStudents).HasColumnName("num_students");
            entity.Property(e => e.PctFemaleStudents).HasColumnName("pct_female_students");
            entity.Property(e => e.PctInternationalStudents).HasColumnName("pct_international_students");
            entity.Property(e => e.StudentStaffRatio)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("student_staff_ratio");
            entity.Property(e => e.UniversityId).HasColumnName("university_id");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.University).WithMany()
                .HasForeignKey(d => d.UniversityId)
                .HasConstraintName("fk_uy_uni");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
