using Microsoft.EntityFrameworkCore;
using Tarifikacija.Entities;

namespace Tarifikacija;

public class AppDbContext : DbContext
{
    private static readonly Environment.SpecialFolder Folder = Environment.SpecialFolder.LocalApplicationData;
    private readonly string _dbPath;
    
    public DbSet<SubjectEntity> Subjects { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        _dbPath = Path.Join(Environment.GetFolderPath(Folder), "eif.db");
        Console.Write(_dbPath);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseSqlite($"Data Source={_dbPath}");
        }
    }
}