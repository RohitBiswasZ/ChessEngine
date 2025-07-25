public class Board
{
    public Coord[] coords;

    public Board()
    {
        coords = new Coord[64];
        for (int file = 0; file < 8; file++) {
            for (int rank = 0; rank < 8; rank++) {
                coords[rank * 8 + file] = new Coord(file, rank);
            }
        }
    }
}