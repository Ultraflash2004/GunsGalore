using Terraria.ID;
using Terraria.ModLoader; 
using Terraria;
using Microsoft.Xna.Framework;

namespace GunsGalore.Items
{
	public class GoldenGlock : ModItem
	{

	
		public override void SetStaticDefaults(){
			Tooltip.SetDefault("'Cha-Ching'");
		}

		public override void SetDefaults() {
			item.damage = 8;
			item.ranged = true;
			item.width = 30;
			item.height = 5;
			item.useTime = 12;
			item.useAnimation = 17;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 15f;
			item.useAmmo = AmmoID.Bullet;
		} 
		  
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(16);
			recipe.AddIngredient(19, 20);  
			recipe.AddIngredient(ItemID.Ruby, 8); 
			recipe.AddIngredient(ItemID.FlintlockPistol);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }  

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			// Here we manually spawn the 2nd projectile, manually specifying the projectile type that we wish to shoot.
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.GoldenBullet, damage, knockBack, player.whoAmI);
			// By returning true, the vanilla behavior will take place, which will shoot the 1st projectile, the one determined by the ammo.
			return true;
		}
			
		
	

		
	}
}
