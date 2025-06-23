using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    private Board board;
    public BoardUI boardUI;

    public void Start()
    {
        boardUI = GetComponent<BoardUI>();
        if (boardUI == null) boardUI = transform.AddComponent<BoardUI>();

        board = new Board();
        FENUtility.LoadBoardFEN("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR",board);

        boardUI.CreateBoardUI(board);

        for (int i = 0; i < board.coords.Length; i++)
        {
            Debug.Log(board.coords[i].piece);
        }
    }
}
