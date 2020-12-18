using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementumCraft.Projectiles
{

    public class ElderDragonFireball2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 1;
        }
        public override void SetDefaults()
        {
            projectile.width = 25;
            projectile.aiStyle = 8;
            projectile.height = 25;
            projectile.friendly = false;
            projectile.melee = false;
            projectile.hostile = true;
            projectile.penetrate = 10;
            projectile.timeLeft = 125;
            projectile.tileCollide = true;
            projectile.light = 0.75f;
            projectile.ignoreWater = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 300);
        }
    }
}