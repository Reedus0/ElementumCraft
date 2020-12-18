using Terraria.ID;
using Terraria.ModLoader;

namespace ElementumCraft.Items.Weapons
{
	public class TomohawkOfOcean : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Tomohawk Of The Ocean"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("This tomohawk was created by an elder of sirens.");
		}

		public override void SetDefaults() 
		{
			item.damage = 20;
			item.UseSound = SoundID.Item20;
			item.melee = true;
			item.width = 80;
			item.height = 80;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 10000;
			item.rare = ItemRarityID.Lime;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 8f;
			item.shoot = mod.ProjectileType("TomohawkOfOceanProjectile");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ElementumIngot>(), 15);
			recipe.AddIngredient(ModContent.ItemType<HeartOfTheOcean>(), 1);
			recipe.AddIngredient(ItemID.WaterBucket, 3);
			recipe.AddIngredient(ItemID.SharkFin, 5);
			recipe.AddIngredient(ItemID.Glowstick, 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
