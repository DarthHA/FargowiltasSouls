using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace FargowiltasSouls.Items.Accessories.Enchantments
{
    public class BeetleEnchant : SoulsItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Beetle Enchantment");

            string tooltip =
@"Beetles protect you from damage, up to 15% damage reduction only
Increases flight time by 50%
'The unseen life of dung courses through your veins'";
            string tooltip_ch =
@"'你的血管里流淌着看不见的粪便生命'
甲虫保护你免受伤害
增加100%飞行时间";

            Tooltip.SetDefault(tooltip);
            DisplayName.AddTranslation(GameCulture.Chinese, "甲虫魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, tooltip_ch);
        }

        public override void SafeModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(109, 92, 133);
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
            //defense beetle bois
            modPlayer.BeetleEffect();
            modPlayer.wingTimeModifier += .5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BeetleHelmet);
            recipe.AddRecipeGroup("FargowiltasSouls:AnyBeetle");
            recipe.AddIngredient(ItemID.BeetleLeggings);
            recipe.AddIngredient(ItemID.BeetleWings);
            recipe.AddIngredient(ItemID.BeeWings);
            recipe.AddIngredient(ItemID.ButterflyWings);
            recipe.AddIngredient(ItemID.MothronWings);
            //breaker blade
            //amarok
            //beetle minecart

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}