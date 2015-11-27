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

namespace Animation.View
{
	public class ExplosionView
	{
		private List<Model.ExplosionSystem> explosionList = new List<Model.ExplosionSystem>();

		private View.Camera camera;
		private Texture2D explosionSpriteSheet;


		private Random random;

		public ExplosionView(ContentManager content, GraphicsDevice device, View.Camera camera)
		{
			this.camera = camera;
			this.explosionSpriteSheet = content.Load<Texture2D> ("explosion.png");
			this.random = new Random();
		}

		public void Start()
		{
			this.explosionList.Add(new Model.ExplosionSystem (new Vector2((float)this.random.NextDouble() * (0.2f - -0.2f) + -0.2f, (float)this.random.NextDouble() * (0.2f - -0.2f) + -0.2f)));
		}

		public void Update(float elapsedTime)
		{
			foreach (Model.ExplosionSystem explosion in this.explosionList.ToList()) {
				if (explosion != null) {
					if (explosion.IsDone ()) {
						this.explosionList.Remove (explosion);
					} else {
						explosion.Update(elapsedTime);
					}
				}
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			Vector2 textureCenterDisplacement = new Vector2 ((float)128 / 2, (float)128 / 2);

  			foreach (Model.ExplosionSystem explosion in this.explosionList) {
				if (explosion != null) {
					Vector2 scale = camera.GetVisualScale (128, 128, explosion.Size);
					spriteBatch.Draw (this.explosionSpriteSheet, camera.GetVisualCoordinates (explosion.Position.X, explosion.Position.Y), 
						new Rectangle (128 * explosion.FrameX, 128 * explosion.FrameY, 128, 128), Color.White, 0f, textureCenterDisplacement, scale, 
							SpriteEffects.None, 0f);
				}
			}
		}
	}

}

