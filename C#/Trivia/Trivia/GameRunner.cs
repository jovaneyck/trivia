using System;
using UglyTrivia;

namespace Trivia
{
    public class GameRunner
    {
        private static bool notAWinner;
        private readonly Random _random;

        public GameRunner()
            : this(new Random()) { }

        public GameRunner(Random rng)
        {
            _random = rng;
        }

        public static void Main(String[] args)
        {
            new GameRunner().PlayGame();
        }

        public void PlayGame()
        {
            Game aGame = new Game();

            aGame.add("Chet");
            aGame.add("Pat");
            aGame.add("Sue");

            do
            {
                aGame.roll(_random.Next(5) + 1);

                if (_random.Next(9) == 7)
                {
                    notAWinner = aGame.wrongAnswer();
                }
                else
                {
                    notAWinner = aGame.wasCorrectlyAnswered();
                }
            } while (notAWinner);
        }
    }
}
