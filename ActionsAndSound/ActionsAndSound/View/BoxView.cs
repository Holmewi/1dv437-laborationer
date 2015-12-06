#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

#endregion

namespace ActionsAndSound.View
{
	class BoxView
	{
		private Model.Box box;
		private View.LineDrawer line;
		private View.Camera camera;

		public BoxView(GraphicsDevice device, View.Camera camera) 
		{
			this.box = new Model.Box ();
			this.line = new View.LineDrawer (device);
			this.camera = camera;

			/*
			this.box.Top = this.camera.BoxMargin + this.camera.BoxWindowDisplacement.Y;
			this.box.Bottom = this.camera.BoxMargin + this.camera.BoxSize + this.camera.BoxWindowDisplacement.Y;
			this.box.Left = this.camera.BoxMargin + this.camera.BoxWindowDisplacement.X;
			this.box.Right = this.camera.BoxMargin + this.camera.BoxSize + this.camera.BoxWindowDisplacement.X;
			*/

			this.box.Top = this.camera.BoxMargin;
			this.box.Bottom = device.Viewport.Height - this.camera.BoxMargin;
			this.box.Left = this.camera.BoxMargin;
			this.box.Right = device.Viewport.Width - this.camera.BoxMargin;
		}

		public void DrawBox(SpriteBatch spriteBatch) 
		{
			Vector2 topLeftCornerPos = new Vector2 (this.box.Left, this.box.Top);
			Vector2 topRightCornerPos = new Vector2 (this.box.Right, this.box.Top);
			Vector2 bottomLeftCornerPos = new Vector2 (this.box.Left, this.box.Bottom);
			Vector2 bottomRightCornerPos = new Vector2 (this.box.Right, this.box.Bottom);

			this.line.DrawLine (spriteBatch, topLeftCornerPos, topRightCornerPos, Color.White);
			this.line.DrawLine (spriteBatch, topRightCornerPos, bottomRightCornerPos, Color.White);
			this.line.DrawLine (spriteBatch, bottomRightCornerPos, bottomLeftCornerPos, Color.White);
			this.line.DrawLine (spriteBatch, bottomLeftCornerPos, topLeftCornerPos, Color.White);
		}
	}
}

