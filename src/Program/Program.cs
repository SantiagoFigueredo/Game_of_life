using System;
using System.Text;
using System.Threading;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            // Importar archivo de texto con el tablero
            Board board = File.Import("assets/board.txt");

            // Inicializar la lógica del juego
            GameLogic game = new GameLogic(board);

            // Iniciar el loop principal del juego
            while (true)
            {
                Console.Clear();
                // Dibujar el tablero en la consola
                DrawBoard(game.Board);

                // Calcular la siguiente generación
                game.NextGeneration();

                // Esperar un tiempo para que el juego no avance demasiado rápido
                Thread.Sleep(300);
            }
        }

        static void DrawBoard(Board board)
        {
            int width = board.Width;
            int height = board.Height;
            StringBuilder s = new StringBuilder();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (board[x, y])
                    {
                        s.Append("|X|");
                    }
                    else
                    {
                        s.Append("___");
                    }
                }
                s.Append("\n");
            }
            Console.WriteLine(s.ToString());
        }
    }
}
