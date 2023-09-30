using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaAPI.models;
using CadeteriaAPI.Repositories;

namespace CadeteriaAPI.Repositories
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> GetAllClientes();
        Cliente GetCliente(int id);
        void CreateCliente(Cliente cliente);
        bool UpdateCliente(int id, Cliente cliente);
        bool DeleteCliente(int id);
    }
}