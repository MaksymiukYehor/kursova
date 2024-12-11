namespace Lab1
{
    using System;
    using System.Linq;

    public abstract class Game
    {
        public int[,] board = new int[9, 9];
        public Random random = new Random();
        public GameAccount player { get; }
        public string type { get; set; }
        public bool Result { get; set; }
        public int id { get; }
        private static int ID = 0;
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

        public Game(string Type, GameAccount Player)
        {
            id = ++ID;
            type = Type;
            player = Player;
            Result = false;
        }

    
        public abstract void RemoveNumsFromBoard();
        public abstract int GetRating();
        public bool FillBoard(int row, int col)
        {
            if (row == 9) return true;

            int nextRow = col == 8 ? row + 1 : row;
            int nextCol = col == 8 ? 0 : col + 1;

            var numbers = Enumerable.Range(1, 9).OrderBy(x => random.Next()).ToArray();

            foreach (var num in numbers)
            {
                if (IsMoveValid(row, col, num))
                {
                    board[row, col] = num;

                    if (FillBoard(nextRow, nextCol)) return true;

                    board[row, col] = 0;
                }
            }
        return false;
        }
        public void DisplayBoard()
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

        public bool IsMoveValid(int row, int col, int num)
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

        public bool IsBoardFull()
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
        public HardGame(GameAccount player) : base("Hard", player) 
        {
            GetRating();
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
            Rating = 50;
            return Rating;
        }
    }

    public class TestGame : Game
    {
        public TestGame(GameAccount player) : base("Test", player) 
        {
            GetRating();
        }
        public override void RemoveNumsFromBoard()
        {
            int cellsToRemove = random.Next(2, 3);

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
            Rating = 5;
            return Rating;
        }
    }
}