using NCalc;
using WebApi.Abstractions;

namespace WebApi.Service{
    public  class ServiceCalculate:IServiceCalculate{


        public async Task<String> calculate(String Expression){
            Expression expr = new Expression(Expression);
            
            String result = Math.Round(Decimal.Parse(expr.Evaluate().ToString()),3).ToString();
            return result;
        }
    }
}