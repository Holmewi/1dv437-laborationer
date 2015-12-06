#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

#endregion

namespace ActionsAndSound.View.GFX
{
	public class BurstSystem
	{
		private View.Camera camera;
		private Vector2 position;
		private float radius;
		private Texture2D texture;

		private float timeElapsed;
		private int frameX;
		private int frameY;

		private const int NUMBER_OF_FRAMES = 16;
		private const float MAX_TIME = 0.6f;
		private const int NUM_FRAMES_X = 4;
		private const int NUM_FRAMES_Y = 4;

		public int count = 0;

		public BurstSystem(View.Camera camera, Vector2 position, float radius, Texture2D texture) {
			this.camera = camera;
			this.position = position;
			this.radius = radius;
			this.texture = texture;
		}
			
		public void Update(float elapsedTime)
		{
			this.count++;
			this.timeElapsed += elapsedTime;
			float percentAnimated = timeElapsed / MAX_TIME;
			int frame = (int)(percentAnimated * NUMBER_OF_FRAMES);

			this.frameX = frame % NUM_FRAMES_X;
			this.frameY = frame / NUM_FRAMES_X;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			int frameWidth = this.texture.Bounds.Width / NUM_FRAMES_X;
			int frameHeight = this.texture.Bounds.Height / NUM_FRAMES_Y;

			Vector2 textureCenterDisplacement = new Vector2 ((float)frameWidth / 2, (float)frameHeight / 2);

			float scale = this.camera.GetVisualScale (this.radius * 2, frameWidth, frameHeight);

			spriteBatch.Draw (this.texture, camera.GetVisualCoordinates (this.position.X, this.position.Y), 
				new Rectangle (frameWidth * this.frameX, frameHeight * this.frameY, frameWidth, frameHeight), Color.White, 0f, textureCenterDisplacement, scale, 
				SpriteEffects.None, 0f);


		}
			
		public bool IsDone()
		{
			if (this.frameX * this.frameY > NUMBER_OF_FRAMES) {
				return true;
			}
			return false;
		}
	}
}

