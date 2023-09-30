using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CadeteriaAPI.models;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using CadeteriaAPI.Repositories;


namespace CadeteriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public IActionResult GetAllClientes()
        {
            try
            {
                var clientes = _clienteRepository.GetAllClientes();
                return Ok(clientes);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var cliente = _clienteRepository.GetCliente(id);

                if (cliente == null)
                {
                    return NotFound();
                }

                return Ok(cliente);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Cliente cliente)
        {
            try
            {
                _clienteRepository.CreateCliente(cliente);
                return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
            }
        }
    
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Cliente cliente)
        {
            try
            {
                if (_clienteRepository.UpdateCliente(id, cliente))
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
                if (_clienteRepository.DeleteCliente(id))
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

    }
}