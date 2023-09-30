using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeteriaLib.models
{
    public class Cliente
    {
        private static int ContadorCliente = 1;
        public int Id { get; set; }
        public string? Apellido { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? NumeroTelefono { get; set; }
        

        /************CONSTRUCTOR***************/
        public Cliente(){}

        public Cliente(string apellido, string nombre, string direccion, string numero){
            this.Id = ContadorCliente++;
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.NumeroTelefono = numero;
        }

        /*************FUNCIONES**************/
    }
}