#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

#endregion

namespace FireAndExplosion.Model
{
	public class ShockwaveParticle : Model.Particle
	{
		private Random random;

		private const float MAX_LIFE = 0.2f;
		private const float MAX_SPEED = 0.02f;
		private const float MAX_SIZE = 0.7f;
		private const float MIN_SIZE = 0.02f;

		public ShockwaveParticle(Texture2D texture, Vector2 position)
		{
			this.random = new Random ();

			base.Texture = texture;
			base.Position = position;
			base.Acceleration = new Vector2((float)this.random.NextDouble() * (0.01f - -0.01f) + -0.01f, (float)this.random.NextDouble() * (0.01f - -0.01f) + -0.01f);

			base.Size = MIN_SIZE;
			base.Timer = 0.2f;
		}

		public void Update(float elapsedTime) {
			base.Life = base.Life - elapsedTime;
			base.Size = base.Size + elapsedTime;
			base.Fade = base.Fade - 0.07f;
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

