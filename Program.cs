using System;

namespace CombineGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.start();
            game.play();
            game.end();
        }
    }
}
