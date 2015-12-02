#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion

namespace FireAndExplosion.View
{
	public class Camera
	{
		private int minSideOfWindow;
		private int windowWidth;
		private int windowHeight;

		public Camera(GraphicsDevice device) 
		{
			this.windowWidth = device.Viewport.Width;
			this.windowHeight = device.Viewport.Height;

			if (this.windowWidth > this.windowHeight) {
				this.minSideOfWindow = this.windowHeight;
			} else {
				this.minSideOfWindow = this.windowWidth;
			}
		}
			
		public Vector2 GetVisualCoordinates(float logicX, float logicY)
		{
			float visualX = this.windowWidth * logicX;
			float visualY = this.windowHeight * logicY;
			return new Vector2(visualX, visualY);
		}

		public Vector2 GetLogicCoordinates (int visualX, int visualY)
		{
			float logicX = (float)visualX / this.windowWidth;
			float logicY = (float)visualY / this.windowHeight;
			return new Vector2(logicX, logicY);
		}

		public Vector2 GetVisualTextureScale(int textureWidth, int textureHeight, float logicTextureSize)
		{
			float visualTextureSize = this.minSideOfWindow * logicTextureSize;
			float textureScaleX = (float)visualTextureSize / textureWidth;
			float textureScaleY = (float)visualTextureSize / textureHeight;
			return new Vector2 (textureScaleX, textureScaleY);
		}
	}

}

