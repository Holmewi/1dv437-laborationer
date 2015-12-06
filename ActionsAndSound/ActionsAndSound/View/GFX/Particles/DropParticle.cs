#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace ActionsAndSound.View.GFX.Particles
{
	public class DropParticle : Model.Particle
	{
		private Random random;

		private const float MAX_LIFE = 1.0f;
		private const float MAX_SPEED = 1.0f;
		private const float MAX_SIZE = 0.01f;
		private const float MIN_SIZE = 0.005f;

		private float timeLived = 0;
		private float lifePercent;

		public DropParticle(Texture2D texture, Vector2 position)
		{
			this.random = new Random ();

			base.Texture = texture;
			base.Position = position;

			base.Acceleration = new Vector2(0, 0.5f);
			base.Gravity = new Vector2(0, 5.5f);

			base.Velocity = new Vector2((float)this.random.NextDouble() - 0.5f, (float)this.random.NextDouble() - 0.5f);
			base.Velocity.Normalize ();
			base.Velocity = base.Velocity * ((float)this.random.NextDouble() * MAX_SPEED);

			base.Life = MAX_LIFE;
			base.Size = MIN_SIZE;

			base.Rotation = (float)this.random.NextDouble() * (3.0f - -3.0f) + -3.0f;
			base.RotationSpeed = (float)this.random.NextDouble () * (1.0f - -1.0f) + -1.0f;
		}

		public void Update(float elapsedTime) 
		{
			base.Life = base.Life - elapsedTime;

			this.timeLived += elapsedTime;
			this.lifePercent = this.timeLived / MAX_LIFE;
			base.Size = MIN_SIZE + this.lifePercent * MAX_SIZE;

			base.Fade = base.Fade - elapsedTime / MAX_LIFE;
			base.Rotation = base.Rotation + elapsedTime * base.RotationSpeed;

			base.Velocity = elapsedTime * base.Acceleration + base.Velocity;
			base.Position = elapsedTime * base.Velocity + base.Position;
		}

		public bool IsParticleDead() 
		{
			if (base.Life <= 0) {
				return true;
			}
			return false;
		}
	}

}

