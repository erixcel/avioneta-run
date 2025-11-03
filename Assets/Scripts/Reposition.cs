using UnityEngine;

public class Reposition : MonoBehaviour
{
    private float spriteWidth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteWidth = GetComponent<SpriteRenderer>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -spriteWidth)
        {
            transform.Translate(Vector2.right * 2f * spriteWidth);
        }
    }
}
