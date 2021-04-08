using Microsoft.EntityFrameworkCore;

namespace wave_analysis_rebuild.Models
{
    public class MetaDataContext : DbContext
    {
        public MetaDataContext(DbContextOptions<MetaDataContext> options)
            : base(options)
        {
        }

        public DbSet<MetaData> MetaData { get; set; }
    }
}