using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimatedSprite : MonoBehaviour
{
    
    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;
    private int frame;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Invoke(nameof(Animate), 0f);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    private void Animate()
    {
        frame++;
        if (frame >= sprites.Length)
        {
            frame = 0;
        }

        spriteRenderer.sprite = sprites[frame];

        Invoke(nameof(Animate), 1f / GameManager.Instance.gameSpeed);
    }
}
