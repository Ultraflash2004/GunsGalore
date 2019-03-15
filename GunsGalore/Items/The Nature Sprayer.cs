using Terraria.ID;
using Terraria.ModLoader; 
using Terraria;
using Microsoft.Xna.Framework;

namespace GunsGalore.Items
{
	public class TheNatureSprayer : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Freshly Grown'");
		}

		public override void SetDefaults() {
			item.damage = 16;
			item.ranged = true;
			item.width = 60;
			item.height = 45;
			item.useTime = 6;
			item.useAnimation = 40;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 2;
			item.value = 10000;
			item.rare = 4;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 17f;
			item.useAmmo = AmmoID.Bullet;
		} 
	
	   public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(134);  
			recipe.AddIngredient(331, 30); 
			recipe.AddIngredient(210, 15); 
			recipe.AddIngredient(208, 3);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }  

	
		// What if I wanted an inaccurate gun? (Chain Gun)
		// Inaccurate Gun style: Single Projectile, Random spread 
		  public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
		}
		
		// Help, my gun isn't being held at the handle! Adjust these 2 numbers until it looks right.
		  public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, 0);
		}
		
	}
}
