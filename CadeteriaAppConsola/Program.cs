using Serilog;
using CadeteriaLib.models;


//creo el log para anotar los errores 
    Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger();

var AccesoCSV = new AccesoCSV();
var AccesoJSON = new AccesoJSON();

try
{
    Cadeteria cadeteria = new Cadeteria(1, "Diaz Cadeteria", "0800-888-999");
    
    Cliente cliente1 = new Cliente("Kirsch", "Edmond", "Bilbao", "012-3456-789");
    Cliente cliente2 = new Cliente("Zobrist", "Bertrand", "Florencia", "987-6543-210");

    cadeteria.AgregarCliente(cliente1);
    cadeteria.AgregarCliente(cliente2);

    Pedido pedido1 = new Pedido("PC Gamer",cliente1);
    Pedido pedido2 = new Pedido("El origen de las especies",cliente1);
    Pedido pedido3 = new Pedido("Manual de Genertica",cliente2);

    cadeteria.AgregarPedido(pedido1);
    cadeteria.AgregarPedido(pedido2);
    cadeteria.AgregarPedido(pedido3);

    Cadete cadete1 = new Cadete("Superman", "011-2358-1321");
    Cadete cadete2 = new Cadete("Flash", "123-5711-1317");

    cadeteria.AgregarCadete(cadete1);
    cadeteria.AgregarCadete(cadete2);

    cadeteria.AsignarCadeteAPedido(1,1);
    cadeteria.AsignarCadeteAPedido(2,1);
    cadeteria.AsignarCadeteAPedido(3,2);

    pedido1.CambiarEstadoPedido(EstadoPedido.Entregado);
    pedido3.CambiarEstadoPedido(EstadoPedido.Entregado);
    
    AccesoCSV.GuardarClientes(cadeteria.ListaClientes);
    AccesoJSON.GuardarClientes(cadeteria.ListaClientes);
    AccesoCSV.GuardarPedidos(cadeteria.ListaPedidos);
    AccesoJSON.GuardarPedidos(cadeteria.ListaPedidos);
    AccesoCSV.GuardarCadetes(cadeteria.ListaCadetes);
    AccesoJSON.GuardarCadetes(cadeteria.ListaCadetes);

    Console.WriteLine($"El Jornal de {cadete1.Nombre} es ${cadeteria.JornalACobrar(1)}");
    Console.WriteLine($"El Jornal de {cadete2.Nombre} es ${cadeteria.JornalACobrar(2)}");

}
catch (Exception ex)
{
    Log.Error(ex, $"Error: {ex}");
    throw;
}

//cierro el log
    Log.CloseAndFlush();