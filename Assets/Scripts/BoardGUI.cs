using NaughtyAttributes;
using UnityEngine;

public class BoardGUI : MonoBehaviour
{
    public Color lightColor;
    public Color darkColor;
    public Sprite squareSprite;
    [Min(0.1f)] public float scale;

    public void Start() {
        UpdateBoardGUI();
    }
    
    [Button]
    void UpdateBoardGUI()
    {
        ClearBoardGUI();
        CreateBoardGUI();
    }
    
    void CreateBoardGUI() 
    {
        Vector2 offset = new Vector2(8, 8) * scale / 2 - Vector2.one * scale * 0.5f;
        
        for (int rank = 0; rank < 8; rank++)
        for (int file = 0; file < 8; file++)
        {
            Color color = (rank + file) % 2 == 0 ? darkColor : lightColor;
            CreateSquare(new Vector2(file, rank) * scale - offset, color);
        }
    }

    void ClearBoardGUI()
    {
        foreach (Transform child in transform) {
            DestroyImmediate(child.gameObject);
        }
    }
    
    void CreateSquare(Vector3 position, Color color)
    {
        Transform parent = FindChild("Squares");
        
        SpriteRenderer square = new GameObject(position.ToString()).AddComponent<SpriteRenderer>();
        square.transform.parent = parent;
        square.transform.localScale = Vector3.one * scale;
        square.transform.localPosition = position;
        
        square.color = color;
        square.sprite = squareSprite;
    }

    Transform FindChild(string id)
    {
        if (transform.Find(id) == null)
        {
            GameObject child = new GameObject(id);
            child.transform.parent = transform;
            return child.transform;
        }
        return transform.Find(id);
    }
}
