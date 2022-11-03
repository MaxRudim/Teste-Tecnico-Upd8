using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using RichardSzalay.MockHttp;
using System;
using Xunit;
using FluentAssertions;

namespace ClientUpd8.Test.Controller;

public class ClientControllerTest
{
    public string apiUri = "https://localhost:7268";

    
    [Trait("User", "1 - Client")]
    [Fact(DisplayName = "Teste para Create Client")]
    public async Task TestCreateAClientController()
    {
    
        var mockHttp = new MockHttpMessageHandler();

        var newClient = JsonConvert.SerializeObject(new
          {
              Name = "Max Rudim",
              Cpf = "435.861.890-10",
              City = "Curitiba",
              State = "Parana",
              Address = "Rua das pamonhas",
              Birthdate = "25-12-1996",
              Gender = "M"
          });

        mockHttp.When(HttpMethod.Post, $"{apiUri}/client")
                .Respond("application/json", newClient);

        var client = mockHttp.ToHttpClient();

        var response = await client.PostAsync($"{apiUri}/client", new StringContent(newClient, Encoding.UTF8, "application/json"));

        var json = await response.Content.ReadAsStringAsync();

        response.Should().BeSuccessful();
        json.Should().Contain(newClient);

    }

    [Trait("User", "1 - Client")]
    [Fact(DisplayName = "Teste para Delete Client")]
    public async Task TestDeleteAClientController()
    {
    
        var mockHttp = new MockHttpMessageHandler();

        var newClient = JsonConvert.SerializeObject(new
          {
              Name = "Max Rudim",
              Cpf = "435.861.890-10",
              City = "Curitiba",
              State = "Parana",
              Address = "Rua das pamonhas",
              Birthdate = "25-12-1996",
              Gender = "M"
          });

        mockHttp.When(HttpMethod.Post, $"{apiUri}/client")
                .Respond("application/json", newClient);

        mockHttp.When(HttpMethod.Get, $"{apiUri}/client/*")
                .Respond("application/json", newClient);

        mockHttp.When(HttpMethod.Delete, $"{apiUri}/client/*")
                .Respond(System.Net.HttpStatusCode.NoContent);
                
        var client = mockHttp.ToHttpClient();

        var response = await client.PostAsync($"{apiUri}/client", new StringContent(newClient, Encoding.UTF8, "application/json"));
        response.Should().BeSuccessful();

        var getClient = await client.GetAsync($"{apiUri}/client/id");
        getClient.Should().BeSuccessful();

        var deleteClient = await client.DeleteAsync($"{apiUri}/client/id");
        deleteClient.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);

    }

    [Trait("User", "1 - Client")]
    [Fact(DisplayName = "Teste para Get Client")]
    public async Task TestGetAClientController()
    {
    
        var mockHttp = new MockHttpMessageHandler();

        var newClient = JsonConvert.SerializeObject(new
          {
              Name = "Max Rudim",
              Cpf = "435.861.890-10",
              City = "Curitiba",
              State = "Parana",
              Address = "Rua das pamonhas",
              Birthdate = "25-12-1996",
              Gender = "M"
          });

        mockHttp.When(HttpMethod.Post, $"{apiUri}/client")
                .Respond("application/json", newClient);

        mockHttp.When(HttpMethod.Get, $"{apiUri}/client/*")
                .Respond("application/json", newClient);
                
        var client = mockHttp.ToHttpClient();

        var response = await client.PostAsync($"{apiUri}/client", new StringContent(newClient, Encoding.UTF8, "application/json"));
        response.Should().BeSuccessful();

        var getClient = await client.GetAsync($"{apiUri}/client/id");
        getClient.Should().BeSuccessful();

        var json = await response.Content.ReadAsStringAsync();
        json.Should().Contain(newClient);

    }

    [Trait("User", "1 - Client")]
    [Fact(DisplayName = "Teste para Get All Clients")]
    public async Task TestGetAllClientsController()
    {
    
        var mockHttp = new MockHttpMessageHandler();

        var newClient = JsonConvert.SerializeObject(new
          {
              Name = "Max Rudim",
              Cpf = "435.861.890-10",
              City = "Curitiba",
              State = "Parana",
              Address = "Rua das pamonhas",
              Birthdate = "25-12-1996",
              Gender = "M"
          });

        mockHttp.When(HttpMethod.Post, $"{apiUri}/client")
                .Respond("application/json", newClient);

        mockHttp.When(HttpMethod.Get, $"{apiUri}/client")
                .Respond("application/json", newClient);
                
        var client = mockHttp.ToHttpClient();

        var response = await client.PostAsync($"{apiUri}/client", new StringContent(newClient, Encoding.UTF8, "application/json"));
        response.Should().BeSuccessful();

        var getAllClients = await client.GetAsync($"{apiUri}/client");
        getAllClients.Should().BeSuccessful();

        var json = await response.Content.ReadAsStringAsync();
        json.Should().Contain(newClient);

    }

    [Trait("User", "1 - Client")]
    [Fact(DisplayName = "Teste para Update Client")]
    public async Task TestUpdateAClientController()
    {
    
        var mockHttp = new MockHttpMessageHandler();

        var newClient = JsonConvert.SerializeObject(new
          {
              Name = "Max Rudim",
              Cpf = "435.861.890-10",
              City = "Curitiba",
              State = "Parana",
              Address = "Rua das pamonhas",
              Birthdate = "25-12-1996",
              Gender = "M"
          });

        var updatedClient = JsonConvert.SerializeObject(new
          {
              Name = "Max Rudim",
              Cpf = "435.861.890-10",
              City = "Maringá",
              State = "Parana",
              Address = "Rua do pão de queijo",
              Birthdate = "25-12-1996",
              Gender = "M"
          });

        mockHttp.When(HttpMethod.Post, $"{apiUri}/client")
                .Respond("application/json", newClient);

        mockHttp.When(HttpMethod.Put, $"{apiUri}/client")
                .Respond("application/json", updatedClient);
                
        var client = mockHttp.ToHttpClient();

        var response = await client.PostAsync($"{apiUri}/client", new StringContent(newClient, Encoding.UTF8, "application/json"));
        response.Should().BeSuccessful();

        var getUser = await client.PutAsync($"{apiUri}/client", new StringContent(updatedClient, Encoding.UTF8, "application/json"));
        getUser.Should().BeSuccessful();

        var json = await getUser.Content.ReadAsStringAsync();
        json.Should().Contain(updatedClient);

    }
}