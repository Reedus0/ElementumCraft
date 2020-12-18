using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementumCraft.Items
{
	public class HeartOfTheOcean : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heart Of The Ocean"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults()
		{
			item.width = 64;
			item.height = 64;
			item.maxStack = 1;
			item.rare = 7;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SpecularFish, 3);
			recipe.AddIngredient(ItemID.Seashell, 5);
			recipe.AddIngredient(ItemID.Starfish, 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}