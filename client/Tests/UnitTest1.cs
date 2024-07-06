
using client;
namespace Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {

        //Arrange
        List<String> input= new List<String>(){"2+2", "(2+3)", "2*Pow(2,2)", "4*(4-3)", "(2+3", "3*a", "(16-7)*4-1/d", "(16-7.5,3)", "2*Pow(2,2)+4*(4-3)"};
        List<bool> results = new List<bool>(){true,true,true,true,false,false,false,false, true};
        List<bool> output = new List<bool>();

        //Act
            foreach(var item in input){
                output.Add(Expression.CheckExpression(item));
            }

        //Asert
            Assert.Equal(results,output);


    }
}