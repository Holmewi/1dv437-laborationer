#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion

namespace ActionsAndSound.View
{
	public class Camera
	{
		private float boxMargin = 25;

		private float sizeOfBoxX;
		private float sizeOfBoxY;

		private int windowWidth;
		private int windowHeight;

		public Camera(GraphicsDevice device) 
		{
			this.windowWidth = device.Viewport.Width;
			this.windowHeight = device.Viewport.Height;

			this.sizeOfBoxX = ((float)this.windowWidth - this.boxMargin * 2);
			this.sizeOfBoxY = ((float)this.windowHeight - this.boxMargin * 2);
		}

		public Vector2 GetVisualCoordinates(float logicX, float logicY)
		{
			float visualX = this.boxMargin + this.sizeOfBoxX * logicX;
			float visualY = this.boxMargin + this.sizeOfBoxY * logicY;
			return new Vector2(visualX, visualY);
		}

		public Vector2 GetLogicCoordinates (int visualX, int visualY)
		{
			float logicX = (float)visualX / this.windowWidth;
			float logicY = (float)visualY / this.windowHeight;
			return new Vector2(logicX, logicY);
		}

		public float GetVisualScale(float logicSize, int width, int height) 
		{
			float visualSize;
			float scale;
			if (this.windowWidth > this.windowHeight) {
				visualSize = this.sizeOfBoxY * logicSize;
				scale = visualSize / (float)width;
			} else {
				visualSize = this.sizeOfBoxX * logicSize;
				scale = visualSize / (float)height;
			}
			return scale;
		}

		public float BoxMargin { get { return this.boxMargin; } }
	}
}

