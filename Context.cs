using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<HabitReward>()
            .HasKey(hr => new { hr.HabitId, hr.RewardId });
            
        }

        public virtual DbSet<Habit> Habits { get; set; }
        public virtual DbSet<Reward> Rewards { get; set; }
        public virtual DbSet<HabitReward> HabitsRewards { get; set; }
    }
}
