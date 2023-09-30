using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace CadeteriaLib.models
{
    public abstract class AccesoADatos
    {
        public abstract List<Cadete> GetCadetes();
        public abstract List<Cliente> GetClientess();
        public abstract List<Pedido> GetPedidos();

        public abstract void GuardarCadetes(List<Cadete>cadetes);
        public abstract void GuardarClientes(List<Cliente> clientes);
        public abstract void GuardarPedidos(List<Pedido>pedidos);
    }
}