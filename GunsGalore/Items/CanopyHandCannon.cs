using Terraria.ID;
using Terraria.ModLoader; 
using Terraria;
using Microsoft.Xna.Framework;

namespace GunsGalore.Items
{
	public class CanopyHandCannon : ModItem
	{
         public override void SetStaticDefaults() { 
		     Tooltip.SetDefault("'The Vines are going into your arm... eww'");
		 }	
		public override void SetDefaults() {
			
            item.damage = 105; 
            item.ranged = true; 
            item.width = 40; 
            item.height = 30; 
            item.useTime = 30;
            item.useAnimation = 40; 
            item.knockBack = 5;
            item.UseSound = SoundID.Item11; 
            item.noMelee = true; 
            item.useStyle = 5; 
            item.rare = 7; 
			item.value = 10000; 
			item.shoot = 10;
            item.shootSpeed = 18f;          
            item.autoReuse = true; 
			item.useAmmo = AmmoID.Bullet;
        }   
	     
		  
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(173);
			recipe.AddIngredient(331, 50);  
			recipe.AddIngredient(3261, 15); 
			recipe.AddIngredient(1552, 10); 
			recipe.AddIngredient(1006, 25);
			recipe.AddIngredient(549, 5);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }  
		
			// What if I wanted multiple projectiles in a even spread? (Vampire Knives) 
		// Even Arc style: Multiple Projectile, Even Spread 
		  public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 7 + Main.rand.Next(0); // 3, 4, or 5 shots
			float rotation = MathHelper.ToRadians(2);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		
			
		
	

		
	}
}
