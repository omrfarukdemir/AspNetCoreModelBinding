using AspNetCoreModelBinding.Infrastructure;
using AspNetCoreModelBinding.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreModelBinding.Controllers
{
    [Route("api/[controller]")]
    public class NumberController : Controller
    {
        //example
        //http://localhost:5000/api/number/calculate?number.first=3&number.second=3&number.op.add=true&number.op.double=false
        [HttpGet("calculate")]
        public string Get([ModelBinder(typeof(NumberBinder))]Number number)
        {
            var result = number.Op.Add ? number.First + number.Second : number.First - number.Second;

            return (number.Op.Double ? result * 2 : result).ToString();
        }
    }
}