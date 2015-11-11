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
		public Vector2 getVisualCoords(float logicX, float logicY) 
		{
			float visualX = 10;
			float visualY = 10;
			return new Vector2(visualX, visualY);
		}
	}


}

