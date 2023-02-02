using System.Collections.Generic;
using UnityEngine;

public class AnimatedRenderer : MonoBehaviour
{
    private int animationFrame;
    private SpriteRenderer frame_Renderer;
    public Sprite idle;
    public List<Sprite> sprites = new List<Sprite>();
    public float animationTime = 0.3f;
    public bool loop = true, isPlaying = false;


    private void Awake()
    {
        frame_Renderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        frame_Renderer.enabled = true;
    }

    private void OnDisable()
    {
        frame_Renderer.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        //invokeReaping keeps Nextframe function in a loop
        InvokeRepeating(nameof(NextFrame), animationTime, animationTime);
    }

    private void NextFrame()
    {
        animationFrame++;

        if (loop && animationFrame >= sprites.Count)
        {
            animationFrame = 0;
        }

        if (isPlaying)
        {
            frame_Renderer.sprite = idle;
        }
        else if (animationFrame >= 0 && animationFrame < sprites.Count)
        {
            frame_Renderer.sprite = sprites[animationFrame];
        }

    }
}
