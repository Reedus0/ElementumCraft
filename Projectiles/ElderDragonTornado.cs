using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace ElementumCraft.Projectiles
{

    public class ElderDragonTornado : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 4 ;
        }
        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.friendly = false;
            projectile.melee = false;
            projectile.hostile = true;
            projectile.light = 0.75f;
            projectile.tileCollide = true;
            projectile.penetrate = 10;
            projectile.timeLeft = 400;
            projectile.ignoreWater = true;
        }


        public override void AI()
        {
            Player player = Main.player[0];
            if (projectile.position.X <= player.position.X)
            {
                if (projectile.ai[0] >= 20f)
                {
                    projectile.velocity.X = projectile.velocity.X * 0.97f;
                    projectile.velocity.X += 0.1f; // 0.99f for rolling grenade speed reduction. Try values between 0.9f and 0.99f
                }
            }
            else
            {
                if (projectile.ai[0] >= 20f)
                {
                    projectile.velocity.X = projectile.velocity.X  * 0.97f;
                    projectile.velocity.X -= 0.1f; // 0.99f for rolling grenade speed reduction. Try values between 0.9f and 0.99f
                }
            }

            if (projectile.position.Y <= player.position.Y)
            {
                if (projectile.ai[0] >= 20f)
                {
                    projectile.velocity.Y = projectile.velocity.Y * 0.97f;
                    projectile.velocity.Y += 0.1f; // 0.99f for rolling grenade speed reduction. Try values between 0.9f and 0.99f
                }
            }
            else
            {
                if (projectile.ai[0] >= 20f)
                {
                    projectile.velocity.Y = projectile.velocity.Y * 0.97f;
                    projectile.velocity.Y -= 0.1f; // 0.99f for rolling grenade speed reduction. Try values between 0.9f and 0.99f
                }
            }
            if (projectile.ai[0] == 0)
            {
                Main.PlaySound(SoundID.Item43, projectile.Center);
            }
            projectile.ai[0] += 0.5f;
            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
        }
        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item10, projectile.position);
        }
    }
}