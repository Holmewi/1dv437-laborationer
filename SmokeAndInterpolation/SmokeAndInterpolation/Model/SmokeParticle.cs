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
		private Random random;

		/**
		 * Values which is used when spawning a particle
		 * @Vector2 startPosition and acceleration is the same for all particles
		 * @float rotationSpeed gives a random value in the SpawnParticle method
		 */
		private Vector2 startPosition = new Vector2(0, 0.45f);
		private Vector2 acceleration = new Vector2(0, -0.1f);
		private float rotationSpeed;

		/**
		 * Constant floats which are used to define constant varialbles
		 */
		private const float MAX_LIFE = 5.0f;
		private const float MAX_SPEED = 0.05f;
		private const float MAX_SIZE = 0.3f;
		private const float MIN_SIZE = 0.02f;

		/**
		 * Variables which values are changed in the update method
		 * Are set to it's default values in the SpawnParticle method
		 */
		private Vector2 velocity;
		private Vector2 position;

		private float size;
		private float life = 0;
		private float timeLived = 0;
		private float lifePercent;
		private float fade = 1.0f;
		private float rotation;




		public SmokeParticle(Random random)
		{
			this.random = random;
		}

		/**
		 * Method used to spawn and respawn the particle with it's default values
		 */
		public void SpawnParticle() 
		{
			this.position = this.startPosition;

			this.velocity = new Vector2((float)this.random.NextDouble() - 0.5f, (float)this.random.NextDouble() - 0.5f);
			this.velocity.Normalize();
			this.velocity = this.velocity * ((float)this.random.NextDouble() * MAX_SPEED);

			this.life = MAX_LIFE;
			this.timeLived = 0;
			this.size = MIN_SIZE;
			this.fade = 1.0f;

			this.rotationSpeed = (float)this.random.NextDouble () * (1.0f - -1.0f) + -1.0f;
			this.rotation = (float)this.random.NextDouble() - MathHelper.PiOver4;
		}

		public void Draw(Camera camera, Texture2D particlesmoke, SpriteBatch spriteBatch)
		{
			Color color = new Color(fade, fade, fade, fade);

			int particleTextureWidth = particlesmoke.Bounds.Width;
			int particleTextureHeight = particlesmoke.Bounds.Height;

			// Sets the displacement to the center of the texture
			Vector2 smokeTextureCenterDisplacement = new Vector2 ((float)particleTextureWidth / 2, (float)particleTextureHeight / 2);

			// Sets the scale of the the texture independently of the resolution 
			Vector2 scale = camera.GetVisualParticleScale (particleTextureWidth, particleTextureHeight, this.size);

			spriteBatch.Draw (particlesmoke, camera.GetVisualCoordinates (this.position.X, this.position.Y), 
				particlesmoke.Bounds, color, this.rotation, smokeTextureCenterDisplacement, scale, 
				SpriteEffects.None, 0f);
		}

		public void Update(float elapsedTime)
		{
			this.life -= elapsedTime;

			this.timeLived += elapsedTime;
			this.lifePercent = this.timeLived / MAX_LIFE;
			this.size = MIN_SIZE + this.lifePercent * MAX_SIZE;

			this.fade -= elapsedTime / MAX_LIFE;
			this.rotation += elapsedTime * this.rotationSpeed;

			this.velocity = elapsedTime * this.acceleration + this.velocity;
			this.position = elapsedTime * this.velocity + this.position;
		}

		public bool IsParticleDead() 
		{ 
			if (this.life <= 0) {
				return true;
			}
			return false;
		}
	}
}

