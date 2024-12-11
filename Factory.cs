using Lab1;
using System;

namespace Factory
{
    public static class GameFactory
    {
        public static Game CreateGame(string type, GameAccount player)
        {
            return type switch
            {
                "Hard" => new HardGame(player),
                "Easy" => new EasyGame(player),
                "Test" => new TestGame(player),
                _ => throw new ArgumentException("Unknown game type")
            };
        }
    }
}
