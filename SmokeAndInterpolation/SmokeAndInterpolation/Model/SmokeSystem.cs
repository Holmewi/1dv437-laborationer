#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

#endregion

namespace SmokeAndInterpolation.Model
{
	public class SmokeSystem
	{
		private Texture2D particlesmoke;

		private View.Camera camera;
		private List<Model.SmokeParticle> smoke = new List<Model.SmokeParticle>();

		private const int MAX_AMOUNT_PARTICLES = 200;
		private const int PARTICLE_LIFE_TIME = 5;

		private float spawnTime = 0;


		public SmokeSystem (ContentManager content, GraphicsDevice device, View.Camera camera)
		{
			this.particlesmoke = content.Load<Texture2D> ("particlesmoke.tga");
			this.camera = camera;
		}

		/**
		 * Create particles whenever they need to be used
		 */
		private void Create()
		{
			if(this.smoke.Count < MAX_AMOUNT_PARTICLES) {	
				Random random = new Random();
				this.smoke.Add(new Model.SmokeParticle(random));
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			for (int i = 0; i < this.smoke.Count; i++) 
			{
				this.smoke[i].Draw (this.camera, this.particlesmoke, spriteBatch);
			}
		}

		public void Update(float elapsedTime) 
		{
			this.spawnTime += elapsedTime;

			if (this.spawnTime >= (float)PARTICLE_LIFE_TIME / (float)MAX_AMOUNT_PARTICLES) {
				this.Create ();
				this.spawnTime = 0;
			}

			for (int i = 0; i < this.smoke.Count; i++) 
			{
				this.smoke[i].Update (elapsedTime);

				if (this.smoke [i].ParticleLife <= 0) {
					this.smoke [i].Respawn (i);
				}
			}
		}
	}

}

