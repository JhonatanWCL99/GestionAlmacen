using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PruebaTecnicaSitec.Data;
using PruebaTecnicaSitec.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnicaSitec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly AlmacenDB _context;

        public VentasController(AlmacenDB context)
        {
            _context = context;
        }
        // GET: api/Ventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetVentas()
        {
            return await _context.Ventas.Include(d => d.detallesVenta).ToListAsync();
        }

        // GET api/Ventas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> GetVenta(int id)
        {
            var venta= await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }

            await _context.Entry(venta).Collection(d => d.detallesVenta).LoadAsync();
            // loads StudentAddress
            return venta;
        }

        // POST api/Ventas
        [HttpPost]
        public async Task<ActionResult<Venta>> PostVenta(Venta venta)
        {

            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Venta v = new Venta();
                    v.fecha = venta.fecha;
                    v.total = CalculateTotal(venta.detallesVenta);
                    double iva = 0.13;
                    v.total_neto = (float)(CalculateTotal(venta.detallesVenta) + CalculateTotal(venta.detallesVenta)*iva); //TotalNeto con recargo 13% (IVA)
                    _context.Ventas.Add(v);
                    await _context.SaveChangesAsync();

                    Venta lastVenta = await _context.Ventas.OrderByDescending(x => x.Id).Take(1).FirstAsync();

                    float oldTotalDetalleInventario= 0;
                    float newTotalDetalleInventario = 0;
                    int IdInventario = 0;
                    foreach (DetalleVenta detalleVenta in venta.detallesVenta)
                    {
                        Producto producto = await _context.Productos.FindAsync(detalleVenta.ProductoId);
                        if (producto == null) return NotFound();
                        DetalleInventario detalleInventario = await _context.DetallesInventario.Where(d => d.ProductoId== detalleVenta.ProductoId).FirstAsync();
                        if (detalleVenta.cantidad > detalleInventario.cantidad) return BadRequest($"Stock Insuficiente del producto con ID : {detalleVenta.ProductoId }");
                        oldTotalDetalleInventario += detalleInventario.subtotal;
                        detalleInventario.cantidad -= detalleVenta.cantidad;
                        detalleInventario.subtotal = detalleInventario.cantidad*producto.Costo;
                        IdInventario = detalleInventario.InventarioId;
                        newTotalDetalleInventario += detalleInventario.subtotal;
                        _context.DetallesInventario.Update(detalleInventario);
                        await _context.SaveChangesAsync();
                        DetalleVenta dVenta = new DetalleVenta();
                        dVenta.cantidad = detalleVenta.cantidad;
                        dVenta.precio = detalleVenta.precio;
                        dVenta.subtotal = detalleVenta.cantidad * detalleVenta.precio;
                        dVenta.VentaId = lastVenta.Id;
                        dVenta.ProductoId = detalleVenta.ProductoId;
                        _context.DetallesVenta.Add(dVenta);
                        await _context.SaveChangesAsync();
                    }
                    Inventario inventario = await _context.Inventarios.FindAsync(IdInventario);
                    inventario.total += -oldTotalDetalleInventario+newTotalDetalleInventario;
                    _context.Inventarios.Update(inventario);

                    await _context.SaveChangesAsync();
                    dbContextTransaction.Commit();
                    return lastVenta;

                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    Console.WriteLine(ex.Message);
                    return BadRequest(ex.Message);
                }
            }
        }

        private float CalculateTotal(IList<DetalleVenta> listDetalleVenta)
        {
            float total = 0;
            foreach (DetalleVenta d in listDetalleVenta)
            {
                total += d.cantidad*d.precio;
            }
            return total;
        }
    }
}
