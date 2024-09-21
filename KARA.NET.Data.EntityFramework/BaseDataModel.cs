using Microsoft.EntityFrameworkCore;

namespace KARA.NET.Data.EntityFramework;
public abstract class BaseDataModel
    : DbContext
{
    private bool IsSeeding { get; set; }

    protected abstract void Configure(DbContextOptionsBuilder optionsBuilder);

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // TODO connectionstring
        optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=KPM;Trusted_Connection=True;MultipleActiveResultSets=True;Integrated Security=True;TrustServerCertificate=True;");
        this.Configure(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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