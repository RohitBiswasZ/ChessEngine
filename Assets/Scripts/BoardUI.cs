using Unity.VisualScripting;
using UnityEngine;

public class BoardUI : MonoBehaviour
{
    [Min(0.1f)] public float squareSize;
    public Transform squareParent;

    public Color lightColor;
    public Color darkColor;

    public void CreateBoardUI(Board board)
    {
        for (int i = 0; i < board.coords.Length; i++)
        {
            Coord coord = board.coords[i];
            Color color = coord.IsWhite() ? lightColor : darkColor;
            Vector2 position = new Vector2(coord.file, coord.rank) * squareSize;
            Vector2 offset = Vector2.one * 8 * squareSize / 2 - Vector2.one * squareSize * 0.5f;
            DrawSquare(position - offset, color);
        }
    }

    public void DrawSquare(Vector2 position, Color color)
    {
        var square = new GameObject(position.ToString()).transform.AddComponent<SpriteRenderer>();
        square.transform.SetParent(squareParent);
        square.transform.localPosition = position;
        square.transform.localScale = Vector2.one * squareSize;
        square.color = color;
        square.sprite = Resources.Load<Sprite>("Utility/Square");
    }
}