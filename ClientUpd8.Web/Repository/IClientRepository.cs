using ClientUpd8.Models;

namespace ClientUpd8.Repository;

public interface IClientRepository
{
  public Task<Client> Add(Client client);
  public Task Delete(Guid id);
  public Task Update(Client client);
  public Task<Client?> Get(Guid id);
  public Task<Client?> GetByCpf(string cpf);
  public Task<IEnumerable<Client>> GetAll();
}