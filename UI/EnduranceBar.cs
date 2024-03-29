using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Terraria.ModLoader;


namespace ElementumCraft.UI
{
    class EnduranceBar : UIState
    {
		public static bool visible = false;
		private UIText text;
		private UIElement area;
		private UIImage barFrame;
		private Color gradientA;
		private Color gradientB;
		public override void OnInitialize()
		{
			// Create a UIElement for all the elements to sit on top of, this simplifies the numbers as nested elements can be positioned relative to the top left corner of this element. 
			// UIElement is invisible and has no padding. You can use a UIPanel if you wish for a background.
			area = new UIElement();
			area.Left.Set(area.Width.Pixels - 1020, 1f); // Place the resource bar to the left of the hearts.
			area.Top.Set(570, 0f); // Placing it just a bit below the top of the screen.
			area.Width.Set(80, 0f); // We will be placing the following 2 UIElements within this 182x60 area.
			area.Height.Set(20, 0f);

			barFrame = new UIImage(ModContent.GetTexture("ElementumCraft/UI/EnduranceBarFrame"));
			barFrame.Left.Set(22, 0f);
			barFrame.Top.Set(0, 0f);
			barFrame.Width.Set(138, 0f);
			barFrame.Height.Set(80, 0f);

			text = new UIText("0/0", 0.8f); // text to show stat
			text.Width.Set(60, 0f);
			text.Height.Set(10, 0f);
			text.Top.Set(3, 0f);
			text.Left.Set(30, 0f);

			gradientB =  new Color(164, 55, 65); //red
			gradientA = new Color(250, 160, 185); //red

			area.Append(barFrame);
			area.Append(text);
			Append(area);
		}
		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			base.DrawSelf(spriteBatch);

			var modPlayer = Main.LocalPlayer.GetModPlayer<ElementumPlayer>();
			// Calculate quotient
			float quotient = (float)modPlayer.endurance / (float)modPlayer.totalEndurance; // Creating a quotient that represents the difference of your currentResource vs your maximumResource, resulting in a float of 0-1f.
			quotient = Utils.Clamp(quotient, 0f, 1f); // Clamping it to 0-1f so it doesn't go over that.

			// Here we get the screen dimensions of the barFrame element, then tweak the resulting rectangle to arrive at a rectangle within the barFrame texture that we will draw the gradient. These values were measured in a drawing program.
			Rectangle hitbox = barFrame.GetInnerDimensions().ToRectangle();
			hitbox.X += 12;
			hitbox.Width -= 24;
			hitbox.Y += 8;
			hitbox.Height -= 16;

			// Now, using this hitbox, we draw a gradient by drawing vertical lines while slowly interpolating between the 2 colors.
			int left = hitbox.Left;
			int right = hitbox.Right;
			int steps = (int)((right - left) * quotient);
			for (int i = 0; i < steps; i += 1)
			{
				//float percent = (float)i / steps; // Alternate Gradient Approach
				float percent = (float)i / (right - left);
				spriteBatch.Draw(Main.magicPixel, new Rectangle(left + i, hitbox.Y - 4, 1, hitbox.Height + 7), Color.Lerp(gradientA, gradientB, percent));
			}
		}
		public override void Update(GameTime gameTime)
		{
			var modPlayer = Main.LocalPlayer.GetModPlayer<ElementumPlayer>();
			// Setting the text per tick to update and show our resource values.
			text.SetText($"{(int)modPlayer.endurance}");
			base.Update(gameTime);
		}
	}
}