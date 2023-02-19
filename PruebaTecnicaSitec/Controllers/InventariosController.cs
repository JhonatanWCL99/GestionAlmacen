using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSitec.Data;
using PruebaTecnicaSitec.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnicaSitec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventariosController : ControllerBase
    {
        private readonly AlmacenDB _context;

        public InventariosController(AlmacenDB context)
        {
            _context = context;
        }
        // GET: api/Inventarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventario>>> GetInventarios()
        {
            return await _context.Inventarios.Include(d => d.detallesInventario).ToListAsync();
        }

        // GET api/Inventarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventario>> GetInventario(int id)
        {
            var inventario = await _context.Inventarios.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }

            await _context.Entry(inventario).Collection(d => d.detallesInventario).LoadAsync();
            // loads StudentAddress
            return inventario;
        }

        // POST api/Inventarios
        [HttpPost]
        public async Task<ActionResult<Inventario>> PostInventario(Inventario inventario)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Inventario i = new Inventario();
                    i.fecha = inventario.fecha;
                    i.total = CalculateTotal(inventario.detallesInventario);
                    _context.Inventarios.Add(i);
                    await _context.SaveChangesAsync();

                    Inventario lastInventario = await _context.Inventarios.OrderByDescending(x => x.Id).Take(1).FirstAsync();

                    foreach (DetalleInventario detalleInventario in inventario.detallesInventario)
                    {
                        DetalleInventario dinventario = new DetalleInventario();
                        var producto = await _context.Productos.FindAsync(detalleInventario.ProductoId);
                        if (producto == null)
                        {
                            return NotFound();
                        }
                        dinventario.cantidad = detalleInventario.cantidad;
                        dinventario.subtotal = detalleInventario.cantidad * producto.Costo;
                        dinventario.ProductoId = detalleInventario.ProductoId;
                        dinventario.InventarioId = lastInventario.Id;

                        _context.DetallesInventario.Add(dinventario);
                        await _context.SaveChangesAsync();
                    }

                    await _context.SaveChangesAsync();
                    dbContextTransaction.Commit();

                    return lastInventario;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    Console.WriteLine(ex.Message);
                    return BadRequest(ex.Message);
                }
            }
        }


        // DELETE api/Inventarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventario(int id)
        {
            var inventario = await _context.Inventarios.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }

            _context.Inventarios.Remove(inventario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private float CalculateTotal(IList<DetalleInventario> listDetalleInventario)
        {
            float total = 0;
            foreach (DetalleInventario d in listDetalleInventario)
            {
                var p = _context.Productos.Find(d.ProductoId);
                total += p.Costo * d.cantidad;
            }
            return total;
        }
    }
}
