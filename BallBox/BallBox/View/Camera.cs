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
		private float boxWindowDisplacementX;
		private float boxWindowDisplacementY;

		public Camera(GraphicsDevice device) 
		{
			int windowWidth = device.Viewport.Width;
			int windowHeight = device.Viewport.Height;

			if (windowWidth > windowHeight) {
				this.sizeOfBox = (float)windowHeight - this.boxMargin * 2;
				this.boxWindowDisplacementX = (float)(windowWidth / 2) - ((this.sizeOfBox / 2) + this.boxMargin);
				this.boxWindowDisplacementY = 0;
			} else {
				this.sizeOfBox = (float)windowWidth - this.boxMargin * 2;
				this.boxWindowDisplacementX = 0;
				this.boxWindowDisplacementY = (float)(windowHeight / 2) - (this.sizeOfBox / 2 + this.boxMargin);
			}
		}

		public Vector2 getVisualCoordinates(float logicX, float logicY)
		{
			float visualX = this.sizeOfBox * logicX + this.boxMargin + this.boxWindowDisplacementX;
			float visualY = this.sizeOfBox * logicY + this.boxMargin + this.boxWindowDisplacementY;
			return new Vector2(visualX, visualY);
		}

		public Vector2 getVisualBallScale(float logicBallRadius, int textureWidth, int textureHeight) 
		{
			float visualBallRadius = this.sizeOfBox * logicBallRadius;
			float ballScaleX = (float)(visualBallRadius * 2) / textureWidth;
			float ballScaleY = (float)(visualBallRadius * 2) / textureHeight;
			return new Vector2(ballScaleX, ballScaleY);
		}

		public float BoxSize { get { return this.sizeOfBox; } }

		public float BoxMargin { get { return this.boxMargin; } }

		public float BoxWindowDisplacementX { get { return this.boxWindowDisplacementX; } }

		public float BoxWindowDisplacementY { get { return this.boxWindowDisplacementY; } }
	}
}

