using Microsoft.EntityFrameworkCore;

namespace KARA.NET.Data.EntityFramework;
public interface ISeed
{
    public void Seed(ModelBuilder modelBuilder);
}