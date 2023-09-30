using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Serilog;

namespace CadeteriaLib.models
{
    public class AccesoCSV : AccesoADatos
    {
        private string clienteCSVFilePath = "datos/clientes.csv";
        private string cadeteCSVFilePath = "datos/cadetes.csv";
        private string pedidosCSVFilePath = "datos/pedidos.csv";

        private ILogger logger;
        public AccesoCSV(){
            logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        }

        public override List<Cadete> GetCadetes()
        {
            try
            {
                using(var reader = new StreamReader(cadeteCSVFilePath))
                using(var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    var cadetes = csv.GetRecords<Cadete>().ToList();
                    return cadetes;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex,"Error al querer acceder al registro cadetes");
                return new List<Cadete>();
            }
        }
        public override List<Cliente> GetClientess()
        {
            try
            {
                using(var reader = new StreamReader(clienteCSVFilePath))
                using(var csv = new CsvReader(reader,new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    var clientes = csv.GetRecords<Cliente>().ToList();
                    return clientes;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error al querer acceder a los archivos de clientes");
                return new List<Cliente>();
            }
        }
        public override List<Pedido> GetPedidos()
        {
            try
            {
                using(var reader = new StreamReader(pedidosCSVFilePath))
                using(var csv = new CsvReader(reader,new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    var pedidos = csv.GetRecords<Pedido>().ToList();
                    return pedidos;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex,"Error al acceder al archivo de pedidos");
                return new List<Pedido>();
            }
        }
        public override void GuardarCadetes(List<Cadete> cadetes)
        {
            try
            {
                using(var writer = new StreamWriter(cadeteCSVFilePath))
                using(var csv = new CsvWriter(writer,new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(cadetes);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex,"Error al escribir en el archivo de Cadetes");
            }
        }
        public override void GuardarClientes(List<Cliente> clientes)
        {
            try
            {
                using(var writer = new StreamWriter(clienteCSVFilePath))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(clientes);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex,"Error al escribir en el archivo de Clientes");
            }
        }
        public override void GuardarPedidos(List<Pedido> pedidos)
        {
            try
            {
                using(var writer = new StreamWriter(pedidosCSVFilePath))
                using (var csv = new CsvWriter(writer,new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(pedidos);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error al escribir en el archivo de pedidos");
                
            }
        }
    }
}