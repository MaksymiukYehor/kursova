using Lab1;
using System;
using System.Collections.Generic;

namespace Lab1
{
    public class GameAccount
    {
        public string UserName { get; set; }
        public string Password { get; }
        private int currentRating = 1;
        public int CurrentRating
        {
            get
            {
                return currentRating;
            }
            set
            {
                if (value < 1)
                {
                    currentRating = 1;
                }
                else
                {
                    currentRating = value;
                }

            }
        }
        public int GamesCount => gamesHistory.Count;
        private readonly List<Game> gamesHistory;

        public GameAccount(string userName, string password)
        {
            UserName = userName;
            Password = password;
            gamesHistory = new List<Game>();
        }

        public void CalculateRating(Game game)
        {
            if (game.Result)
            {
                game.player.CurrentRating += game.Rating;
            }
            else
            {
                game.player.CurrentRating -= game.Rating;
            }
        }
    }
}