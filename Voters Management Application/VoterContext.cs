using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Voters_Management_Application
{
    public class VoterContext : DbContext
    {
        public VoterContext() : base("Name=VoterDetailsConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<VoterContext, Migrations.Configuration>());
        }

        public virtual DbSet<VoterDetail> VoterDetails { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VoterDetail>().ToTable("Voters Information");
            modelBuilder.Entity<VoterDetail>().HasKey(property => property.VoterId);
            modelBuilder.Entity<VoterDetail>().Property(property => property.VoterId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<VoterDetail>().Property(property => property.VoterId).HasColumnName("EPIC Number");
            modelBuilder.Entity<VoterDetail>().Property(property => property.Name).IsRequired();
            modelBuilder.Entity<VoterDetail>().Property(property => property.DateOfBirth).HasColumnName("Date Of Birth");
            modelBuilder.Entity<VoterDetail>().Property(property => property.Age).IsRequired();
            modelBuilder.Entity<VoterDetail>().Property(property => property.Gender).HasMaxLength(1);
            modelBuilder.Entity<VoterDetail>().Property(property => property.VotingLocation).HasColumnName("Voting Location");
        }
    }
}
