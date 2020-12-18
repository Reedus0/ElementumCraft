using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementumCraft.Items.Weapons
{
	public class SwordOfTheForest : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sword Of The Forest"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("This sword was created by an elder of the wood elves.");
		}

		public override void SetDefaults() 
		{
			item.damage = 27;
			item.UseSound = SoundID.Item1; 
			item.melee = true;
			item.width = 80;
			item.height = 80;
			item.useTime = 10;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 10000;
			item.rare = ItemRarityID.Lime;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ElementumIngot>(), 15);
			recipe.AddIngredient(ItemID.Wood, 35);
			recipe.AddIngredient(ItemID.Sunflower, 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void OnHitNPC(Terraria.Player player, NPC target, int damage, float knockBack, bool crit)
		{
			target.AddBuff(BuffID.Chilled, 300);
			target.AddBuff(BuffID.CursedInferno, 300);
		}
	}
}
