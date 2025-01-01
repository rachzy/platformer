using System;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class TrailController : MonoBehaviour
    {
        [NonSerialized]
        protected PlayerController player;
        [NonSerialized]
        public TrailRenderer trail;
        [NonSerialized]
        protected Gradient originalTrailGradient;
        [NonSerialized]
        public bool isOverJumper = false;

        public void Start()
        {
            player = GetComponent<PlayerController>();
            trail = GetComponent<TrailRenderer>();
            originalTrailGradient = trail.colorGradient;
        }

        public void Update()
        {
            if (player.IsGrounded() && !isOverJumper)
            {
                ResetDefaultTrailGradient();
            }
        }

        public void SetTrailGradient(Gradient gradient)
        {
            trail.colorGradient = gradient;
        }

        public void SetTrailGradient(Color color)
        {
            var newGradient = new Gradient();

            var colors = new GradientColorKey[2];
            colors[0] = new GradientColorKey(color, 0.0f);
            colors[1] = new GradientColorKey(color, 1.0f);

            var alphas = new GradientAlphaKey[2];
            alphas[0] = new GradientAlphaKey(1.0f, 0.0f);
            alphas[1] = new GradientAlphaKey(0.0f, 1.0f);

            newGradient.SetKeys(colors, alphas);

            trail.colorGradient = newGradient;
        }
        public void ResetDefaultTrailGradient()
        {
            trail.colorGradient = originalTrailGradient;
        }
    }

}