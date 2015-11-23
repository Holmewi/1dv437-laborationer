#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using SplitterAndGravitation.View;

#endregion

namespace SplitterAndGravitation.Model
{
	public class SplitterParticle
	{
		private float maxSpeed = 0.3f;
		private float size = 0.8f;
		private Vector2 randomDirection;
		private Vector2 position = new Vector2(0, 0);
		private Vector2 acceleration = new Vector2(0, 0.8f);

		public SplitterParticle(Random random) 
		{
			this.randomDirection = new Vector2((float)random.NextDouble() - 0.5f, (float)random.NextDouble() - 0.5f);
			//normalize to get it spherical vector with length 1.0
			this.randomDirection.Normalize();
			//add random length between 0 to maxSpeed
			this.randomDirection = randomDirection * ( (float)random.NextDouble() * this.maxSpeed);
		}
			
		public void Draw(Camera camera, Texture2D spark, SpriteBatch spriteBatch) 
		{
			int sparkTextureWidth = spark.Bounds.Width;
			int sparkTextureHeight = spark.Bounds.Height;

			// Sets the displacement to the center of the texture
			Vector2 sparkTextureCenterDisplacement = new Vector2 ((float)sparkTextureWidth / 2, (float)sparkTextureHeight / 2);

			// Sets the scale of the the texture to 0.1 independently of the resolution 
			Vector2 scale = camera.GetVisualParticleScale (sparkTextureWidth, sparkTextureHeight, this.size);

			if (this.position.Y < 0.5f) 
			{
				spriteBatch.Draw (spark, camera.GetVisualCoordinates (this.position.X, this.position.Y) 
									- sparkTextureCenterDisplacement * scale, 
									null, Color.White, 0f, Vector2.Zero, scale, 
									SpriteEffects.None, 0f);
			}

		}

		public void Update(float elapsedTime)
		{
			this.randomDirection.X = elapsedTime * this.acceleration.X + this.randomDirection.X;
			this.randomDirection.Y = elapsedTime * this.acceleration.Y + this.randomDirection.Y;

			this.position.X = elapsedTime * this.randomDirection.X + this.position.X;
			this.position.Y = elapsedTime * this.randomDirection.Y + this.position.Y;
		}
	}
}

