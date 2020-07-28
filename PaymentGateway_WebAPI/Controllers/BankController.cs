using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway_DataAccess;
using PaymentGateway_Service;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentGateway_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IPaymentService paymentService;
        private readonly IBankService bankService;

        public BankController(IBankService bankService, IPaymentService paymentService)
        {
            this.paymentService = paymentService;
            this.bankService = bankService;
        }
        // GET: api/<BankController>
        [HttpGet]
        [Route("")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BankController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<BankController>
        [HttpPost]
        [Route("")]
        public async Task<OkObjectResult> Create([FromBody] Bank bank)
        {
            //if (!ModelState.IsValid)
            //{
            //    return (IHttpActionResult)BadRequest(ModelState);
            //}
            Console.WriteLine(bank);
            Console.Write("*********************************************");
            Console.Write("***************************************************");
            var created = await bankService.AddAsyncBank(bank);
            return Ok(created);
        }
    }

        //// PUT api/<BankController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<BankController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    //}
}
