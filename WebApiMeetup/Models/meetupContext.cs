using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApiMeetup.Models
{
    public partial class meetupContext : DbContext
    {
        public meetupContext()
        {
        }

        public meetupContext(DbContextOptions<meetupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Districts> Districts { get; set; }
        public virtual DbSet<Meetup> Meetup { get; set; }
        public virtual DbSet<MeetupType> MeetupType { get; set; }
        public virtual DbSet<Participents> Participents { get; set; }
        public virtual DbSet<People> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=meetup;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Districts>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("districts");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(100)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Meetup>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("meetup");

                entity.HasIndex(e => e.Code)
                    .HasName("IX_meetup");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Details)
                    .HasColumnName("details")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.DistrictCode).HasColumnName("districtCode");

                entity.Property(e => e.MeetupTypeCode).HasColumnName("meetupTypeCode");

                entity.HasOne(d => d.DistrictCodeNavigation)
                    .WithMany(p => p.Meetup)
                    .HasForeignKey(d => d.DistrictCode)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_meetup_district");

                entity.HasOne(d => d.MeetupTypeCodeNavigation)
                    .WithMany(p => p.Meetup)
                    .HasForeignKey(d => d.MeetupTypeCode)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_meetup_meetupType");
            });

            modelBuilder.Entity<MeetupType>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("meetupType");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(100)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Participents>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("participents");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .ValueGeneratedNever();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MeetupCode).HasColumnName("meetupCode");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Participents)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_participents_people");

                entity.HasOne(d => d.MeetupCodeNavigation)
                    .WithMany(p => p.Participents)
                    .HasForeignKey(d => d.MeetupCode)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_participents_meetup");
            });

            modelBuilder.Entity<People>(entity =>
            {
                entity.ToTable("people");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
