using ConsoleLibrary;
using Vector;

namespace TicTacToeGame {
    class TicTacToeGame {
        private readonly int _boardSize;
        private readonly int _winningLength;

        public int XWins { get; private set; }
        public int OWins { get; private set; }


        public TicTacToeGame(int boardSize, int winningLength) { 
            _boardSize = boardSize;
            _winningLength = winningLength;
        }

        public void StartRound() { 
            Board gameBoard = new(_boardSize, _winningLength);

            GameObject? winner;
            while (true) {
                if (gameBoard.CheckForRow(out winner)) break;
                if (gameBoard.IsFilled) break;

                Console.WriteLine($"Make it to {_winningLength} in a row!\nIt's {gameBoard.CurrentSign}'s turn: \n{gameBoard.ToString()}");
                MakeChoice(gameBoard);

                Console.Clear();
            }

            Console.WriteLine(gameBoard.ToString(false));
            if (winner != null) {
                Console.WriteLine($"Congrats, {winner}, you have won!\n");

                if (winner == GameObject.X) XWins++;
                else OWins++;
            } else {
                Console.WriteLine("Tie!\n");
            }
        }

        private static void MakeChoice(Board gameBoard) {
            bool valid = false;

            while (!valid) {
                int cell = ConsoleHelper.GetInt("Enter cell number: ", 1, gameBoard.GreatestCellNumber);
                valid = gameBoard.SetSign(cell);
            }
        }
    }
}