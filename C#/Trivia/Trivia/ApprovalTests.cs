namespace Trivia
{
    public class ApprovalTests
    {
        [Fact]
        public async Task WorldIsSane()
        {
            //Arrange
            using var output = new StringWriter();
            Console.SetOut(output);
            var seeded = new Random(1234567890);

            //Act
            foreach (var run in Enumerable.Range(1, 100))
            {
                await output.WriteLineAsync($"Starting game {run}:");
                new GameRunner(seeded).PlayGame();
            }

            //Assert
            var logs = output.GetStringBuilder().ToString();
            // testOutputHelper.WriteLine(logs);
            await Verify(logs);
        }
    }
}
