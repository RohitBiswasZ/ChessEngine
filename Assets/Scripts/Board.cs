public class Board
{
    public Coord[] coords = new Coord[64];

    public Board()
    {
        int index = 0;
        for (int rank = 0; rank < 8; rank++) {
            for (int file = 0; file < 8; file++)
            {
                Coord coord = new Coord(file, rank);
                coords[index] = coord;
                index++;
            }
        }
    }
}