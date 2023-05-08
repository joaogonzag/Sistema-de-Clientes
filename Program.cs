using APICliente.Services;
using System.Data.SqlClient;
using TesteConexão.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
ClienteServices clienteServices = new ClienteServices();


app.MapPost("/cadastrar", (ClienteModel model) =>
{
    return clienteServices.InserirCliente(model);
});

app.MapGet("/listarClientes", () =>
{
    return clienteServices.ListCliente();
});

app.MapPut("/editarClientes", (ClienteModel model) =>
{
    return clienteServices.EditarCliente(model);
});

app.MapGet("/buscarCliente/{id:int}", (int id) =>
{
    return clienteServices.SelectCliente(id);
});

app.Run();
