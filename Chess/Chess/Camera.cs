#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

#endregion

namespace Chess
{
	public class Camera
	{
		private int sizeOfTile = 64;
		private int borderSize = 64;
		private float scale;

		public Vector2 getVisualCoordinates(int logicX, int logicY)
		{
			int visualX = Convert.ToInt32((borderSize + logicX * sizeOfTile) * scale);
			int visualY = Convert.ToInt32((borderSize + logicY * sizeOfTile) * scale);
			return new Vector2(visualX, visualY);
		}

		public Vector2 getRotatedCameraView(int logicX, int logicY)
		{
			int visualX = Convert.ToInt32(((8 * sizeOfTile + borderSize - sizeOfTile) - logicX * sizeOfTile) * scale);
			int visualY = Convert.ToInt32(((8 * sizeOfTile + borderSize - sizeOfTile) - logicY * sizeOfTile) * scale);
			return new Vector2(visualX, visualY);
		}


		public Vector2 getScale(GraphicsDevice device) 
		{
			int windowHeight = device.Viewport.Height;
			int windowWidth = device.Viewport.Width;

			if (windowWidth > windowHeight) {
				this.scale = (float)windowHeight / (8 * sizeOfTile + borderSize * 2);
			} else {
				this.scale = (float)windowWidth / (8 * sizeOfTile + borderSize * 2);
			}
				
			return new Vector2(scale, scale);
		}
	}
}

