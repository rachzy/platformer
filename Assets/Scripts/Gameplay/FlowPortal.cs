using Platformer.Interfaces;
using Platformer.Mechanics;
using UnityEngine;

namespace Platformer.Gameplay
{
    public class FlowPortal : MonoBehaviour
    {
        public LevelManager levelManager;
        public Flow flow;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                levelManager.currentFlow = flow;
            }
        }
    }
}
