


using WebApi.Service;

public class CalculateTest{

    [Fact]
    public async Task CheckAnswerCalculate()
    {
        // Arrange
            ServiceCalculate calculate = new ServiceCalculate();
            List<String> expression = new List<string>(){"2+2", "15-3", "2*9", "9/2", "10/2", "15*0", "Pow(2,3)", "(25+70)/3 + 3*Pow(5,2) - 31"};
            List<String> expected = new List<string>(){"4","12", "18", "4,5","5","0", "8", "75,667"};
            List<String> results = new List<string>();

            // Act
            foreach (var item in expression)
            {
                    results.Add(await calculate.calculate(item));
            }
            // Assert
            Assert.Equal(expected,results);
    }
}
