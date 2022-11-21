using System;


namespace TicTacToe
{
   
    class Program
    {
        static void Main(string[] args)
        {
            List<string> board = GetNewBoard();
            string currentPlayer = "x";

            while (!IsGameOver(board))
            {
                DisplayBoard(board);

                int choice = GetMoveChoice(currentPlayer);
                MakeMove(board, choice, currentPlayer);

                currentPlayer = GetNextPlayer(currentPlayer);
            }

            DisplayBoard(board);
            Console.WriteLine("Good game");
        }

        
        static List<string> GetNewBoard()
        {
            List<string> board = new List<string>();

            for (int i = 1; i <= 9; i++)
            {
                board.Add(i.ToString());
            }

            return board;
        }

        
        static void DisplayBoard(List<string> board)
        
        {
            
            for(int j = 0; j < 9; j=j+3)
            {
               Console.WriteLine($"{board[j]}|{board[(j+1)]}|{board[(j+2)]}"); 
               if(j<6)
               {
               for(int k = 0; k<1; k++)
               {
                     Console.WriteLine("-+-+-");
               }

               }
            }
            
           
        }

        
        static bool IsGameOver(List<string> board)
        {
            bool isGameOver = false;

            if (IsWinner(board, "x") || IsWinner(board, "o") || IsTie(board))
            {
                isGameOver = true;
            }

            return isGameOver;
        }

       
        static bool IsWinner(List<string> board, string player)
        {
  
        
            bool isWinner = false;


            if ((board[0] == player && board[1] == player && board[2] == player)
                || (board[3] == player && board[4] == player && board[5] == player)
                || (board[6] == player && board[7] == player && board[8] == player)
                || (board[0] == player && board[3] == player && board[6] == player)
                || (board[1] == player && board[4] == player && board[7] == player)
                || (board[2] == player && board[5] == player && board[8] == player)
                || (board[0] == player && board[4] == player && board[8] == player)
                || (board[2] == player && board[4] == player && board[6] == player)
                )
            {
                isWinner = true;
            }

            return isWinner; 
        }

   
        static bool IsTie(List<string> board)
        {
  
            bool foundDigit = false;

            foreach (string value in board)
            {
                if (char.IsDigit(value[0]))
                {
                    foundDigit = true;
                    break;
                }
            }

            return !foundDigit;
        }


        static string GetNextPlayer(string currentPlayer)
        {
            string nextPlayer = "x";

            if (currentPlayer == "x")
            {
                nextPlayer = "o";
            }

            return nextPlayer;
        }


        static int GetMoveChoice(string currentPlayer)
        {
            Console.Write($"{currentPlayer}'s turn to choose a square (1-9): ");
            string move_string = Console.ReadLine();

            int choice = int.Parse(move_string);
            return choice;
        }

        
        static void MakeMove(List<string> board, int choice, string currentPlayer)
        {
            
            int index = choice - 1;

            
            board[index] = currentPlayer;
        }
    }
}