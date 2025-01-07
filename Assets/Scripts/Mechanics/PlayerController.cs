using System;
using Platformer.Core;
using Platformer.Gameplay;
using Platformer.Interfaces;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class PlayerController : MonoBehaviour
    {
        // Controllers
        public LevelManager levelManager;
        [NonSerialized]
        public JumpController jumpController;
        [NonSerialized]
        public TrailController trailController;
        [NonSerialized]
        public LauncherController launcherController;

        [NonSerialized]
        public Rigidbody2D body;

        public GameObject spawnPoint;

        /// <summary>
        /// Camera related
        /// </summary>
        /// <value></value>
        public new CameraController camera;
        [NonSerialized]
        public float currentStaticY;

        /// <summary>
        /// Speed related
        /// </summary>
        /// <value></value>
        public float speed;

        /// <summary>
        /// Bottom hitbox related
        /// </summary>
        public Vector2 boxSize;
        public float castDistance;
        public LayerMask groundMask;

        /// <summary>
        /// Flow related
        /// </summary>
        [NonSerialized]
        public Flow currentFlow;


        public void Start()
        {
            body = GetComponent<Rigidbody2D>();
            trailController = GetComponent<TrailController>();
            jumpController = GetComponent<JumpController>();
            launcherController = GetComponent<LauncherController>();

            currentFlow = levelManager.initialFlow;
        }

        public void Update()
        {
            body.linearVelocity = new Vector2(speed, body.linearVelocityY);

            if (IsGrounded())
            {
                currentStaticY = body.position.y;
                UpdateCameraPosition();
            }

            if (currentFlow != levelManager.currentFlow)
            {
                Simulation.Schedule<PlayerChangedFlow>().player = this;
            }

            // Position events
            if (body.position.y < levelManager.DEATH_ZONE_Y)
            {
                Simulation.Schedule<PlayerDeath>().player = this;
            }
        }

        public bool IsGrounded()
        {
            return Physics2D.BoxCast(transform.position, boxSize, 0, Vector2.down, castDistance, groundMask);
        }


        private void UpdateCameraPosition()
        {
            if (camera.target.CompareTag("Player") && camera.y != currentStaticY)
            {
                camera.SetY(currentStaticY);
            }
        }


        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
        }
    }
}
