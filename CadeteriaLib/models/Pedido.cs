using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeteriaLib.models
{
    public enum EstadoPedido
    {
        Pendiente,
        Viajando,
        Entregado
    }
    public class Pedido
    {
        private static int PedidosCreados = 001;
        public int Id { get; set; }
        public string? Producto { get; set; }
        public EstadoPedido Estado { get; set; }
        public Cadete? CadeteAsignado { get;private set; }
        public Cliente? Cliente { get; set; }

        /**********CONSTRUCTOR******************/
        public Pedido(){}

        public Pedido(string producto, Cliente cliente){
            Id = PedidosCreados++;
            Producto = producto;
            Estado = EstadoPedido.Pendiente;
            Cliente = cliente;
            CadeteAsignado = new Cadete();
        }
        

        /*************** FUNCIONES *****************/

        public void CambiarEstadoPedido(EstadoPedido nuevoEstado){
            this.Estado = nuevoEstado;
        }//¿cómo podría hacer que solo el cadete asignado pudiera cambiar el estado?

        public void ReasignarCadete(Cadete nuevoCadete){
            CadeteAsignado = nuevoCadete;
        }//esto debería ser realizado por la clase cadeteria

        public string? GetDireccionCliente(){
            return Cliente != null? Cliente.Direccion : null;
        }

        public string? GetNombreCliente(){
            return Cliente != null? Cliente.Nombre : null;
        }

        public string? GetApellidoCliente(){
            return Cliente != null? Cliente.Apellido : null;
        }

        public string? GetTelefonoCliente(){
            return Cliente != null? Cliente.NumeroTelefono : null;
        }
    
        
    }
}