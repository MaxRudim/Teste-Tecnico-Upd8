using Microsoft.EntityFrameworkCore;
using ClientUpd8.Models;

namespace ClientUpd8.Repository
{
    public interface IClientContext
    {
    public DbSet<Client>? Clients { get; set; }
    public int SaveChanges();
    }
}