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

namespace ActionsAndSound.View.GFX
{
	public class SplashSystem
	{
		private List<Particles.Model.Particle> particleList = new List<Particles.Model.Particle>();

		private const int AMOUNT_DROP_PARTICLES = 15;
		private const float DROP_LIFE_TIME = 1.0f;
		private int dropCount = 0;

		private const int AMOUNT_RAINBOW_PARTICLES = 1;
		private const float RAINBOW_LIFE_TIME = 1.0f;
		private int rainbowCount = 0;

		private bool initialized = false;

		private View.Camera camera;
		private Vector2 position;
		private Texture2D dropTexture;
		private Texture2D rainbowTexture;

		public SplashSystem(View.Camera camera, Vector2 position, Texture2D dropTexture, Texture2D rainbowTexture) {
			this.camera = camera;
			this.position = position;
			this.dropTexture = dropTexture;
			this.rainbowTexture = rainbowTexture;
		}

		private void Init() 
		{
			this.initialized = true;

			if(this.dropCount < AMOUNT_DROP_PARTICLES) {
				this.particleList.Add (new Particles.DropParticle (this.dropTexture, this.position));
				this.dropCount++;
				this.initialized = false;
			}
			if(this.rainbowCount < AMOUNT_RAINBOW_PARTICLES) {
				this.particleList.Add (new Particles.RainbowParticle (this.rainbowTexture, this.position));
				this.rainbowCount++;
				this.initialized = false;
			}
		}

		public void Update(float elapsedTime) 
		{
			if (!this.initialized) {
				this.Init ();
			}

			foreach (Particles.Model.Particle particle in this.particleList.ToList()) {
				Particles.DropParticle drop = particle as Particles.DropParticle;
				Particles.RainbowParticle rainbow = particle as Particles.RainbowParticle;

				if (drop != null) {
					if (drop.IsParticleDead ()) {
						this.particleList.Remove (drop);
					} else {
						drop.Update (elapsedTime);
					}
				}

				if (rainbow != null) {
					rainbow.Timer = rainbow.Timer - elapsedTime;
					if (rainbow.IsParticleDead ()) {
						this.particleList.Remove (rainbow);
					} else if (rainbow.Timer <= 0f) {
						rainbow.Update (elapsedTime);
					}
				}
			}
		}

		public void Draw(SpriteBatch spriteBatch) 
		{
			foreach (Particles.Model.Particle particle in this.particleList.ToList()) {
				if (particle != null) {
					Vector2 textureCenterDisplacement = new Vector2 ((float)particle.Texture.Bounds.Width / 2, (float)particle.Texture.Bounds.Height / 2);
					float scale = this.camera.GetVisualScale (particle.Size, particle.Texture.Bounds.Width, particle.Texture.Bounds.Height);

					spriteBatch.Draw (particle.Texture, this.camera.GetVisualCoordinates (particle.Position.X, particle.Position.Y), 
						particle.Texture.Bounds, new Color (particle.Fade, particle.Fade, particle.Fade, particle.Fade), 
						particle.Rotation, textureCenterDisplacement, scale, SpriteEffects.None, 0f);
				}
			}
		}

		public bool IsDone()
		{
			if (this.initialized && this.particleList.Count <= 0) {
				Console.WriteLine ("done");
				return true;
			}
			return false;
		}
	}
}

