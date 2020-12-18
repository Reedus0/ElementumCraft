using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace ElementumCraft.Projectiles
{

    public class ValkyrieSwordProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 4 ;
        }
        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.tileCollide = true;
            projectile.penetrate = 10;
            projectile.timeLeft = 200;
            projectile.ignoreWater = true;
        }


        public override void AI()
        {
            if(projectile.ai[0] == 0)
            {
                Main.PlaySound(SoundID.Item43, projectile.Center);
            }
            projectile.ai[0] += 0.5f;
            if (projectile.ai[0] >= 20f)
            {
                projectile.velocity.Y = projectile.velocity.Y * 0.97f;
                projectile.velocity.X = projectile.velocity.X * 0.97f; // 0.99f for rolling grenade speed reduction. Try values between 0.9f and 0.99f
            }
            if (projectile.ai[0] >= 75f)
            {
                projectile.alpha += 15; // Decrease alpha, increasing visibility.
            }
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