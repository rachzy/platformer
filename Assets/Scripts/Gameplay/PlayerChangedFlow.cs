using Platformer.Core;
using Platformer.Interfaces;
using Platformer.Mechanics;
using UnityEngine;

namespace Platformer.Gameplay
{
    public class PlayerChangedFlow : Simulation.Event<PlayerChangedFlow>
    {
        public PlayerController player;

        public override void Execute()
        {
            var defaultGravity = player.levelManager.defaultGravity;

            switch (player.levelManager.currentFlow)
            {
                case Flow.ReversedGravity:
                    Physics2D.gravity = defaultGravity * -1;
                    player.castDistance *= -1;
                    break;
                default:
                    if (player.currentFlow == Flow.ReversedGravity)
                    {
                        Physics2D.gravity = defaultGravity;
                        player.castDistance *= -1;
                    }
                    break;
            }

            player.currentFlow = player.levelManager.currentFlow;
        }
    }
}