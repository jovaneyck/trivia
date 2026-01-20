using Xunit.Abstractions;

namespace Trivia
{
    public class ApprovalTests(ITestOutputHelper testOutputHelper)
    {
        [Fact]
        public Task WorldIsSane()
        {
            //Arrange
            var output = new StringWriter();
            Console.SetOut(output);
            var seeded = new Random(1234567890);

            //Act
            foreach (var run in Enumerable.Range(1, 100))
            {
                output.WriteLine($"Starting game {run}:");
                new GameRunner(seeded).PlayGame();        
            }

            //Assert
            var logs = output.GetStringBuilder().ToString();
            // testOutputHelper.WriteLine(logs);
            return Verify(logs);
        }     
    }
}