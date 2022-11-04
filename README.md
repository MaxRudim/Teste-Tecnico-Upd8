# Processo Seletivo Upd8

Projeto elaborado visando construir uma aplicativo que efetua o cadastro de clientes.

## Proposta de desenvolvimento
 
 - Aplicação Web com Asp.net MVC ( HTML,CSS,Java Script, JQuery, Ajax)

 - Utilizar .NET e Linguagem C#

 - Framework de Persistência:  Entity Framework

 - Banco de Dados : Microsoft SQL SERVER

 - Criar API Rest para o Cliente com as funcionalidades (inclusão, atualização e exclusão)

 
## Orientações

Antes de iniciar o projeto, é necessário ter o [.NET SDK 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) instalado em sua máquina.

Além disso, é necessário ter o [MS SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads), podendo a imagem ser gerada por meio do [Docker](https://www.docker.com/), conforme orientações abaixo.

Tenha instalado algum software para fazer requisições HTTP ao aplicativo criado. São alguns exemplos: Thunder Client (extensão do VS Code), [Insomnia](https://insomnia.rest/download) e [Postman](https://www.postman.com/).

Por fim, é necessário ter o git instalado e inicializado no diretório para clonar o repositório e rodar o projeto localmente.
 
## Como inicializar o projeto

Clone o repositório
```bash
git clone git@github.com:MaxRudim/Teste-Tecnico-Upd8.git
```
Entre na pasta que você acabou de criar com o comando:
```bash
cd teste-tecnico-upd8
```
Restaure as dependências utilizando o comando:
```bash
dotnet restore
```
Inicialize o banco de dados atraves do comando:
```docker
sudo docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=SenhaSegura123." \
   -p 1433:1433 --name sql1 --hostname sql1 \
   -d \
   mcr.microsoft.com/mssql/server:2022-latest
```
Também é possível configurar o ClientContext.cs na pasta ClientUpd8.Web/Repository para adicionar sua conexão preexistente com o MS SQL Server para criar o banco de dados.</br></br>
Entre na pasta do aplicativo:
```bash
cd ClientUpd8.Web
```
Suba o banco
```bash
dotnet ef database update
```
Inicialize a aplicação
```bash
dotnet run
```

## Rotas

O projeto possui a seguinte rota: `https://localhost:7268/client`. Obs: este endereço local deve ser o mesmo informado quando executado o comando `dotnet run`.

Este aplicativo utiliza swagger, portanto, para verificar todas as rotas do servidor, basta digitar no navegador: `https://localhost:7268/swagger`.

## Veriicando os views

Para acessar os views do aplicativo, basta seguir a rota: `https://localhost:7268/client/view`. Caso tenha cadastrado algum cliente, suas informações serão exibidas nela.

## Testando a aplicação

Este projeto foi realizado utilizando testes com xUnit. Para rodar os testes, basta entrar na pasta `ClientUpd8.Test` e, sem estar com o aplicativo rodando (dê um ctrl + c no terminal caso o dotnet run esteja em execução), utilize o comando: `dotnet test`.

## Agradeço a oportunidade!!
