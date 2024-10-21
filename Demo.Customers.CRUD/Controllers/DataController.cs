using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo.Customers.CRUD.Models;

namespace Demo.Customers.CRUD.Controllers
{
    [ApiController]
    public class DataController : ControllerBase
    {
        [Route("api/[controller]/Get")]
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var customers = new List<Customer>();
            customers.Add(new Customer { Name = "Joe Bloggs Heating", Address = "2 Bakewell Close, Coventry" });
            customers.Add(new Customer { Name = "Will Smith Industries", Address = "5 The Road, London" });
            customers.Add(new Customer { Name = "Jane Jones Cars", Address = "5 The Street, Manchester" });
            customers.Add(new Customer { Name = "Jack Smith Limited", Address = "8 Chine Street, Birmigham" });

            return customers;
        }

        [Route("api/[controller]/Post")]
        [HttpPost]
        public void Post([FromBody] Customer value)
        {
        }

        [Route("api/[controller]/Put")]
        [HttpPut]
        public void Put([FromBody] Customer value)
        {
        }

        [Route("api/[controller]/Delete")]
        [HttpDelete]
        public void Delete([FromBody]int id)
        {
        }
    }
}
