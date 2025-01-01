using System;
using System.Collections;
using Platformer.Core;
using Platformer.Mechanics;
using UnityEngine;

namespace Platformer.Gameplay
{
    public class PlayerJumped : Simulation.Event<PlayerJumped>
    {
        public JumpController jumpController;

        public override void Execute()
        {
            jumpController.player.body.linearVelocityY = jumpController.jumpForce;
            jumpController.StartCoroutine(GradualRotation());
        }

        private IEnumerator GradualRotation()
        {
            var body = jumpController.player.body;

            float startRotation = body.rotation;
            float targetRotation = -360f;
            float elapsedTime = 0f;
            float duration = jumpController.rotationDuration;

            while (elapsedTime < duration)
            {
                if (jumpController.player.IsGrounded())
                {
                    yield return null;
                }
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / duration;
                float currentRotation = Mathf.Lerp(startRotation, targetRotation, t);
                body.MoveRotation(currentRotation);
                yield return null;
            }

            body.rotation = 0;
        }
    }
}
