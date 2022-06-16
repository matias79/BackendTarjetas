using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendTarjetas;
using BackendTarjetas.Models;

namespace BackendTarjetas.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class tarjetaCreditoController : ControllerBase
    {
        private readonly conexionDBcontex _context;

        public tarjetaCreditoController(conexionDBcontex context)
        {
            _context = context;
        }

        // GET: api/tarjetaCredito
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tarjetaCredito>>> GetTarjetaCredito()
        {
            return await _context.TarjetaCredito.ToListAsync();
        }

        // GET: api/tarjetaCredito/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tarjetaCredito>> GettarjetaCredito(int id)
        {
            var tarjetaCredito = await _context.TarjetaCredito.FindAsync(id);

            if (tarjetaCredito == null)
            {
                return NotFound();
            }

            return tarjetaCredito;
        }

        // PUT: api/tarjetaCredito/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttarjetaCredito(int id, tarjetaCredito tarjetaCredito)
        {
            if (id != tarjetaCredito.Id)
            {
                return BadRequest();
            }

            _context.Entry(tarjetaCredito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tarjetaCreditoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/tarjetaCredito
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tarjetaCredito>> PosttarjetaCredito(tarjetaCredito tarjetaCredito)
        {
            _context.TarjetaCredito.Add(tarjetaCredito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettarjetaCredito", new { id = tarjetaCredito.Id }, tarjetaCredito);
        }

        // DELETE: api/tarjetaCredito/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetarjetaCredito(int id)
        {
            var tarjetaCredito = await _context.TarjetaCredito.FindAsync(id);
            if (tarjetaCredito == null)
            {
                return NotFound();
            }

            _context.TarjetaCredito.Remove(tarjetaCredito);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tarjetaCreditoExists(int id)
        {
            return _context.TarjetaCredito.Any(e => e.Id == id);
        }
    }
}
