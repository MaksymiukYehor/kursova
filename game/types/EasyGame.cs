using Lab1;
using System;
using System.Linq;

public class EasyGame : Game
    {
        public EasyGame(GameAccount player) : base("Easy", player)
        {
            GetRating();
        }
        public override void RemoveNumsFromBoard()
        {
            int cellsToRemove = random.Next(20, 30);

            for (int i = 0; i < cellsToRemove; i++)
            {
                int row, col;

                do
                {
                    row = random.Next(0, 9);
                    col = random.Next(0, 9);
                } while (board[row, col] == 0);

                board[row, col] = 0;
            }
        }
        public override int GetRating()
        {
            Rating = 30;
            return Rating;
        }
    }