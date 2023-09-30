using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CadeteriaAPI.models;
using CadeteriaAPI.Repositories;

namespace CadeteriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;
        public PedidoController(IPedidoRepository pedidoRepository)
        {
            
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        public IActionResult GetAllPedidos()
        {
            try
            {
                var pedidos = _pedidoRepository.GetAllPedidos();
                return Ok(pedidos);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) //busca un pedido por id del pedido
        {
            try
            {
                var pedido = _pedidoRepository.GetPedido(id);

                if (pedido == null)
                {
                    return NotFound();
                }

                return Ok(pedido);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{idCliente}")]
        public IActionResult GetPedidosClientes(int idCliente)
        {
            try
            {
                var pedidos = _pedidoRepository.GetPedidoCliente(idCliente);
                return Ok(pedidos);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Pedido pedido)
        {
            try
            {
                pedido.Estado = "Pendiente";
                _pedidoRepository.CreatePedido(pedido);
                return CreatedAtAction(nameof(Get), new { id = pedido.Id }, pedido);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
            }
        }
    
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pedido pedido)
        {
            try
            {
                if (_pedidoRepository.UpdatePedido(id,pedido))
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_pedidoRepository.DeletePedido(id))
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("cancel/{id}")]
        public IActionResult CancelPedido(int idPedido, int idCliente)
        {
            try
            {
                var pedido = _pedidoRepository.GetPedido(idPedido);
                if (pedido == null)
                {
                    return NotFound();
                }

                if(pedido.IdCliente != idCliente)
                {
                    return Unauthorized();
                }

                pedido.Estado = "Cancelado";
                _pedidoRepository.UpdatePedido(idPedido,pedido);

                return Ok();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}