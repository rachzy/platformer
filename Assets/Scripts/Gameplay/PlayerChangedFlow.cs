using Platformer.Core;
using Platformer.Interfaces;
using Platformer.Mechanics;
using UnityEngine;

namespace Platformer.Gameplay
{
    public class PlayerChangedFlow : Simulation.Event<PlayerChangedFlow>
    {
        public PlayerController player;
        public Vector3 defaultGravity = new(0, -9.81f, 0);

        public override void Execute()
        {
            switch (player.levelManager.currentFlow)
            {
                case Flow.ReversedGravity:
                    Debug.Log("Reversing gravity");
                    Physics2D.gravity = defaultGravity * -1;
                    player.castDistance *= -1;
                    break;
                default:
                    if (player.currentFlow == Flow.ReversedGravity)
                    {
                        Debug.Log("Setting back gravity");
                        Debug.Log(Physics2D.gravity);
                        Debug.Log(defaultGravity);
                        Physics2D.gravity = defaultGravity;
                        player.castDistance *= -1;
                    }
                    break;
            }

            player.currentFlow = player.levelManager.currentFlow;
        }
    }
}