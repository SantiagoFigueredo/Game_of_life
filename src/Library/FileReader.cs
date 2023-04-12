// FileReader.cs

public class FileReader {
    public static Board ReadFile(string path) {
        string[] lines = File.ReadAllLines(path);
        int width = lines[0].Length;
        int height = lines.Length;
        Board board = new Board(width, height);

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                board[x, y] = lines[y][x] == '1';
            }
        }

        return board;
    }
}
