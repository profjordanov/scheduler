using Microsoft.EntityFrameworkCore;

namespace Scheduler.Web.Data
{
    public class SchedulerWebContext : DbContext
    {
        public SchedulerWebContext (DbContextOptions<SchedulerWebContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Training> Training { get; set; }
    }
}
