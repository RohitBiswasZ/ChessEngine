using System;
using System.Collections.Generic;
using Unity.VisualScripting;

public static class FENUtility
{
    /// <summary>
    /// Note: "N" is white Kinght and "n" is black Knight
    /// </summary>
    private static Dictionary<string, int> pieceSymbolMap = new Dictionary<string, int>()
    {
        { "P", 1 }, { "p", -1 },
        { "N", 2 }, { "n", -2 },
        { "B", 3 }, { "b", -3 },
        { "R", 4 }, { "r", -4 },
        { "Q", 5 }, { "q", -5 },
        { "K", 6 }, { "k", -6 }
    };

    public static void LoadBoardFEN(string fen, Board board)
    {
        int file = 0;
        int rank = 7;

        foreach (Char fenSymbol in fen)
        {
            if (fenSymbol == '/') {
                rank--;
                file = 0;
            }
            else if (char.IsDigit(fenSymbol)) {
                file += int.Parse(fenSymbol.ToString());
            }
            else if (pieceSymbolMap.ContainsKey(fenSymbol.ToString())) {
                int pieceType = pieceSymbolMap[fenSymbol.ToString()];
                board.coords[rank * 8 + file] = new Coord(file, rank, pieceType);
                file++;
            }

            if (fenSymbol == ' ') break;
        }
    }
}