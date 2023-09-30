using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaAPI.Repositories;
using CadeteriaAPI.models;

namespace CadeteriaAPI.Repositories
{
    public interface IPedidoRepository
    {
        Pedido GetPedido(int id);
        IEnumerable<Pedido> GetAllPedidos();
        void CreatePedido(Pedido pedido);
        bool UpdatePedido(int id, Pedido pedido);
        bool DeletePedido(int id);
        IEnumerable<Pedido> GetPedidoCliente(int idCliente);
    }
}