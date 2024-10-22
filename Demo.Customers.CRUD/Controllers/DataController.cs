using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo.Customers.CRUD.Models;
using Demo.Customers.CRUD.Helpers;

namespace Demo.Customers.CRUD.Controllers
{
    [ApiController]
    public class DataController : ControllerBase
    {
        [Route("api/[controller]/Get")]
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var customers = JsonStorageHelper.ReadCustomerData(); //  This operation should not fail
            return customers;
        }

        [Route("api/[controller]/Post")]
        [HttpPost]
        public IActionResult Post([FromBody] Customer value)
        {
            try
            {
                var result = JsonStorageHelper.AddCustomerData(value);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(400);
            }
        }

        [Route("api/[controller]/Put")]
        [HttpPut]
        public IActionResult Put([FromBody] Customer value)
        {
            try
            {
                var result = JsonStorageHelper.UpdateCustomerData(value);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(400);
            }
        }

        [Route("api/[controller]/Delete")]
        [HttpDelete]
        public IActionResult Delete([FromBody] int id)
        {
            try
            {
                var result = JsonStorageHelper.DeleteCustomerData(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(400);
            }
        }
    }
}
