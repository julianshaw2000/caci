using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Games.Task6API.Data;
public class AppDbContext : DbContext
{
    public DbSet<ScoreRecord> ScoreRecords { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
