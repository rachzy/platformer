using Platformer.Core;
using UnityEngine;
using Platformer.Interfaces;

namespace Platformer.Mechanics
{
    public class LevelManager : MonoBehaviour
    {
        [System.NonSerialized]
        public static LevelManager Instance;
        public float DEATH_ZONE_Y = -10;
        public Flow initialFlow = Flow.Default;
        [System.NonSerialized]
        public Flow currentFlow = Flow.Default;

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

        public void ResetFlow()
        {
            currentFlow = initialFlow;
        }
    }
}
