using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeteriaLib.models
{
    public class Cadete
    {
        private static int ContadorCadete = 1;
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? NumeroTelefono { get; set; }

        public Cadete(){}
        public Cadete(string nombre, string telefono){
            Id = ContadorCadete++;
            Nombre = nombre;
            NumeroTelefono = telefono;
        }
    }
}