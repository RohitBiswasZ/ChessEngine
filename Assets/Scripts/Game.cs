using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    private Board board;
    public BoardUI boardUI;

    public Color lightTeamTextColor;
    public Color darkTeamTextColor;

    public void Start()
    {
        board = new Board();
        FEN fen = new FEN();
        fen.SetBoard(board, null);

        for (int i = 0; i < board.coords.Length; i++) {

            if (board.coords[i].piece == 0) continue;

            FontData fontData = new FontData {
                position = boardUI.squaresPosition[i],
                alignment = TextAlignmentOptions.Center,
                fontStyle = FontStyles.Normal,
                size = new Vector2(0.5f, 0.5f)
            };

            Color fontCol = default;
            if (board.coords[i].piece > 0) fontCol = lightTeamTextColor;
            if (board.coords[i].piece < 0) fontCol = darkTeamTextColor;

            boardUI.CreateText(board.coords[i].piece.ToString(), 10, fontCol, fontData);
        }
    }
}