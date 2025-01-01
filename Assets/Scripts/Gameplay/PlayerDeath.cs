using Platformer.Core;
using Platformer.Mechanics;
using UnityEngine;

namespace Platformer.Gameplay
{
    public class PlayerDeath : Simulation.Event<PlayerDeath>
    {
        public PlayerController player;
        public override void Execute()
        {
            var rb = player.body;
            rb.angularVelocity = 0;
            rb.linearVelocityX = 0;
            rb.transform.position = player.spawnPoint.transform.position;
        }
    }
}