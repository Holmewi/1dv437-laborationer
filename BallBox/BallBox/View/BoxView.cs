#region Using Statements
using System;
using BallBox.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using BallBox.Model;
using Microsoft.Xna.Framework.Content;

#endregion

namespace BallBox.View
{
	class BoxView
	{
		SpriteBatch spriteBatch;
		BallSimulation ballSimulation;

		LineDrawer line;

		private float boxMargin = 25;
		private float boxTop;
		private float boxBottom;
		private float boxLeft;
		private float boxRight;

		public BoxView(BallSimulation ballSimulation, ContentManager content, GraphicsDevice device) 
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch (device);

			this.ballSimulation = ballSimulation;

			line = new LineDrawer (device);

			this.boxTop = this.boxMargin;
			this.boxBottom = device.Viewport.Height - this.boxMargin;
			this.boxLeft = this.boxMargin;
			this.boxRight = device.Viewport.Width - this.boxMargin;
		}

		public void DrawBox() 
		{
			spriteBatch.Begin ();

			Vector2 topLeftCornerPos = new Vector2 (this.boxTop, this.boxLeft);
			Vector2 topRightCornerPos = new Vector2 (this.boxRight, this.boxTop);
			Vector2 bottomLeftCornerPos = new Vector2 (this.boxLeft, this.boxBottom);
			Vector2 bottomRightCornerPos = new Vector2 (this.boxBottom, this.boxRight);

			line.DrawLine (spriteBatch, topLeftCornerPos, topRightCornerPos, Color.White);
			line.DrawLine (spriteBatch, topRightCornerPos, bottomRightCornerPos, Color.White);
			line.DrawLine (spriteBatch, bottomRightCornerPos, bottomLeftCornerPos, Color.White);
			line.DrawLine (spriteBatch, bottomLeftCornerPos, topLeftCornerPos, Color.White);

			spriteBatch.End ();
		}
	}
}

