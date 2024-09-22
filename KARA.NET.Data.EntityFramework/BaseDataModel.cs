using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KARA.NET.Data.EntityFramework;
public abstract class BaseDataModel
    : DbContext
{
    protected ILoggerFactory LoggerFactory { get; }
    private DatabaseSettings DatabaseSettings { get; }
    private bool IsSeeding { get; set; }

    public BaseDataModel(ILoggerFactory loggerFactory, DatabaseSettings databaseSettings)
    {
        this.LoggerFactory = loggerFactory;
        this.DatabaseSettings = databaseSettings;
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
            // TODO seed
        }
        base.OnModelCreating(modelBuilder);
    }

    public void EnableSeeding()
    {
        this.IsSeeding = true;
    }
}