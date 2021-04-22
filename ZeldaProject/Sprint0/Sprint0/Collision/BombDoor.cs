using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Sprint0
{
    class BombDoor
    {
        public BombDoor()
        {

        }

        public static void DetermineDoor(IProjectile projectile, RoomManager roomManager)
        {
            if(projectile.GetProjectileLocation().X > 448 && projectile.GetProjectileLocation().X + projectile.GetProjectileLocation().Width < 576)
            {
                if(projectile.GetProjectileLocation().Y < 120 + (64 * 4) && ((BombProjectile)projectile).Exploding())
                {
                    roomManager.BlowDoor(Direction.Up);
                } 
                else if(projectile.GetProjectileLocation().Y > 580 + (64 * 4) && ((BombProjectile)projectile).Exploding())
                {
                    roomManager.BlowDoor(Direction.Down);
                }
            } else if(projectile.GetProjectileLocation().Y > 240 + (64 * 4) && projectile.GetProjectileLocation().Y + projectile.GetProjectileLocation().Height < 400 + (64 * 4))
            {
                if (projectile.GetProjectileLocation().X < 120 && ((BombProjectile)projectile).Exploding())
                {
                    roomManager.BlowDoor(Direction.Left);
                }
                else if (projectile.GetProjectileLocation().X < 900 && ((BombProjectile)projectile).Exploding())
                {
                    roomManager.BlowDoor(Direction.Right);
                }
            }
        }
    }
}
