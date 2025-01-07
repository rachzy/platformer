using System;
using Platformer.Core;
using Platformer.Gameplay;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class JumpController : MonoBehaviour
    {
        public PlayerController player;
        protected Rigidbody2D body;
        protected float jumpCounter;
        protected Vector2 gravityVec;
        public float jumpForce;
        public float rotationDuration;
        public float fallMultiplier;
        [NonSerialized]
        protected bool isJumping;

        public void Start()
        {
            body = GetComponent<Rigidbody2D>();
            player = GetComponent<PlayerController>();
            gravityVec = new Vector2(0, -Physics2D.gravity.y);
        }

        public void Update()
        {
            if (player.IsGrounded())
            {
                isJumping = false;
            }
            else if (body.linearVelocityY < 0 || (body.linearVelocityY > jumpForce && isJumping))
            {
                body.linearVelocity -= gravityVec * fallMultiplier * Time.deltaTime;
            }


            // Button Events
            if (Input.GetButton("Jump"))
            {
                if (player.IsGrounded())
                {
                    jumpCounter = 0;
                    isJumping = true;
                    Simulation.Schedule<PlayerJumped>().jumpController = this;
                }
            }
        }
    }

}