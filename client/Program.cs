// See https://aka.ms/new-console-template for more information

namespace client;
public class Client{
    protected static HttpClient? client;
    protected static Query? query;
    public static async Task Main(){
        var socketsHandler = new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(2)
        };
        client = new HttpClient(socketsHandler);
        query = new Query(client);
        await start();
    }
    protected static async Task start(){
        while(true){
            Console.WriteLine("приветствую вас в консоьном калькуляторе \nДля составения математических выражений используйте:\n\tцифры 0-9\n\tЗнаки + - * / ()\n\tPow(x,y) где x чисо возводимое в степень y\nДля выхода введите 0\nВаше выражение:");
            String expression = Console.ReadLine();
            if(expression == "0"){
                break;
            }
            (Expression exp, String error) = Expression.Create(expression);
            if(String.IsNullOrEmpty(error)){
                await query.GetSolution(exp);
            }
            else{
                Console.WriteLine(error, "попробуйте написать еще раз");
            }
        }
    }
}