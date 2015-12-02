#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace FireAndExplosion.Model
{
	public class ExplosionSystem
	{
		private List<Model.Particle> particleList = new List<Model.Particle>();

		private Textures textures;
		private Vector2 position;

		private const int AMOUNT_SMOKE_PARTICLES = 15;
		private const int AMOUNT_FIRE_PARTICLES = 20;
		private const int AMOUNT_SPLITTER_PARTICLES = 20;
		private const int AMOUNT_SHOCKWAVE_PARTICLES = 1;

		private const float SMOKE_LIFE_TIME = 1.0f;
		private const float FIRE_LIFE_TIME = 1.0f;
		private const float SPLITTER_LIFE_TIME = 1.0f;

		private float smokeSpawnTime = 0;
		private float fireSpawnTime = 0;
		private float splitterSpawnTime = 0;

		private int smokeCount = 0;
		private int fireCount = 0;
		private int splitterCount = 0;
		private int shockwaveCount = 0;

		private bool initialized = false;


		public ExplosionSystem(Model.Textures textures, Vector2 position)
		{
			this.textures = textures;
			this.position = position;
		}

		public void Create(float elapsedTime)
		{
			this.initialized = true;

			if(this.smokeCount < AMOUNT_SMOKE_PARTICLES) {
				if (this.smokeSpawnTime >= SMOKE_LIFE_TIME / (float)AMOUNT_SMOKE_PARTICLES) {
					this.particleList.Add (new Model.SmokeParticle (this.textures.SmokeTexture, this.position));
					this.smokeCount++;
				}
				this.initialized = false;
			}
			if(this.fireCount < AMOUNT_FIRE_PARTICLES) {
				if (this.fireSpawnTime >= FIRE_LIFE_TIME / (float)AMOUNT_FIRE_PARTICLES) {
					this.particleList.Add (new Model.FireParticle (this.textures.FireTexture, this.position));
					this.fireCount++;
				}
				this.initialized = false;
			}
			if(this.splitterCount < AMOUNT_SPLITTER_PARTICLES) {
				if (this.splitterSpawnTime >= SPLITTER_LIFE_TIME / (float)AMOUNT_SPLITTER_PARTICLES) {
					this.particleList.Add (new Model.SplitterParticle (this.textures.SplitterTexture, this.position));
					this.splitterCount++;
				}
				this.initialized = false;
			}
			if(this.shockwaveCount < AMOUNT_SHOCKWAVE_PARTICLES) {
				this.particleList.Add (new Model.ShockwaveParticle (this.textures.ShockwaveTexture, this.position));
				this.shockwaveCount++;
				this.initialized = false;
			}
		}

		public void Update(float elapsedTime) 
		{
			this.smokeSpawnTime += elapsedTime;
			this.fireSpawnTime += elapsedTime;
			this.splitterSpawnTime += elapsedTime;

			if (!this.initialized) {
				this.Create (elapsedTime);
			}

			foreach (Model.Particle particle in this.particleList.ToList()) {
				
				Model.SmokeParticle smoke = particle as Model.SmokeParticle;
				Model.FireParticle fire = particle as Model.FireParticle;
				Model.SplitterParticle splitter = particle as Model.SplitterParticle;
				Model.ShockwaveParticle shockwave = particle as Model.ShockwaveParticle;

				if(smoke != null) {
					if (smoke.IsParticleDead ()) {
						this.particleList.Remove (smoke);
					} else {
						smoke.Update (elapsedTime);
					}
				}
				if(fire != null) {
					if (fire.IsParticleDead ()) {
						this.particleList.Remove (fire);
					} else {
						fire.Update (elapsedTime);
					}
				}
				if(splitter != null) {
					if (splitter.IsParticleDead ()) {
						this.particleList.Remove (splitter);
					} else {
						splitter.Update (elapsedTime);
					}
				}
				if(shockwave != null) {
					shockwave.Timer = shockwave.Timer - elapsedTime;
					if (shockwave.IsParticleDead ()) {
						this.particleList.Remove (shockwave);
					} else if (shockwave.Timer <= 0f) { 
						shockwave.Update (elapsedTime);
					}
				}
			}
		}

		public List<Model.Particle> Particles { get { return this.particleList; } }
	}
}

