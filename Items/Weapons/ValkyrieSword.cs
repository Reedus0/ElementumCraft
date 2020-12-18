using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementumCraft.Items.Weapons
{
	public class ValkyrieSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Valkyrie's Sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("This is valghala's sword.");
		}

		public override void SetDefaults() 
		{
			item.damage = 20;
			item.UseSound = SoundID.Item1; 
			item.melee = true;
			item.width = 80;
			item.height = 80;
			item.useTime = 30;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 10000;
			item.rare = ItemRarityID.Lime;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 5f;
			item.shoot = mod.ProjectileType("ValkyrieSwordProjectile");
		}
	}
}
