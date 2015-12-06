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
	public class RainbowParticle : Model.Particle
	{
		private Random random;

		private const float MAX_LIFE = 0.4f;
		private const float MAX_SPEED = 0.02f;
		private const float MAX_SIZE = 0.7f;
		private const float MIN_SIZE = 0.02f;

		public RainbowParticle(Texture2D texture, Vector2 position)
		{
			this.random = new Random ();

			base.Texture = texture;
			base.Position = position;

			base.Acceleration = new Vector2((float)this.random.NextDouble() * (0.01f - -0.01f) + -0.01f, (float)this.random.NextDouble() * (0.01f - -0.01f) + -0.01f);

			base.Rotation = (float)this.random.NextDouble() * (3.0f - -3.0f) + -3.0f;
			base.RotationSpeed = (float)this.random.NextDouble () * (1.0f - -1.0f) + -1.0f;

			base.Size = 0;
			base.Timer = 0.2f;
		}

		public void Update(float elapsedTime) 
		{
			base.Life = base.Life - elapsedTime;
			base.Size = base.Size + elapsedTime * MAX_SIZE;
			base.Fade = base.Fade - 0.07f;
			base.Rotation = base.Rotation + elapsedTime * base.RotationSpeed;
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

