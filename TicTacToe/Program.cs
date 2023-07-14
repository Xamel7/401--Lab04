using System;

namespace TicTacToe
{
    class Player
    {
        public string Name;
        public string Marker;
        public Player(string name, string marker)
        {
            Name = name;
            Marker = marker;
        }
    }

    internal class Program
    {
        public static string[][] Board;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To The Game!");
            Console.Write("Player1's Name: ");
            string player1name = Console.ReadLine();
            Player player1 = new Player(player1name, "X");

            Console.Write("Player2's Name: ");
            string player2name = Console.ReadLine();
            Player player2 = new Player(player2name, "O");

            Console.WriteLine("====== {0} vs {1} ======", player1.Name, player2.Name);

            Board = new string[][]
            {
                new string[] {"1", "2", "3"},
                new string[] {"4", "5", "6"},
                new string[] {"7", "8", "9"}
            };

            Console.WriteLine("Your playing field.");
            DisplayBoard();

            Player currentPlayer = player1;
            string winner = null;

            while (winner == null)
            {
                Console.WriteLine("It's {0}'s turn!", currentPlayer.Name);

                Console.WriteLine("Please choose a slot.");
                DisplayBoard();
                string selectedSlot = Console.ReadLine();

                if (IsSlotOpen(selectedSlot))
                {
                    UpdateBoard(selectedSlot, currentPlayer.Marker);
                }
                else
                {
                    Console.WriteLine("Invalid move.");
                    continue; 
                }

                DisplayBoard();
                winner = CheckForWinner();

                if (winner == null)
                {
                    if (currentPlayer == player1)
                    {
                        currentPlayer = player2;
                    }
                    else if (currentPlayer == player2)
                    {
                        currentPlayer = player1;
                    }
                }
            }

            if (winner == "draw")
            {
                Console.WriteLine("Darn Draw!");
            }
            else
            {
                Console.WriteLine("Well Done, {0}! You won!", winner);
            }
        }

        static void DisplayBoard()
        {
            Console.WriteLine("|{0}||{1}||{2}|", Board[0][0], Board[0][1], Board[0][2]);
            Console.WriteLine("|{0}||{1}||{2}|", Board[1][0], Board[1][1], Board[1][2]);
            Console.WriteLine("|{0}||{1}||{2}|", Board[2][0], Board[2][1], Board[2][2]);
        }

        static bool IsSlotOpen(string selectedSlot)
        {
            foreach (var row in Board)
            {
                foreach (var cell in row)
                {
                    if (cell == selectedSlot && (cell == "X" || cell == "O"))
                    {
                        return false;
                    }
                }
            }
            return true; 
        }

        static void UpdateBoard(string selectedSlot, string marker)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (Board[row][col] == selectedSlot)
                    {
                        Board[row][col] = marker;
                        return;
                    }
                }
            }
        }

        static string CheckForWinner()
        {
            
            for (int row = 0; row < 3; row++)
            {
                if (Board[row][0] == Board[row][1] && Board[row][1] == Board[row][2])
                {
                    return Board[row][0];
                }
            }

            
            for (int col = 0; col < 3; col++)
            {
                if (Board[0][col] == Board[1][col] && Board[1][col] == Board[2][col])
                {
                    return Board[0][col];
                }
            }

            
            if ((Board[0][0] == Board[1][1] && Board[1][1] == Board[2][2]) ||
                (Board[0][2] == Board[1][1] && Board[1][1] == Board[2][0]))
            {
                return Board[1][1];
            }

            
            bool isDraw = true;
            foreach (var row in Board)
            {
                foreach (var cell in row)
                {
                    if (cell != "X" && cell != "O")
                    {
                        isDraw = false;
                        break;
                    }
                }
            }
            if (isDraw)
            {
                return "draw";
            }

            return null;
        }
    }
}
