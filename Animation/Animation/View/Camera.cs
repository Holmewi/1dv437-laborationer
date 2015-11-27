#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion

namespace Animation.View
{
	public class Camera
	{
		private int sizeOfWindow;
		private int windowWidth;
		private int windowHeight;
		private float zoom = 1.0f;

		public Camera(GraphicsDevice device)
		{
			this.windowWidth = device.Viewport.Width;
			this.windowHeight = device.Viewport.Height;

			if (this.windowWidth > this.windowHeight) {
				this.sizeOfWindow = this.windowHeight;
			} else {
				this.sizeOfWindow = this.windowWidth;
			}
		}

		/**
		 * Sets visual coordinates
		 * The origo is set to the center of the screen
		 */
		public Vector2 GetVisualCoordinates(float logicX, float logicY)
		{
			float visualX = this.windowWidth * logicX + (this.windowWidth / 2);
			float visualY = this.windowHeight * logicY + (this.windowHeight / 2);
			return new Vector2(visualX, visualY);
		}

		public Vector2 GetVisualScale(int objectWidth, int objectHeight, float size)
		{
			float visualParticleSize = this.sizeOfWindow * size / this.zoom;
			float particleScaleX = (float)visualParticleSize / objectWidth;
			float particleScaleY = (float)visualParticleSize / objectHeight;
			return new Vector2 (particleScaleX, particleScaleY);
		}
	}

}

