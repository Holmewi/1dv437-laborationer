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

		private BallSimulation ballSimulation;
		private GraphicsDevice device;
		private Camera camera;
		private LineDrawer line;

		public BoxView(BallSimulation ballSimulation, ContentManager content, GraphicsDevice device, Camera camera) 
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch (device);

			this.ballSimulation = ballSimulation;
			this.device = device;
			this.camera = camera;
			this.line = new LineDrawer (device);

			this.ballSimulation.Box.Top = this.camera.BoxMargin + this.camera.BoxWindowDisplacementY;
			this.ballSimulation.Box.Bottom = this.camera.BoxMargin + this.camera.BoxSize + this.camera.BoxWindowDisplacementY;
			this.ballSimulation.Box.Left = this.camera.BoxMargin + this.camera.BoxWindowDisplacementX;
			this.ballSimulation.Box.Right = this.camera.BoxMargin + this.camera.BoxSize + this.camera.BoxWindowDisplacementX;
		}

		public void DrawBox() 
		{
			spriteBatch.Begin ();

			Vector2 topLeftCornerPos = new Vector2 (this.ballSimulation.Box.Left, this.ballSimulation.Box.Top);
			Vector2 topRightCornerPos = new Vector2 (this.ballSimulation.Box.Right, this.ballSimulation.Box.Top);
			Vector2 bottomLeftCornerPos = new Vector2 (this.ballSimulation.Box.Left, this.ballSimulation.Box.Bottom);
			Vector2 bottomRightCornerPos = new Vector2 (this.ballSimulation.Box.Right, this.ballSimulation.Box.Bottom);

			this.line.DrawLine (spriteBatch, topLeftCornerPos, topRightCornerPos, Color.White);
			this.line.DrawLine (spriteBatch, topRightCornerPos, bottomRightCornerPos, Color.White);
			this.line.DrawLine (spriteBatch, bottomRightCornerPos, bottomLeftCornerPos, Color.White);
			this.line.DrawLine (spriteBatch, bottomLeftCornerPos, topLeftCornerPos, Color.White);

			spriteBatch.End ();
		}
	}
}

