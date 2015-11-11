#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion

namespace BallBox.View
{
	class Camera
	{
		private float boxMargin = 25;
		private float sizeOfBox;

		private float windowHeight;
		private float windowWidth;

		public Camera(GraphicsDevice device) 
		{
			this.windowHeight = device.Viewport.Height;
			this.windowWidth = device.Viewport.Width;

			if (this.windowWidth > this.windowHeight) {
				this.sizeOfBox = (float)this.windowHeight - this.boxMargin * 2;
			} else {
				this.sizeOfBox = (float)this.windowWidth - this.boxMargin * 2;
			}
		}

		public Vector2 getVisualCoordinates(float logicX, float logicY)
		{
			float visualX = this.sizeOfBox * logicX + this.boxMargin;
			float visualY = this.sizeOfBox * logicY + this.boxMargin;
			return new Vector2(visualX, visualY);
		}

		public Vector2 getVisualBallScale(float logicBallRadius, int textureWidth, int textureHeight) 
		{
			float visualBallRadius = this.sizeOfBox * logicBallRadius;
			float ballScaleX = (float)(visualBallRadius * 2) / textureWidth;
			float ballScaleY = (float)(visualBallRadius * 2) / textureHeight;
			return new Vector2(ballScaleX, ballScaleY);
		}

		public float getBoxSize() 
		{
			return this.sizeOfBox;
		}

		public float getBoxMargin() 
		{
			return this.boxMargin;
		}
	}


}

