using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace FargowiltasSouls.Items.Accessories.Enchantments
{
    public class TurtleEnchant : SoulsItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Turtle Enchantment");
            Tooltip.SetDefault(
@"When standing still and not attacking, you will enter your shell
While in your shell, you will gain 90% damage resistance and reflect projectiles
Taking 10 hits will break your shell
100% of contact damage is reflected
Enemies may explode into needles on death
Summons a pet Lizard and Turtle
'You suddenly have the urge to hide in a shell'");
            DisplayName.AddTranslation(GameCulture.Chinese, "乌龟魔石");
            Tooltip.AddTranslation(GameCulture.Chinese,
@"'你突然有一种想躲进壳里的冲动'
当站立不动且不攻击时,获得缩壳Buff
缩壳能阻挡所有抛射物,但是增加接触伤害
反弹100%接触伤害
敌人死亡时爆成针
召唤一只宠物蜥蜴和宠物海龟");
        }

        public override void SafeModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(248, 156, 92);
                }
            }
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = ItemRarityID.Yellow;
            item.value = 250000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>();
            modPlayer.CactusEffect();
            modPlayer.TurtleEffect(hideVisual);
            player.thorns = 1f;
            player.turtleThorns = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TurtleHelmet);
            recipe.AddIngredient(ItemID.TurtleScaleMail);
            recipe.AddIngredient(ItemID.TurtleLeggings);
            recipe.AddIngredient(null, "CactusEnchant");
            //chloro saber
            recipe.AddIngredient(ItemID.ChlorophytePartisan);
            //Yelets
            //jungle turtle
            recipe.AddIngredient(ItemID.Seaweed);
            recipe.AddIngredient(ItemID.LizardEgg);

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}