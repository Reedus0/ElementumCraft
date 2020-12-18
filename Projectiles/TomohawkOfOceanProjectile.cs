using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementumCraft.Projectiles
{

    public class TomohawkOfOceanProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.width = 60;
            projectile.aiStyle = 12;
            projectile.height = 35;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.tileCollide = true;
            projectile.penetrate = 10;
            projectile.timeLeft = 200;
            projectile.light = 0.75f;
            projectile.ignoreWater = true;
        }
    }
}