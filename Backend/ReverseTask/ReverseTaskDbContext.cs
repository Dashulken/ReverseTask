using Microsoft.EntityFrameworkCore;
using ReverseTask.Models;

namespace ReverseTask;

public class ReverseTaskDbContext : DbContext
{
    public ReverseTaskDbContext(DbContextOptions<ReverseTaskDbContext> options) : base(options)
    {
    }

    public DbSet<Concentration> Concentrations => Set<Concentration>();
    public DbSet<Data> Datas => Set<Data>();
}