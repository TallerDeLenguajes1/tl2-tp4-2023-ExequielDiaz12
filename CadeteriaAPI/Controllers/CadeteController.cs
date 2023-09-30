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
    public class CadeteController : ControllerBase
    {
        private readonly ICadeteRepository _cadeteRepository;
        public CadeteController(ICadeteRepository cadeteRepository)
        {
            _cadeteRepository = cadeteRepository;
        }

        [HttpGet]
        public IActionResult GetAllCadetes()
        {
            try
            {
                var cadetes = _cadeteRepository.GetAllCadetes();
                return Ok(cadetes);
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
                var cadete = _cadeteRepository.GetCadete(id);

                if (cadete == null)
                {
                    return NotFound();
                }

                return Ok(cadete);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Cadete cadete)
        {
            try
            {
                _cadeteRepository.CreateCadete(cadete);
                return CreatedAtAction(nameof(Get), new { id = cadete.Id }, cadete);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
            }
        }
    
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Cadete cadete)
        {
            try
            {
                if (_cadeteRepository.UpdateCadete(id,cadete))
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
                if (_cadeteRepository.DeleteCadete(id))
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