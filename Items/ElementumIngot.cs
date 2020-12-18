using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ElementumCraft.Items;

namespace ElementumCraft.Items
{
	public class ElementumIngot : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Elementum Ingot"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("This is an ancient ingot from ancient ore.");
		}

		public override void SetDefaults()
		{

			item.width = 80;
			item.height = 80;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.rare = 6;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Placeable.ElementumOre>(), 5);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}