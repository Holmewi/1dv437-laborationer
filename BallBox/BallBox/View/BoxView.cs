#region Using Statements
using System;
using BallBox.Model;
using BallBox.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

#endregion

namespace BallBox.View
{
	class BoxView
	{
		SpriteBatch spriteBatch;
		BallSimulation ballSimulation;
		Camera camera;
		LineDrawer line;

		private float boxTop;
		private float boxBottom;
		private float boxLeft;
		private float boxRight;

		public BoxView(BallSimulation ballSimulation, ContentManager content, GraphicsDevice device, Camera camera) 
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch (device);

			this.ballSimulation = ballSimulation;
			this.camera = camera;
			line = new LineDrawer (device);

			this.boxTop = camera.getBoxMargin();
			this.boxBottom = device.Viewport.Height - camera.getBoxMargin();
			this.boxLeft = camera.getBoxMargin();
			this.boxRight = device.Viewport.Width - camera.getBoxMargin();
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

