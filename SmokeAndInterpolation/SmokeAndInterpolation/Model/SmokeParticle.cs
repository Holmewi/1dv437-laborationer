#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using SmokeAndInterpolation.View;

#endregion

namespace SmokeAndInterpolation.Model
{
	public class SmokeParticle
	{
		private float maxSpeed = 0.3f;

		private Vector2 randomDirection;
		private Vector2 startRandomDirection;
		private Vector2 position = new Vector2(0, 0.45f);
		private Vector2 acceleration = new Vector2(0, -1.8f);

		private float minSize = 0.02f; // 1.0f is the size of the sizeOfWindow in the Camera class.
		private float currentSize;

		private float particleLife = 5.0f;

		public SmokeParticle(Random random)
		{
			this.randomDirection = new Vector2((float)random.NextDouble() - 0.5f, (float)random.NextDouble() - 0.5f);
			//normalize to get it spherical vector with length 1.0
			this.randomDirection.Normalize();
			//add random length between 0 to maxSpeed
			this.randomDirection = randomDirection * ( (float)random.NextDouble() * this.maxSpeed);
			this.startRandomDirection = this.randomDirection;
		}

		/**
		 * Used to respawn the particle at starting values
		 */
		public void Respawn(int i) 
		{
			Console.WriteLine ("Respawn " + i);
			this.position = new Vector2(0, 0.45f);
			this.randomDirection = this.startRandomDirection;
			this.particleLife = 5.0f;
		}

		public void Draw(Camera camera, Texture2D particlesmoke, SpriteBatch spriteBatch)
		{
			int particleTextureWidth = particlesmoke.Bounds.Width;
			int particleTextureHeight = particlesmoke.Bounds.Height;

			// Sets the displacement to the center of the texture
			Vector2 smokeTextureCenterDisplacement = new Vector2 ((float)particleTextureWidth / 2, (float)particleTextureHeight / 2);

			// Sets the scale of the the texture independently of the resolution 
			Vector2 scale = camera.GetVisualParticleScale (particleTextureWidth, particleTextureHeight, this.minSize);

			spriteBatch.Draw (particlesmoke, camera.GetVisualCoordinates (this.position.X, this.position.Y) 
				- smokeTextureCenterDisplacement * scale, 
				null, Color.White, 0f, Vector2.Zero, scale, 
				SpriteEffects.None, 0f);
		}

		public void Update(float elapsedTime)
		{
			this.particleLife -= elapsedTime;

			this.randomDirection = elapsedTime * this.acceleration + this.randomDirection;
			this.position = elapsedTime * this.randomDirection + this.position;
		}

		public float ParticleLife { get { return this.particleLife; } }
	}
}

