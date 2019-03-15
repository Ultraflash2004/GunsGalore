using Terraria.ID;
using Terraria.ModLoader; 
using Terraria;
using Microsoft.Xna.Framework;

namespace GunsGalore.Items
{
	public class ElementalEqualizer : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Mighty, Sighted and frightning");
		}

		public override void SetDefaults() {
			item.damage = 65;
			item.ranged = true;
			item.width = 60;
			item.height = 45;
			item.useTime = 16;
			item.useAnimation = 40;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 3;
			item.value = 10000;
			item.rare = 7;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 50f;
			item.useAmmo = AmmoID.Bullet;
		} 
	
	   public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(134);
			recipe.AddIngredient(547, 20);  
			recipe.AddIngredient(548, 20); 
			recipe.AddIngredient(549, 20); 
			recipe.AddIngredient(173, 50);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }  

	
		// What if I wanted multiple projectiles in a even spread? (Vampire Knives) 
		// Even Arc style: Multiple Projectile, Even Spread 
		  public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 3 + Main.rand.Next(0); // 3, 4, or 5 shots
			float rotation = MathHelper.ToRadians(7);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}		

		// Help, my gun isn't being held at the handle! Adjust these 2 numbers until it looks right.
		  public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, 0);
		}
		
	}
}
