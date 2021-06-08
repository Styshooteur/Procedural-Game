using UnityEngine;


public struct Cell
{
    public bool isAlive;

    public Cell(bool isAlive)
    {
        this.isAlive = isAlive;
    }
}
public class CellBehavior : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private bool isAlive = true;
    [SerializeField] private Sprite[] sprites_;

    private void Start()
    {
        spriteRenderer.sprite = sprites_[Random.Range(0, sprites_.Length)];
    }

    public bool IsAlive
    {
        get => isAlive;
        set
        {
            isAlive = value;
            UpdateColor(isAlive?Color.white:Color.black);
        }
    }

    public void UpdateColor(Color color)
    {
        spriteRenderer.color = color;
    }
}
