using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using ElementumCraft.Buffs;
using ElementumCraft.UI;

namespace ElementumCraft
{
	// ModPlayer classes provide a way to attach data to Players and act on that data. ExamplePlayer has a lot of functionality related to 
	// several effects and items in ExampleMod. See SimpleModPlayer for a very simple example of how ModPlayer classes work.
	public class ElementumPlayer : ModPlayer
	{
        public float endurance = 100;
		public float totalEndurance = 100;
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{
			if (damage != 0)
            {
				if (endurance >= 10)
				{
					endurance = endurance - 10;
				}
			}
		}
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if (proj.melee) { 
				if (endurance >= 5)
				{
					endurance = endurance - 5f;
				}
			}
		}
		public override void FrameEffects()
        {
			if (endurance < totalEndurance)
            {
				endurance = endurance + 0.3f;
			}
			if (endurance < 25)
			{
				player.AddBuff(mod.BuffType("Fatigue"), 60);
			}
			if ((int)endurance == (int)totalEndurance)
            {
				EnduranceBar.visible = false;
            }
            else
            {
				EnduranceBar.visible = true;
			}
		}
	}
}
