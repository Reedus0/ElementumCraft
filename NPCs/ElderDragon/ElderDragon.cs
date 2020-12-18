using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using ElementumCraft.Projectiles;
using ElementumCraft;

namespace ElementumCraft.NPCs.ElderDragon
{
	// This ModNPC serves as an example of a complete AI example.
	public class ElderDragon : ModNPC
	{

		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[npc.type] = 1;
		}

		public override void SetDefaults()
		{
			npc.width = 225;
			npc.height = 300;
			npc.damage = 7;
			npc.defense = 20;
			npc.lifeMax = 5000;
			npc.boss = true;
			npc.lavaImmune = true;
			npc.noTileCollide = false;
			npc.knockBackResist = -10;
		}
		private float timeMultiplier => 1f * 0.2f;
		public readonly IList<int> targets = new List<int>();
		private int damageTotal;
		private int stage = 0;

		private float StageTimer
		{
			get => npc.ai[1];
			set => npc.ai[1] = value;
		}

		internal int attack
		{
			get => (int)npc.ai[2];
			private set => npc.ai[2] = value;
		}

		internal int attackProgress
		{
			get => (int)npc.ai[3];
			private set => npc.ai[3] = value;
		}
		public override void AI()
		{
			FindPlayers();
			int target = Main.rand.Next(targets[0], targets[targets.Count - 1]);
			if (damageTotal >= 5000)
			{
				StageTimer = 0;
				stage = 3;
			}

			switch (stage)
			{
				case 0:
					Initialize();
					break;
				case 1:
					npc.noTileCollide = true;
					npc.noGravity = false;
					attack++;
					StageTimer++;
					if ((int)attack >= 50)
					{
						DoAttack(1);
						attack = 0;
					}
					if (StageTimer >= 400)
					{
						StageTimer = 0;
						stage++;
					}
					if (StageTimer >= 0)
					{
						attackProgress++;
						if ((int)attackProgress % 2 == 0)
						{
							if (attackProgress <= 30){
								DoAttack(3);
							}
						}
						if ((int)attackProgress >= 400)
						{
							attackProgress = 0;
						}
						if (npc.position.X <= Main.player[target].position.X + 425)
						{
							npc.velocity.X += 0.6f;
						}
						else
						{
							npc.velocity.X -= 0.6f;
						}
						if (Main.player[target].position.Y < npc.position.Y + 500) // IF the target is higher than "300 below my height"
						{
							if (npc.velocity.Y < 0 // IF I'm already moving up 
								&& npc.velocity.Y > -4) // AND I'm not at max "up" velocity
								npc.velocity.Y -= 0.5f; // THEN accelerate up
							else // otherwise, I'm not moving up already
								npc.velocity.Y -= 0.6f; // THEN accelerate up (faster)
						}

						if (Main.player[target].position.Y > npc.position.Y + 500) // IF the target is lower than "300 below my height"
						{
							if (npc.velocity.Y > 0 // IF I'm already moving down 
								&& npc.velocity.Y < 4) // AND I'm not at max "down" velocity
								npc.velocity.Y += 0.5f; // THEN accelerate down
							else // otherwise, I'm not moving down already
								npc.velocity.Y += 0.6f; // THEN accelerate down (faster)
						}
					}
					break;
				case 2:
					StageTimer++;
					attack++;
					if ((int)attack >= 50)
					{
						DoAttack(2);
						attack = 0;
					}
					if (StageTimer >= 400)
					{
						StageTimer = 0;
						stage--;
					}
					if(StageTimer >= 0)
                    {
						attackProgress++;
						if ((int)attackProgress % 2 == 0)
						{
							if (attackProgress <= 30)
							{
								DoAttack(3);
							}
						}
						if ((int)attackProgress >= 400)
						{
							attackProgress = 0;
						}
						if (npc.position.X >= Main.player[target].position.X - 750)
						{
							npc.velocity.X -= 0.6f;
						}
						else
						{
							npc.velocity.X += 0.6f;
						}
						if (Main.player[target].position.Y < npc.position.Y + 500) // IF the target is higher than "300 below my height"
						{
							if (npc.velocity.Y < 0 // IF I'm already moving up 
								&& npc.velocity.Y > -4) // AND I'm not at max "up" velocity
								npc.velocity.Y -= 0.5f; // THEN accelerate up
							else // otherwise, I'm not moving up already
								npc.velocity.Y -= 0.6f; // THEN accelerate up (faster)
						}

						if (Main.player[target].position.Y > npc.position.Y + 500) // IF the target is lower than "300 below my height"
						{
							if (npc.velocity.Y > 0 // IF I'm already moving down 
								&& npc.velocity.Y < 4) // AND I'm not at max "down" velocity
								npc.velocity.Y += 0.5f; // THEN accelerate down
							else // otherwise, I'm not moving down already
								npc.velocity.Y += 0.6f; // THEN accelerate down (faster)
						}
					}
					break;
				case 3:
					npc.noGravity = true;
					StageTimer++;
					attack++;
					attackProgress++;
					if ((int)attack >= 15)
					{
						DoAttack(1);
						attack = 0;
					}
					if(attackProgress >= 800)
                    {
						DoAttack(4);
					}
					if (attackProgress >= 1000)
					{
						attackProgress = 0;
					}
					if (StageTimer >= 0)
					{
						if (Main.player[target].position.X < npc.position.X // IF the target is to my left
						&& npc.velocity.X > -8) // AND I'm not at max "left" velocity
						{
							npc.velocity.X -= 0.2f; // accelerate to the left
						}

						if (Main.player[target].position.X > npc.position.X // IF the target is to my right
							&& npc.velocity.X < 8) // AND I'm not at max "right" velocity
						{
							npc.velocity.X += 0.2f; // accelerate to the right
						}
						if (Main.player[target].position.Y < npc.position.Y + 300 // IF the target is higher than "300 below my height"
						&& npc.velocity.Y > -4) // AND I'm not at max "up" velocity
						{
							npc.velocity.Y -= 0.2f; // accelerate up
						}

						if (Main.player[target].position.Y > npc.position.Y + 300 // IF the target is lower than "300 below my height"
							&& npc.velocity.Y < 4) // AND I'm not at max "down" velocity
						{
							npc.velocity.Y += 0.2f; // accelerate down
						}
					}
					break;
				case 4:
					break;
			}
		}
		public void FindPlayers()
		{
			if (Main.netMode != NetmodeID.MultiplayerClient)
			{
				int originalCount = targets.Count;
				targets.Clear();
				for (int k = 0; k < 255; k++)
				{
					if (Main.player[k].active && Main.player[k].GetModPlayer<ElementumPlayer>().endurance != null)
					{
						targets.Add(k);
					}
				}
				if (Main.netMode == NetmodeID.Server && targets.Count != originalCount)
				{
					ModPacket netMessage = GetPacket();
					netMessage.Write(targets.Count);
					foreach (int target in targets)
					{
						netMessage.Write(target);
					}
					netMessage.Send();
				}
			}
		}
		public void Initialize()
		{
			npc.noGravity = true;
			npc.dontTakeDamage = true;
			attackProgress++;
			if (attackProgress >= 420)
			{
				attackProgress = 0;
				stage++;
				npc.dontTakeDamage = false;
			}
		}
		private void DoAttack(int attackType)
        {
			int frame = npc.direction;
			switch (attackType)
            {
				case 1:
					FireBallAttack(frame);
				break;
				case 2:
					TornadoAttack(frame);
					break;
				case 3:
					FireBallAttack2(frame);
					break;
				case 4:
					SpawnEgg();
					break;
			}
        }

		private void FireBallAttack(int Frame)
        {
			if (Frame == -1)
			{
				Projectile.NewProjectile(npc.Left.X, npc.Top.Y, 0f, 0f, ModContent.ProjectileType<ElderDragonFireball>(), 20, 0f, Main.myPlayer, npc.whoAmI, 10);
			}
			else
			{
				Projectile.NewProjectile(npc.Right.X, npc.Top.Y, 0f, 0f, ModContent.ProjectileType<ElderDragonFireball>(), 20, 0f, Main.myPlayer, npc.whoAmI, 10);
			}
		}

		private void TornadoAttack(int Frame)
		{
			if (Frame == -1)
			{
				Projectile.NewProjectile(npc.Left.X, npc.Top.Y, 0f, 0f, ModContent.ProjectileType<ElderDragonTornado>(), 20, 0f, Main.myPlayer, npc.whoAmI, 10);
			}
			else 
			{ 
				Projectile.NewProjectile(npc.Right.X, npc.Top.Y, 0f, 0f, ModContent.ProjectileType<ElderDragonTornado>(), 20, 0f, Main.myPlayer, npc.whoAmI, 10);
			}
		}

		private void FireBallAttack2(int Frame)
		{
			if (Frame == -1)
			{
				Projectile.NewProjectile(npc.Left.X, npc.Top.Y, npc.velocity.X, 0f, ModContent.ProjectileType<ElderDragonFireball2>(), 20, 0f, Main.myPlayer, npc.whoAmI, 10);
			}
			else
			{
				Projectile.NewProjectile(npc.Right.X, npc.Top.Y, npc.velocity.X, 0f, ModContent.ProjectileType<ElderDragonFireball2>(), 20, 0f, Main.myPlayer, npc.whoAmI, 10);
			}
		}
		private void SpawnEgg()
		{
			if(attackProgress >= 1000)
            {
				NPC.NewNPC((int)npc.Center.X, (int)npc.Bottom.Y, NPCID.MothronEgg, 0);
			}
		}








        private void OnHit(int damage)
		{
			damageTotal += damage;
		}
		public override void FindFrame(int frameHeight)
		{
			npc.spriteDirection = npc.direction;
		}
		private ModPacket GetPacket()
		{
			ModPacket packet = mod.GetPacket();
			packet.Write(npc.whoAmI);
			return packet;
		}
        public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit)
        {
			OnHit(damage);
        }
        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
		{
			OnHit(damage);
		}
	}
}