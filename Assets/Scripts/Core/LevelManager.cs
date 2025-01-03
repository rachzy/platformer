using Platformer.Core;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class LevelManager : MonoBehaviour
    {
        [System.NonSerialized]
        public static LevelManager Instance;
        public float DEATH_ZONE_Y = -10;
        private void OnEnable()
        {
            Instance = this;
        }

        private void OnDisable()
        {
            if (Instance == this) Instance = null;
        }

        private void Update()
        {
            if (Instance == this) Simulation.Tick();
        }
    }
}
