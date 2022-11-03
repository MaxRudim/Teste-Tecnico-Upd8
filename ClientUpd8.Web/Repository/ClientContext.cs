using Microsoft.EntityFrameworkCore;
using ClientUpd8.Models;

namespace ClientUpd8.Repository;
public class ClientContext : DbContext, IClientContext
{

    public DbSet<Client>? Clients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=upd8;User=SA;Password=SenhaSegura123.");
    }

}