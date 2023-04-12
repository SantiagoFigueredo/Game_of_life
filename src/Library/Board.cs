public class Board
{
    private bool[,] _cells;

    public int Width { get { return _cells.GetLength(0); } }
    public int Height { get { return _cells.GetLength(1); } }

    public Board(bool[,] cells)
    {
        _cells = cells;
    }

    public bool IsCellAlive(int x, int y)
    {
        if (x < 0 || x >= Width || y < 0 || y >= Height)
        {
            return false;
        }
        return _cells[x, y];
    }

    public void UpdateBoard()
    {
        bool[,] cloneBoard = new bool[Width, Height];
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                int aliveNeighbors = 0;
                for (int i = x - 1; i <= x + 1; i++)
                {
                    for (int j = y - 1; j <= y + 1; j++)
                    {
                        if (i >= 0 && i < Width && j >= 0 && j < Height && !(i == x && j == y) && _cells[i, j])
                        {
                            aliveNeighbors++;
                        }
                    }
                }
                if (_cells[x, y])
                {
                    if (aliveNeighbors < 2 || aliveNeighbors > 3)
                    {
                        cloneBoard[x, y] = false;
                    }
                    else
                    {
                        cloneBoard[x, y] = true;
                    }
                }
                else
                {
                    if (aliveNeighbors == 3)
                    {
                        cloneBoard[x, y] = true;
                    }
                }
            }
        }
        _cells = cloneBoard;
    }
}