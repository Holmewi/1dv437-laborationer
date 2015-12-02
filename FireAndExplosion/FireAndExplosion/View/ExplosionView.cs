#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

#endregion

namespace FireAndExplosion.View
{
	public class ExplosionView
	{
		private List<Model.ExplosionSystem> explosionList = new List<Model.ExplosionSystem>();
		private View.Camera camera;

		// Makes sure only one explosion is created
		private float timer = 0;

		public ExplosionView(GraphicsDevice device, View.Camera camera)
		{
			this.camera = camera;
		}

		public void Start(Model.Textures textures, Vector2 mousePosition, float elapsedTime)
		{
			if (this.timer <= 0) {
				this.timer = 0.1f;
				this.explosionList.Add (new Model.ExplosionSystem (textures, mousePosition));
			}
			this.timer -= elapsedTime;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			foreach(Model.ExplosionSystem explosion in this.explosionList) {
				if (explosion != null) {
					foreach(Model.Particle particle in explosion.Particles) {
						if (particle != null) {
							Vector2 textureCenterDisplacement = new Vector2 ((float)particle.Texture.Bounds.Width / 2, (float)particle.Texture.Bounds.Height / 2);
							Vector2 scale = this.camera.GetVisualTextureScale (particle.Texture.Bounds.Width, particle.Texture.Bounds.Height, particle.Size);
					
							spriteBatch.Draw (particle.Texture, this.camera.GetVisualCoordinates (particle.Position.X, particle.Position.Y), 
												particle.Texture.Bounds, new Color (particle.Fade, particle.Fade, particle.Fade, particle.Fade), 
												particle.Rotation, textureCenterDisplacement, scale, SpriteEffects.None, 0f);
						}
					}
				}
			}
		}

		public List<Model.ExplosionSystem> Explosions { get { return this.explosionList; } }
	}
}

