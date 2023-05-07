using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class ExperimentContext : DbContext
    {
        #region DbSets
        public DbSet<Experiment> Experiments { get; set; }
        #endregion

        #region Contructors
        public ExperimentContext(DbContextOptions<ExperimentContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        public ExperimentContext() { }
        #endregion

        #region Protected methods

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Experiment>().HasKey(k => k.DeviceToken);
        }

       
        #endregion
    }
}
