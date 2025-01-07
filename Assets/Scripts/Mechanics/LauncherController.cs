using Platformer.Mechanics;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class LauncherController : MonoBehaviour
    {
        [System.NonSerialized]
        public PlayerController player;
        [System.NonSerialized]
        protected BoxCollider2D boxCollider;
        [System.NonSerialized]
        public Color currentLauncherColor;
        public string launcherTag;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            player = GetComponent<PlayerController>();
            boxCollider = GetComponent<BoxCollider2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButton("Jump") && player.trailController.isOverJumper)
            {
                player.trailController.SetTrailGradient(currentLauncherColor);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(launcherTag))
            {
                var sprite = other.gameObject.GetComponent<SpriteRenderer>();
                currentLauncherColor = sprite.color;
                player.trailController.isOverJumper = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(launcherTag))
            {
                player.trailController.isOverJumper = false;
            }
        }
    }
}
