namespace Lab1
{
    using System;
    using System.Linq;

    public abstract class Game
    {
        private int[,] board = new int[9, 9];
        private Random random = new Random();
        public GameAccount Player { get; }
        public string type { get; set; }
        public bool Result { get; set; }
        private int id { get; set; }
        private int rating;
        public int Rating
        {
           get
            {
                return rating;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Рейтинг не може бути менше нуля.");
                }
                else
                {
                    rating = value;
                }
            } 
        }

        public Game(string type, GameAccount Player)
        {
            ID = ++id;
            Type = type;
            player = Player;
            Result = result;
            GenerateBoard();
        }

        private void GenerateBoard()
        {
            FillBoard(0, 0);
            RemoveNumbersFromBoard();
        }

        public abstract void RemoveNumsFromBoard();
        public abstract int GetRating();

        private void DisplayBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                if (i % 3 == 0 && i != 0) Console.WriteLine("------+-------+------");
                for (int j = 0; j < 9; j++)
                {
                    if (j % 3 == 0 && j != 0) Console.Write("| ");
                    Console.Write(board[i, j] == 0 ? ". " : board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private bool IsMoveValid(int row, int col, int num)
        {
            if (board[row, col] != 0) return false;

            for (int i = 0; i < 9; i++)
            {
                if (board[row, i] == num || board[i, col] == num) return false;
            }

            int startRow = (row / 3) * 3;
            int startCol = (col / 3) * 3;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[startRow + i, startCol + j] == num) return false;
                }
            }
            return true;
        }

        private bool IsBoardFull()
        {
            foreach (var cell in board)
            {
                if (cell == 0) return false;
            }
            return true;
        }
    }

    //похідні класи
    public class HardGame : Game
    {
        public HardGame() : base( "Hard") 
        {
            GetRating();
            if (Result)
            {
                Player.WinGame;
            }
            else
            {
                Player.LoseGame;
            };
        }
        public override void RemoveNumsFromBoard()
        {
            int cellsToRemove = random.Next(40, 50);

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
            Rating = 50;
            return Rating;
        }
    }

    public class EasyGame : Game
    {
        public EasyGame() : base("Easy")
        {
            GetRating();
            if (Result) 
            { 
                Player.WinGame;
            }
            else 
            { 
                Player.LoseGame;
            };
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
            Rating = 50;
            return Rating;
        }
    }
}