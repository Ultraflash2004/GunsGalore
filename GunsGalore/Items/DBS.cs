using Terraria.ID;
using Terraria.ModLoader; 
using Terraria;
using Microsoft.Xna.Framework;

namespace GunsGalore.Items
{
	public class DBS : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Two barrels. Twice the inaccurate fun!'");
		}

		public override void SetDefaults() {
			item.damage = 105;
			item.ranged = true;
			item.width = 40;
			item.height = 30;
			item.useTime = 18;
			item.useAnimation = 40;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 10000;
			item.rare = 8;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 20f;
			item.useAmmo = AmmoID.Bullet;
		} 
		  
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddIngredient(ItemID.Wood, 300); 
			recipe.anyWood = true; 
			recipe.AddIngredient(ItemID.Shotgun, 2); 
			recipe.AddIngredient(ItemID.TacticalShotgun);
			recipe.AddIngredient(ItemID.Ectoplasm, 15);
			recipe.SetResult(this);
			recipe.AddRecipe();
        } 
		    public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, 0);
		}
			public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 4 + Main.rand.Next(2); // 4 or 5 shots 
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(25)); // 30 degree spread.
				// If you want to randomize the speed to stagger the projectiles
				// float scale = 1f - (Main.rand.NextFloat() * .3f);
				// perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false; // return false because we don't want tmodloader to shoot projectile
		}

		
	}
}
