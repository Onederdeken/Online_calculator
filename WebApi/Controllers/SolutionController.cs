
using Microsoft.AspNetCore.Mvc;
using WebApi.Abstractions;
using WebApi.Request;
using WebApi.Responses;
using WebApi.Service;

namespace WebApi.Controller{
    [ApiController]
    [Route("[controller]/")]
    public class SolutionController:ControllerBase{
        protected readonly IServiceCalculate _ServiceCalculate;
        

        public SolutionController(IServiceCalculate serviceCalculate){
            this._ServiceCalculate = serviceCalculate;
        }
        [Route("api/GetSolution")]
        [HttpPost]
        public async Task<ActionResult<ResponseSolution>> GetSolition([FromBody]RequstSolution request){
            var res = await _ServiceCalculate.calculate(request.Expresion); 
            var response = new ResponseSolution(
                res
            );
            Console.WriteLine("+1");
            return  Ok(response);
        }



    }
}