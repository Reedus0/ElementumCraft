using Terraria;
using Terraria.ModLoader;

namespace ElementumCraft.Buffs
{
    public class Fatigue : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Fatigue");
            Description.SetDefault("You fatigue and need to relax. Damage significatly reduced.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Terraria.Player player, ref int buffIndex)
        {
            player.meleeDamage = 0.2f;
            player.meleeSpeed = 0.5f;
        }
    }
}