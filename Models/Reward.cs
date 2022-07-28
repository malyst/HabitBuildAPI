using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Reward
    {
        public int RewardId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Cost { get; set; }

        public IList<HabitReward>? HabitRewards { get; set; }
    }
}
