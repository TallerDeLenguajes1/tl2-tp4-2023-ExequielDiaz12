using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeteriaAPI.models
{
    
    public class Pedido
    {
        public int Id { get; set; }
        public string Producto { get; set; }
        public string Descripcion { get; set;}
        public string Estado { get; set; }
        public int IdCliente { get; set; }
        public int IdCadete { get; set; }
    }
/*
    public Pedido()
    {
        Estado = "Pendiente";
    }

esto ne da un error:  los campos y métodos no pueden declararse directamente en un espacio de nombres en C#.
para solucionarlo debo hacer la asignacion de pendiente en el controlador

*/
}

