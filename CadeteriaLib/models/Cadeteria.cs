using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeteriaLib.models
{
    public class Cadeteria
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? NumeroTelefono { get; set; }
        public List<Cadete> ListaCadetes { get; set; }
        public List<Pedido> ListaPedidos { get; set; }
        public List<Cliente> ListaClientes { get; set; }

        public Cadeteria(){
            ListaCadetes = new List<Cadete>();
            ListaPedidos = new List<Pedido>();
            ListaClientes = new List<Cliente>();
        }
        public Cadeteria(int id,string nombre,string telefono){
            Id = id;
            Nombre = nombre;
            NumeroTelefono = telefono;
            ListaCadetes = new List<Cadete>();
            ListaPedidos = new List<Pedido>();
            ListaClientes = new List<Cliente>();
        }

        /************FUNCIONES*************/
        public void AgregarCadete(Cadete cadete){
            ListaCadetes.Add(cadete);
        }
        public void AsignarCadeteAPedido(int idPedido, int idCadete){
            Cadete? cadete = ListaCadetes.FirstOrDefault(c =>c.Id == idCadete);
            Pedido? pedido = ListaPedidos.FirstOrDefault(p =>p.Id == idPedido);

            if(cadete == null){throw new ArgumentException("Cadete no encontrado");}
            if(pedido == null){throw new ArgumentException("Pedido no encontradop");}

            pedido.ReasignarCadete(cadete);
        }
        public double JornalACobrar(int idCadete){
            Cadete? cadete = ListaCadetes.FirstOrDefault(c => c.Id == idCadete);
            if(cadete == null){throw new ArgumentException("Cadete no encontrado");}

            double jornal = ListaPedidos.Count(p => p.CadeteAsignado == cadete && p.Estado == EstadoPedido.Entregado)*500;
            return jornal;
        }
        public void AgregarCliente(Cliente cliente){
            ListaClientes.Add(cliente);
        }
        public void AgregarPedido(Pedido pedido){
            ListaPedidos.Add(pedido);
        }
    }
}