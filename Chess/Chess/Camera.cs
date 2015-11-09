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
		int sizeOfTile = 64;
		int borderSize = 64;

		public Vector2 getVisualCoordinates(int logicX, int logicY)
		{
			int visualX = borderSize + logicX * sizeOfTile;
			int visualY = borderSize + logicY * sizeOfTile;
			return new Vector2(visualX, visualY);
		}
	}


}

