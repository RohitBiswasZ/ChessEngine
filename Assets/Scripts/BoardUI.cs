using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class BoardUI : MonoBehaviour {

    [SerializeField] float squareSize = 1.25f;

    public Color lightColor;
    public Color darkColor;

    public List<Vector3> squaresPosition = new List<Vector3>();

    [SerializeField] Sprite squareSprite;
    [SerializeField] Transform squareParent;

    [SerializeField] Transform textParent;

    public void Start() => UpdateBoard();

    // This function instance a square object into the scene
    void CreateSquare(Vector2 position ,float scale, Color color) {

        GameObject square = new GameObject(position.ToString());
        if (squareParent != null) {
            square.transform.SetParent(squareParent);
        }

        square.transform.localPosition = position;
        square.transform.localScale = Vector3.one * scale;
        SpriteRenderer squareRenderer = square.AddComponent<SpriteRenderer>();
        squareRenderer.sprite = squareSprite;
        squareRenderer.color = color;
    }

    private void GenerateBoardUI() {
        for (int rank = 0; rank < 8; rank++)
        for (int file = 0; file < 8; file++)
        {
            Color color = (file + rank) % 2 == 0 ? darkColor : lightColor;
            Vector2 offset = new Vector2(8, 8) * squareSize / 2 - Vector2.one * squareSize / 2f;
            CreateSquare(new Vector2(file,rank) * squareSize - offset, squareSize, color);
            squaresPosition.Add(new Vector2(file,rank) * squareSize - offset);
        }
    }

    [Button]
    private void UpdateBoard() {
        // Destroy all squares
        if (squareParent.childCount > 0) {
            squaresPosition.Clear();
            for (int i = squareParent.childCount - 1; i >= 0; i--) {
                DestroyImmediate(squareParent.GetChild(i).gameObject);
            }
        }
        GenerateBoardUI();
    }

    // This function instance a TextMeshPro object into the scene, Set some font info
    public void CreateText(string text,float fontSize, Color color, FontData fontData) {

        TextMeshPro textMesh = new GameObject(text).AddComponent<TextMeshPro>();
        textMesh.transform.parent = textParent;
        textMesh.transform.localPosition = fontData.position;
        textMesh.transform.localScale = fontData.size;

        textMesh.text = text;
        textMesh.color = color;
        textMesh.fontSize = fontSize;
        textMesh.alignment = fontData.alignment;
        textMesh.fontStyle = fontData.fontStyle;
    }
}

public struct FontData
{
    public Vector2 position;
    public Vector2 size;
    public TextAlignmentOptions alignment;
    public FontStyles fontStyle;
}