using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementumCraft.NPCs
{
	// This ModNPC serves as an example of a complete AI example.
	public class ElderGhost : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.width = 80;
			npc.height = 100;
			npc.aiStyle = 44;
			npc.damage = 7;
			npc.defense = 2;
			npc.lifeMax = 25;
			aiType = NPCID.Wraith;
			animationType = NPCID.Wraith;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.OverworldNightMonster.Chance * 0.5f;
		}
	}
}