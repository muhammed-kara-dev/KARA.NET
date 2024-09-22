using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KARA.NET.Data.EntityFramework;
public abstract class BaseDataModel
    : DbContext
{
    protected ILoggerFactory LoggerFactory { get; }
    private DatabaseSettings DatabaseSettings { get; }
    private ISeed SeedBase { get; }
    private ISeed SeedDevelopment { get; }
    private ISeed SeedProduction { get; }
    private bool IsSeeding { get; set; }

    public BaseDataModel(ILoggerFactory loggerFactory, DatabaseSettings databaseSettings, ISeed seedBase = null, ISeed seedDevelopment = null, ISeed seedProduction = null)
    {
        this.LoggerFactory = loggerFactory;
        this.DatabaseSettings = databaseSettings;
        this.SeedBase = seedBase;
        this.SeedDevelopment = seedDevelopment;
        this.SeedProduction = seedProduction;
    }

    protected abstract void Configure(DbContextOptionsBuilder optionsBuilder);

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(this.DatabaseSettings.ConnectionString);
        this.Configure(optionsBuilder);
    }

    protected abstract void CreateModel(ModelBuilder modelBuilder);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        this.CreateModel(modelBuilder);
        if (this.IsSeeding)
        {
            this.SeedBase?.Seed(modelBuilder);
            if (ApplicationUtils.IsDebug)
            {
                this.SeedDevelopment?.Seed(modelBuilder);
            }
            else
            {
                this.SeedProduction?.Seed(modelBuilder);
            }
        }
        base.OnModelCreating(modelBuilder);
    }

    public void EnableSeeding()
    {
        this.IsSeeding = true;
    }
}