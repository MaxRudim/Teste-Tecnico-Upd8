using ClientUpd8.Models;
using ClientUpd8.Repository;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System;

namespace ClientUpd8.Test.Repository
{
    public class ClientRepositoryTest
    {

        public static IEnumerable<object[]> SendClientParameters()
        {
            yield return new object[]
            {
                new Client
                {
                  Name = "Max Rudim",
                  Cpf = "435.861.890-10",
                  City = "Curitiba",
                  State = "Parana",
                  Address = "Rua das pamonhas",
                  Birthdate = "25-12-1996",
                  Gender = "M"
                }
            };
        }

        public static IEnumerable<object[]> SendTwoClientsParameters()
        {
            yield return new object[]
            {
                new Client
                {
                  Name = "Xablau da Silva",
                  Cpf = "655.058.600-36",
                  City = "Belo Horizonte",
                  State = "Minas Gerais",
                  Address = "Rua do pão de queijo",
                  Birthdate = "11-11-2011",
                  Gender = "M"
                },

                new Client
                {
                  Name = "Max Rudim",
                  Cpf = "435.861.890-10",
                  City = "Curitiba",
                  State = "Parana",
                  Address = "Rua das pamonhas",
                  Birthdate = "25-12-1996",
                  Gender = "M"
                }
            };
        }

        [Theory]
        [MemberData(nameof(SendClientParameters))]
        public async void ShouldCreateAClient(Client client)
        {
            //Arrange
            ClientTestContext clientTestContext = new();
            ClientRepository clientRepository = new(clientTestContext);

            //Act
            var result = await clientRepository.Add(client);
            var clientSaved = await clientRepository.Get(result.ClientId);

            //Assert
            result.Should().Be(client);
            clientSaved.Should().BeEquivalentTo(client);
        }

        [Theory]
        [MemberData(nameof(SendClientParameters))]
        public async void ShouldDeleteAClient(Client client)
        {
            //Arrange
            ClientTestContext clientTestContext = new();
            ClientRepository clientRepository = new(clientTestContext);

            //Act
            var result = await clientRepository.Add(client);

            var clientSaved = await clientRepository.Get(result.ClientId);
            clientSaved.Should().BeEquivalentTo(client);

            await clientRepository.Delete(result.ClientId);

            //Assert
            var clientOnDatabase = await clientRepository.Get(result.ClientId);
            clientOnDatabase.Should().Be(null);

        }

        [Theory]
        [MemberData(nameof(SendClientParameters))]     
        public async void ShouldUpdateAClient(Client client)
        {
            //Arrange
            var newCity = "Maringá";
            ClientTestContext clientTestContext = new();
            ClientRepository clientRepository = new(clientTestContext);

            //Act
            var result = await clientRepository.Add(client);

            var clientSaved = await clientRepository.Get(result.ClientId);
            clientSaved.Should().BeEquivalentTo(client);
            clientSaved!.City = newCity;

            await clientRepository.Update(clientSaved);

            //Assert
            var clientOnDatabase = await clientRepository.Get(result.ClientId);
            clientOnDatabase!.City.Should().Be(newCity);
        }

        [Theory]
        [MemberData(nameof(SendClientParameters))]
        public async void ShouldGetAClient(Client client)
        {
            //Arrange
            ClientTestContext clientTestContext = new();
            ClientRepository clientRepository = new(clientTestContext);

            //Act
            var result = await clientRepository.Add(client);
            var clientSaved = await clientRepository.Get(result.ClientId);

            //Assert
            clientSaved.Should().BeEquivalentTo(client);
        }

        [Theory]
        [MemberData(nameof(SendTwoClientsParameters))]
        public async void ShouldGetAllClients(Client client, Client secondClient)
        {
            //Arrange
            ClientTestContext clientTestContext = new();
            ClientRepository clientRepository = new(clientTestContext);

            var clients = new Client[] { client, secondClient };

            //Act
            await clientRepository.Add(client);
            await clientRepository.Add(secondClient);
            var savedClients = await clientRepository.GetAll();

            //Assert
            Console.WriteLine(clients);
            savedClients.Should().BeEquivalentTo(clients);

        }
    }
}