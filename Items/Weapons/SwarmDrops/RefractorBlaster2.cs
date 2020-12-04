﻿using FargowiltasSouls.Projectiles.BossWeapons;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace FargowiltasSouls.Items.Weapons.SwarmDrops
{
    public class RefractorBlaster2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Diffractor Blaster");
            Tooltip.SetDefault("'The reward for slaughtering many...'");
            DisplayName.AddTranslation(GameCulture.Chinese, "暗星炮");
            Tooltip.AddTranslation(GameCulture.Chinese, "'由一个被击败的敌人的武器改装而来..'");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LaserRifle);
            item.damage = 300;
            item.channel = true;
            item.useTime = 24;
            item.useAnimation = 24;
            item.reuseDelay = 20;
            item.shootSpeed = 15f;
            item.UseSound = SoundID.Item15;
            item.value = 100000;
            item.rare = ItemRarityID.Purple;
            item.shoot = mod.ProjectileType("RefractorBlaster2Held");
            item.noUseGraphic = true;
            //item.mana = 10;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RefractorBlaster");
            recipe.AddIngredient(null, "MutantScale", 10);
            recipe.AddIngredient(ModLoader.GetMod("Fargowiltas").ItemType("EnergizerPrime"));
            recipe.AddTile(ModLoader.GetMod("Fargowiltas").TileType("CrucibleCosmosSheet"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
