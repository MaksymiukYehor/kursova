using Lab1;
using System;
using System.Collections.Generic;
public class DbContext
{
    public List<Game> Games { get; set; }
    public List<GameAccount> Players { get; set; }

    public DbContext()
    {
        Players = new List<GameAccount>
        {
            //Додавання початкових даних
            new GameAccount("player1", "1234"),
            new GameAccount("player2", "1234"),
            new GameAccount("player3", "1234"),
            new GameAccount("player4", "1234")
        };

        Games = new List<Game>
        {
            
        };
    }
}       