﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardsController : ControllerBase
    {
        private readonly Context _context;

        public RewardsController(Context context)
        {
            _context = context;
        }

        // GET: api/Rewards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reward>>> GetRewards()
        {
          if (_context.Rewards == null)
          {
              return NotFound();
          }
            return await _context.Rewards.Include(m => m.HabitRewards).ThenInclude(s => s.Habits).AsNoTracking().ToListAsync();
        }

        // GET: api/Rewards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reward>> GetReward(int id)
        {
          if (_context.Rewards == null)
          {
              return NotFound();
          }
            var reward = await _context.Rewards.Include(m => m.HabitRewards).ThenInclude(s => s.Habits).AsNoTracking().FirstOrDefaultAsync(m => m.RewardId == id);

            if (reward == null)
            {
                return NotFound();
            }

            return reward;
        }


        // POST: api/Rewards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reward>> PostReward(Reward reward)
        {
          if (_context.Rewards == null)
          {
              return Problem("Entity set 'Context.Rewards'  is null.");
          }
            _context.Rewards.Add(reward);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReward", new { id = reward.RewardId }, reward);
        }

        // DELETE: api/Rewards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReward(int id)
        {
            if (_context.Rewards == null)
            {
                return NotFound();
            }
            var reward = await _context.Rewards.FindAsync(id);
            if (reward == null)
            {
                return NotFound();
            }

            _context.Rewards.Remove(reward);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RewardExists(int id)
        {
            return (_context.Rewards?.Any(e => e.RewardId == id)).GetValueOrDefault();
        }
    }
}
