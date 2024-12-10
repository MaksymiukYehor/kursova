using Lab1;
using System;
using System.Collections.Generic;

namespace Lab1
{
    public abstract class GameAccount
    {
        public string UserName { get; set; }
        private string password { get; }
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
            if (game.result)
            {
                CurrentRating += game.Rating;
            }
            else
            {
                CurrentRating -= game.Rating;
            }
        }
        
        public void WinGame(int rating)
        {
            CurrentRating += rating;
        }

        public void LoseGame(int rating)
        {
            CurrentRating -= rating;
        }  
    }
}