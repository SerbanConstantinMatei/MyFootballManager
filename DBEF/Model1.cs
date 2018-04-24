namespace DBEF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Match> Match { get; set; }
        public virtual DbSet<Score> Score { get; set; }
        public virtual DbSet<Team> Team { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Score>()
                .HasMany(e => e.Match)
                .WithRequired(e => e.Score)
                .HasForeignKey(e => e.ID_Score)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Match)
                .WithRequired(e => e.Team)
                .HasForeignKey(e => e.ID_TeamAway)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Match1)
                .WithRequired(e => e.Team1)
                .HasForeignKey(e => e.ID_TeamHome)
                .WillCascadeOnDelete(false);
        }
    }
}
