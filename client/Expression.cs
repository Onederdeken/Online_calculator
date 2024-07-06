using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace client;
public class Expression:HttpContent{
    public String expression;

    private Expression(String str){
        this.expression = str;
    }

    protected override Task SerializeToStreamAsync(Stream stream, TransportContext? context)
    {
        byte[] data = Encoding.UTF8.GetBytes(expression);
        return stream.WriteAsync(data, 0, data.Length);
    }

    protected override bool TryComputeLength(out long length)
    {
        length = Encoding.UTF8.GetByteCount(expression);
        return true;
    }
    public static (Expression exp, String Error) Create(String str){
        String Error = String.Empty;
        if(CheckExpression(str) == false){
            Error = "В выражении есть ошибка.Перепишите";
            return (null,Error);
        }
        return (new Expression(str),Error);
        
    }
    public static bool CheckExpression(String Str)
    {
        bool result = true;
        String patern = @"^(\s*(\d+(\.\d+)?|Pow\(\s*\d+(\.\d+)?\s*,\s*\d+(\.\d+)?\s*\)|[\+\-\*\/\^\(\)])\s*)+$";
        if(String.IsNullOrWhiteSpace(Str = Str.Replace(" ",""))){
            return false;
        }
        else if(!Regex.IsMatch(Str,patern)){
            return false;
        }
        else if(Str.Count(c=>c == '(') != Str.Count(c=>c == ')')){
            return false;
        }
        return result;
    }
}