using UnityEngine;

namespace Assets.GameLogic
{
    public class AnimatedRenderer : MonoBehaviour
    {
        private int animationFrame;
        private SpriteRenderer frame_Renderer;
        public Sprite idleSprite;
        public Sprite[] sprites;
        public float animationTime = 0.3f;
        public bool loop = true, idle = true;


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
        private void Start()
        {
            //invokeReaping keeps Nextframe function in a loop
            InvokeRepeating(nameof(NextFrame), animationTime, animationTime);
        }

        private void NextFrame()
        {
            animationFrame++;

            if (loop && animationFrame >= sprites.Length)
            {
                animationFrame = 0;
            }

            if (loop)
            {
                frame_Renderer.sprite = idleSprite;
            }
            else if (animationFrame >= 0 && animationFrame < sprites.Length)
            {
                frame_Renderer.sprite = sprites[animationFrame];
            }

        }
    }
}

