namespace WebApi.Abstractions{
    public interface IServiceCalculate{
       public  Task<String> calculate(String Expression);
    }
}