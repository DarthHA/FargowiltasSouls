﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Items.Accessories.Masomode
{
    public class ChaliceoftheMoon : ModItem
    {
        public override string Texture => "FargowiltasSouls/Items/Placeholder";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chalice of the Moon");
            Tooltip.SetDefault(
@"Increases life regeneration
Grants immunity to Venom, Burning, and Fused
Grants immunity to Marked for Death, Clipped Wings, and Hexed
Grants immunity to Atrophied, Jammed, Reverse Mana Flow, and Antisocial
Attracts a legendary plant's offspring which flourishes in combat
You erupt into Ancient Visions when injured
Summons a friendly Cultist");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.rare = 10;
            item.value = Item.sellPrice(0, 10);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //magical bulb
            player.lifeRegen += 2;
            player.buffImmune[BuffID.Venom] = true;
            player.AddBuff(mod.BuffType("PlanterasChild"), 5);
            //lihzahrd treasure
            player.buffImmune[BuffID.Burning] = true;
            player.buffImmune[mod.BuffType("Fused")] = true;
            //celestial rune
            player.buffImmune[mod.BuffType("MarkedforDeath")] = true;
            player.buffImmune[mod.BuffType("ClippedWings")] = true;
            player.buffImmune[mod.BuffType("Hexed")] = true;
            //chalice
            player.buffImmune[mod.BuffType("Atrophied")] = true;
            player.buffImmune[mod.BuffType("Jammed")] = true;
            player.buffImmune[mod.BuffType("ReverseManaFlow")] = true;
            player.buffImmune[mod.BuffType("Antisocial")] = true;
            player.GetModPlayer<FargoPlayer>().MoonChalice = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(mod.ItemType("MagicalBulb"));
            recipe.AddIngredient(mod.ItemType("LihzahrdTreasureBox"));
            recipe.AddIngredient(mod.ItemType("CelestialRune"));
            recipe.AddIngredient(ItemID.FragmentSolar, 10);
            recipe.AddIngredient(ItemID.FragmentVortex, 10);
            recipe.AddIngredient(ItemID.FragmentNebula, 10);
            recipe.AddIngredient(ItemID.FragmentStardust, 10);

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
