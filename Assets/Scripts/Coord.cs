public struct Coord
{
    public int file;
    public int rank;

    public int piece;

    public Coord(int file, int rank, int piece = 0)
    {
        this.file = file;
        this.rank = rank;

        this.piece = piece;
    }

    public bool IsWhite()
    {
        return (file + rank) % 2 != 0;
    }
}