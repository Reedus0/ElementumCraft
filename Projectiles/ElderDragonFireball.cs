using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementumCraft.Projectiles
{

    public class ElderDragonFireball : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 1;
        }
        public override void SetDefaults()
        {
            projectile.width = 25;
            projectile.hostile = true;
            projectile.tileCollide = true;
            projectile.height = 25;
            projectile.friendly = false;
            projectile.melee = false;
            projectile.tileCollide = true;
            projectile.penetrate = 10;
            projectile.damage = 15;
            projectile.timeLeft = 200;
            projectile.light = 0.75f;
            projectile.ignoreWater = true;
        }
        public override void AI()
        {
            if (projectile.ai[0] == 0)
            {
                Main.PlaySound(SoundID.Item43, projectile.Center);
            }
            projectile.ai[0] += 0.5f;
            Player player = Main.player[0];
            if(projectile.position.X <= player.position.X)
            {
                projectile.velocity.X += 0.1f;
            }
            else
            {
                projectile.velocity.X -= 0.1f; 
            }

            if (projectile.position.Y <= player.position.Y)
            {
                projectile.velocity.Y += 0.03f;
            }
            else
            {
                projectile.velocity.Y -= 0.03f;
            }

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 300);
        }
    }
}