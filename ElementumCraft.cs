using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using ElementumCraft.UI;

namespace ElementumCraft
{
	class ElementumCraft : Mod
	{
		internal UserInterface customInterface;
		internal EnduranceBar Bar;
		private GameTime _lastUpdateUiGameTime;
		public ElementumCraft()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}

		public override void UpdateUI(GameTime gameTime)
		{
			_lastUpdateUiGameTime = gameTime;
			if (customInterface?.CurrentState != null)
			{
				customInterface.Update(gameTime);
			}
		}
		public override void Load()
        {
			if (!Main.dedServ)
			{
				customInterface = new UserInterface();

				Bar = new EnduranceBar();
				Bar.Activate(); // Activate calls Initialize() on the UIState if not initialized, then calls OnActivate and then calls Activate on every child element
				EnduranceBar.visible = true;
				customInterface?.SetState(Bar);

			}
			base.Load();
        }
		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (mouseTextIndex != -1)
			{
				layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
					"Interface",
					delegate
					{
						if (_lastUpdateUiGameTime != null && customInterface?.CurrentState != null)
						{
                            if (EnduranceBar.visible)
                            {
								customInterface.Draw(Main.spriteBatch, _lastUpdateUiGameTime);
							}
						}
						return true;
					},
					   InterfaceScaleType.UI));
			}
		}
	}
}