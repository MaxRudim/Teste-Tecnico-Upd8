using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ClientUpd8.Models;
using ClientUpd8.Repository;
// using ClientUpd8.Middlewares;

namespace ClientUpd8.Controllers;

[ApiController]
[Route("client")]
public class ClientController : Controller
{
    private readonly IClientRepository _repository;
    public ClientController(IClientRepository repository)
    {
        _repository = repository;
    }

    // [HttpPost("Authentication")]
    // public async Task<IActionResult> Authenticate([FromBody] LoginData loginData)
    // {

    //     try
    //     {
    //         var candidate = await _repository.GetByCpf(loginData.Cpf);

    //         if (candidate is null) throw new InvalidOperationException("O candidato não existe");
    //         if(candidate.Password != loginData.Password) throw new InvalidOperationException("Senha inválida");
    //         var token = new TokenGenerator().Generate(candidate);
    //         candidate.Password = "";
    //         return Ok(new {token, candidate});
    //     }
    //     catch (InvalidOperationException ex)
    //     {
    //         return BadRequest(ex.Message);
    //     }
    // }

    [HttpPost()]
    // [AllowAnonymous]
    public async Task<IActionResult> CreateClient([FromBody] Client client)
    {
        try
        {
            var clientExist = await _repository.GetByCpf(client.Cpf);
            if (clientExist is not null) throw new InvalidOperationException("Este cliente já existe");

            // var validCpf = ValidaCPF.IsCpf(client.Cpf);
            // if (validCpf == false) throw new InvalidOperationException("Cpf inválido");

            var output = await _repository.Add(client);
            return CreatedAtAction("GetClient", new { id = output.ClientId }, output);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    // [Authorize]
    public async Task<IActionResult> DeleteClient(Guid id)
    {
        try
        {
            var clientExist = await _repository.Get(id);
            if (clientExist is null) throw new InvalidOperationException("Este cliente não existe");

            await _repository.Delete(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("view")]
    public async Task<IActionResult> ClientView()
    {
      var clientList = await _repository.GetAll();
      ViewBag.candidate = clientList;
      return View();
    }
    
    [HttpGet()]
    // [Authorize]
    public async Task<IActionResult> GetAllClients()
    {
        try
        {
            var clients = await _repository.GetAll();
            if (clients == null) throw new InvalidOperationException("Não existem clientes cadastrados");

            return Ok(clients);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpGet("{id}")]
    // [Authorize]
    public async Task<IActionResult> GetClient(string id)
    {
        try
        {
            var client = await _repository.Get(new Guid(id));
            if (client == null) throw new InvalidOperationException("O cliente não existe");

            return Ok(client);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut()]
    // [Authorize]
    public async Task<IActionResult> UpdateClient([FromBody] Client client)
    {
        try
        {
            var clientExist = await _repository.Get(client.ClientId);
            if (clientExist == null) throw new InvalidOperationException("O cliente não existe");

            // clientExist.Cpf = client.Cpf;  -- Cpf não pode ser alterado.
            // clientExist.BirthDate = client.BirthDate;  -- BirthDate não pode ser alterado.
            clientExist.Address = client.Address;
            clientExist.City = client.City;
            clientExist.State = client.State;
            clientExist.Name = client.Name;


            await _repository.Update(clientExist);

            var updatedClient = await _repository.Get(client.ClientId);
            return Ok(updatedClient);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }

    }
}