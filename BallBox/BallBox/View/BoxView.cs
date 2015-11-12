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

		public BoxView(BallSimulation ballSimulation, ContentManager content, GraphicsDevice device, Camera camera) 
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch (device);

			this.ballSimulation = ballSimulation;
			this.camera = camera;
			line = new LineDrawer (device);

			// Top, bottom, left, right
			ballSimulation.createBox (this.camera.getBoxMargin(), 
				this.camera.getBoxSize() + this.camera.getBoxMargin(), 
										this.camera.getBoxMargin(), 
										this.camera.getBoxSize() + this.camera.getBoxMargin());
		}

		public void DrawBox() 
		{
			spriteBatch.Begin ();

			Vector2 topLeftCornerPos = new Vector2 (ballSimulation.BoxTop, ballSimulation.BoxLeft);
			Vector2 topRightCornerPos = new Vector2 (ballSimulation.BoxRight, ballSimulation.BoxTop);
			Vector2 bottomLeftCornerPos = new Vector2 (ballSimulation.BoxLeft, ballSimulation.BoxBottom);
			Vector2 bottomRightCornerPos = new Vector2 (ballSimulation.BoxBottom, ballSimulation.BoxRight);

			line.DrawLine (spriteBatch, topLeftCornerPos, topRightCornerPos, Color.White);
			line.DrawLine (spriteBatch, topRightCornerPos, bottomRightCornerPos, Color.White);
			line.DrawLine (spriteBatch, bottomRightCornerPos, bottomLeftCornerPos, Color.White);
			line.DrawLine (spriteBatch, bottomLeftCornerPos, topLeftCornerPos, Color.White);

			spriteBatch.End ();
		}
	}
}

