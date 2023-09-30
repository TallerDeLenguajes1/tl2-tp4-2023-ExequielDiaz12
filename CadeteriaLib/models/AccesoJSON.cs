using Newtonsoft.Json;
using Serilog;

namespace CadeteriaLib.models
{
    public class AccesoJSON : AccesoADatos
    {
        private string clienteJsonFilePath = "datos/clientes.json";
        private string cadeteJsonFilePath = "datos/cadetes.json";
        private string pedidosJsonFilePath = "datos/pedidos.json";

        private ILogger logger;
        public AccesoJSON(){
            logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        }

        public override List<Cadete> GetCadetes()
        {
            try
            {
                if (File.Exists(cadeteJsonFilePath))
                {
                    List<Cadete>? cadetes;

                    using (var reader = new StreamReader(cadeteJsonFilePath))
                    {
                        string json = reader.ReadToEnd();
                        cadetes = JsonConvert.DeserializeObject<List<Cadete>>(json);
                    }

                    return cadetes;
                }
                else
                {
                    return new List<Cadete>();
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
                if (File.Exists(clienteJsonFilePath))
                {
                    List<Cliente>? clientes;

                    using (var reader = new StreamReader(clienteJsonFilePath))
                    {
                        string json = reader.ReadToEnd();
                        clientes = JsonConvert.DeserializeObject<List<Cliente>>(json);
                    }

                    return clientes;
                }
                else
                {
                    return new List<Cliente>();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex,"Error al querer acceder al registro clientes");
                return new List<Cliente>();
            }
        }
        public override List<Pedido> GetPedidos()
        {
            try
            {
                if (File.Exists(pedidosJsonFilePath))
                {
                    List<Pedido>? pedidos;

                    using (var reader = new StreamReader(pedidosJsonFilePath))
                    {
                        string json = reader.ReadToEnd();
                        pedidos = JsonConvert.DeserializeObject<List<Pedido>>(json);
                    }

                    return pedidos;
                }
                else
                {
                    return new List<Pedido>();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex,"Error al querer acceder al registro pedidos");
                return new List<Pedido>();
            }
        }
        public override void GuardarCadetes(List<Cadete> cadetes)
        {
            try
            {
                string json = JsonConvert.SerializeObject(cadetes, Formatting.Indented);

                File.WriteAllText(cadeteJsonFilePath, json);
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Error al guardar clientes en JSON: {ex.Message}");
            }
        }
        public override void GuardarClientes(List<Cliente> clientes)
        {
            try
            {
                string json = JsonConvert.SerializeObject(clientes, Formatting.Indented);

                File.WriteAllText(clienteJsonFilePath, json);
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Error al guardar clientes en JSON: {ex.Message}");
            }
        }
        public override void GuardarPedidos(List<Pedido> pedidos)
        {
            try
            {
                string json = JsonConvert.SerializeObject(pedidos, Formatting.Indented);

                File.WriteAllText(pedidosJsonFilePath, json);
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Error al guardar clientes en JSON: {ex.Message}");
            }
        }
    }
}