using Microsoft.EntityFrameworkCore;
namespace Worker.Installers
{
    public class WorkerDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        public WorkerDbContext(DbContextOptions<WorkerDbContext> options) : base(options)
        {
        }
        public WorkerDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_configuration.GetConnectionString("DataBase"));
        }

        public DbSet<WeatherData> WeatherDatas { get; set; }
    }
}