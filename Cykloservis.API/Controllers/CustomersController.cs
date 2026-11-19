using Cykloservis.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cykloservis.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private static readonly List<Customer> _customers = new List<Customer>
        {
            new Customer { Id = 1, FirstName = "Jan", LastName = "Novák", Phone = "+420777111222", Email = "jan.novak@example.com" },
            new Customer { Id = 2, FirstName = "Petr", LastName = "Svoboda", Phone = "+420608999888", Email = "petr.svoboda@example.com" },
            new Customer { Id = 3, FirstName = "Eva", LastName = "Dvořáková", Phone = "+420731456789", Email = null }
        };

        [HttpGet]
        public ActionResult<List<Customer>> GetAll()
        {
            return Ok(_customers);
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetById(int id)
        {
            foreach (var c in _customers)
            {
                if (c.Id == id)
                {
                    return Ok(c);
                }
            }

            return NotFound();
        }
    }
}
