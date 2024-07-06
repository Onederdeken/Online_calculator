

using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace client;
public class Query{
    protected readonly HttpClient _client;
    public Query(HttpClient client){
        this._client = client;
    }

    public async Task GetSolution(Expression expression){
        RequestSolution request = new RequestSolution(
            expression.expression
        );
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true, // Игнорирует регистр имён свойств
            WriteIndented = true // Форматирует JSON с отступами
        };
        String json = JsonSerializer.Serialize(request);
        HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
        using var result = await _client.PostAsync("http://localhost:5062/Solution/api/GetSolution", content);
        if(result.IsSuccessStatusCode){
            string responseData = await result.Content.ReadAsStringAsync();
            var otvet = JsonSerializer.Deserialize<ResponseSolution>(responseData,options);
            Console.WriteLine(expression.expression + "=" + otvet.Result); 
        }
        else
        {
            Console.WriteLine("Error" + result.StatusCode);
        }
        
    }
}