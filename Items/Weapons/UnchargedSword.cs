using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementumCraft.Items.Weapons
{
	public class UnchargedSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Uncharged Sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("This sword needs to be chearhed.");
		}

		public override void SetDefaults()
		{
			item.damage = 10;
			item.melee = true;
			item.width = 80;
			item.height = 80;
			item.useTime = 10;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.width = 64;
			item.height = 64;
			item.maxStack = 1;
			item.rare = 7;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ElementumIngot>(), 15);
			recipe.AddIngredient(ItemID.Obsidian, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
