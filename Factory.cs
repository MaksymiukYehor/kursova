using Lab1;
using System;

namespace Factory
{
    public static class GameFactory
    {
        public static Game CreateGame(string type)
        {
            return type switch
            {
                "Hard" => new HardGame(currentPlayer),
                "Easy" => new EasyGame(currentPlayer),
                _ => throw new ArgumentException("Unknown game type")
            };
        }
    }
}
