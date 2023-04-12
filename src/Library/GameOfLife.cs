// GameOfLife.cs

public class GameOfLife {
    private Board board;

    public GameOfLife(Board board) {
        this.board = board;
    }

    public void NextGeneration() {
        int width = board.Width;
        int height = board.Height;

        Board newBoard = new Board(width, height);

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                int aliveNeighbors = GetAliveNeighborCount(x, y);

                if (board[x, y]) {
                    if (aliveNeighbors < 2 || aliveNeighbors > 3) {
                        newBoard[x, y] = false;
                    } else {
                        newBoard[x, y] = true;
                    }
                } else {
                    if (aliveNeighbors == 3) {
                        newBoard[x, y] = true;
                    }
                }
            }
        }

        board = newBoard;
    }

    private int GetAliveNeighborCount(int x, int y) {
        int count = 0;

        for (int i = x - 1; i <= x + 1; i++) {
            for (int j = y - 1; j <= y + 1; j++) {
                if (i >= 0 && i < board.Width && j >= 0 && j < board.Height && !(i == x && j == y) && board[i, j]) {
                    count++;
                }
            }
        }

        return count;
    }
}
