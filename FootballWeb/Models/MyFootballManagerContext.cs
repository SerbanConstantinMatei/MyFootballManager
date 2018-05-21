using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FootballWeb.Models
{
    public partial class MyFootballManagerContext : DbContext
    {
        public virtual DbSet<Match> Match { get; set; }
        public virtual DbSet<Score> Score { get; set; }
        public virtual DbSet<Team> Team { get; set; }

        public MyFootballManagerContext(DbContextOptions<MyFootballManagerContext> options)
    : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateTime)
                    .HasColumnName("DateTIme")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdScore).HasColumnName("ID_Score");

                entity.Property(e => e.IdTeamAway).HasColumnName("ID_TeamAway");

                entity.Property(e => e.IdTeamHome).HasColumnName("ID_TeamHome");

                entity.HasOne(d => d.IdScoreNavigation)
                    .WithMany(p => p.Match)
                    .HasForeignKey(d => d.IdScore)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Score");

                entity.HasOne(d => d.IdTeamAwayNavigation)
                    .WithMany(p => p.MatchIdTeamAwayNavigation)
                    .HasForeignKey(d => d.IdTeamAway)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_TeamAway");

                entity.HasOne(d => d.IdTeamHomeNavigation)
                    .WithMany(p => p.MatchIdTeamHomeNavigation)
                    .HasForeignKey(d => d.IdTeamHome)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_TeamHome");
            });

            modelBuilder.Entity<Score>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });
        }
    }
}
