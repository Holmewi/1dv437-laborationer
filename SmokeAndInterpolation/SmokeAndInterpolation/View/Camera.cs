#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion

namespace SmokeAndInterpolation.View
{
	public class Camera
	{
		private int sizeOfWindow;
		private int windowWidth;
		private int windowHeight;

		public Camera (GraphicsDevice device)
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

		public Vector2 GetVisualParticleScale(int particleTextureWidth, int particleTextureHeight, float logicParticleSize)
		{
			float visualParticleSize = this.sizeOfWindow * logicParticleSize;
			float particleScaleX = (float)visualParticleSize / particleTextureWidth;
			float particleScaleY = (float)visualParticleSize / particleTextureHeight;
			return new Vector2 (particleScaleX, particleScaleY);
		}
	}

}

