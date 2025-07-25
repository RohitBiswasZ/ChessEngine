public struct Coord
{
    public int piece;

    public int file;
    public int rank;

    public Coord(int file, int rank, int piece = 0)
    {
        this.file = file;
        this.rank = rank;
        this.piece = piece;
    }
}