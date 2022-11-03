using Microsoft.EntityFrameworkCore;
using ClientUpd8.Models;
using Microsoft.Extensions.DependencyInjection;
using ClientUpd8.Repository;

namespace ClientUpd8.Test.Repository;

public class ClientTestContext : ClientContext
{
    public DbSet<Client> Client1 { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

        optionsBuilder.UseInMemoryDatabase("Client1").UseInternalServiceProvider(serviceProvider);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>()
          .HasKey(i => i.ClientId);
    }

}