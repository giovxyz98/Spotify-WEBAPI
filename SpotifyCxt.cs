namespace WebApplication1
{
    public class SpotifyCxt : DbContext
    {
        public readonly string _connectionString;

        public SpotifyCxt(DbContextOptions<SpotifyCxt> opts, IOptions<AppSettings> setting) : base(opts)
        {
            _connectionString = setting.Value.ConnectionString;
        }
        public SpotifyCxt()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        public DbSet<Song> Song { get; set; }
    }