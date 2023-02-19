using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnicaSitec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        // GET: api/Ventas
        [HttpGet]
        public IEnumerable<string> GetVentas()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Ventas/5
        [HttpGet("{id}")]
        public string GetVenta(int id)
        {
            return "value";
        }

        // POST api/Ventas
        [HttpPost]
        public void PostVenta([FromBody] string value)
        {
        }
    }
}
