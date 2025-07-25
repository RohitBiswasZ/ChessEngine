using System.Collections.Generic;

public class FEN
{
    public string startingPosition = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";

    /// <summary>
    /// Note: 'n' is the knight piece, lower 'n' is black and upper 'N' is white
    /// Note: positive value means white pieces and the negative are black pieces
    /// </summary>
    readonly Dictionary<char, int> piecesMap = new Dictionary<char, int>
    {
        { 'r', Piece.Rook * -1 }, { 'R', Piece.Rook },
        { 'n', Piece.Knight * -1 }, { 'N', Piece.Knight },
        { 'b', Piece.Bishop * -1 }, { 'B', Piece.Bishop },
        { 'q', Piece.Queen * -1 }, { 'Q', Piece.Queen },
        { 'k', Piece.King * -1 }, { 'K', Piece.King },
        { 'p', Piece.Pawn * -1 }, { 'P', Piece.Pawn }
    };

    public void SetBoard(Board board, string fen)
    {
        if (fen == null) fen = startingPosition;

        int file = 0;
        int rank = 7;
        foreach (var fenChar in fen)
        {
            if (fenChar == '/') {
                rank--;
                file = 0;
            }
            else if (char.IsDigit(fenChar)) {
                file += int.Parse(fenChar.ToString());
            }
            else if (piecesMap.TryGetValue(fenChar, out var value)) {
                board.coords[rank * 8 + file].piece = value;
                file++;
            }
            else
            {
                break;
            }
        }
    }
}