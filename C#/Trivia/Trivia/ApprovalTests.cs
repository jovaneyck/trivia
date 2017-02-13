using System;
using System.IO;
using System.Linq;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalUtilities.Utilities;
using Xunit;

namespace Trivia
{
    public class ApprovalTests
    {
        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void WorldIsSane()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            var seeded = new Random(1234567890);

            Enumerable
                .Range(1,100)
                .ForEach(run =>
                { 
                    Console.WriteLine($"Starting game {run}:");
                    new GameRunner(seeded).PlayGame();        
                });
            
            Approvals.Verify(output.GetStringBuilder().ToString());
        }     
    }
}