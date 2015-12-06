﻿using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ActionsAndSound.View
{
	public class LineDrawer
	{
		private Texture2D t; //base for the line texture

		public LineDrawer (GraphicsDevice device)
		{
			LoadContent (device);
		}

		/** Borrowed code
		 * @author_ Ken
		 * Source: http://gamedev.stackexchange.com/questions/44015/how-can-i-draw-a-simple-2d-line-in-xna-without-using-3d-primitives-and-shders
		*/
		private void LoadContent(GraphicsDevice device) 
		{
			// create 1x1 texture for line drawing
			t = new Texture2D(device, 1, 1);
			t.SetData<Color>(
				new Color[] { Color.White });// fill the texture with white
		}

		/** Borrowed code
		 * @author_ Ken
		 * Source: http://gamedev.stackexchange.com/questions/44015/how-can-i-draw-a-simple-2d-line-in-xna-without-using-3d-primitives-and-shders
		 * Added color param: Joakim
		*/
		public void DrawLine(SpriteBatch sb, Vector2 start, Vector2 end, Color color)
		{
			Vector2 edge = end - start;
			// calculate angle to rotate line
			float angle =
				(float)Math.Atan2(edge.Y , edge.X);

			sb.Draw(t,
				new Rectangle(// rectangle defines shape of line and position of start of line
					(int)start.X,
					(int)start.Y,
					(int)edge.Length(), //sb will strech the texture to fill this rectangle
					1), //width of line, change this to make thicker line
				null,
				color, //colour of line
				angle,     //angle of line (calulated above)
				new Vector2(0, 0), // point in line about which to rotate
				SpriteEffects.None,
				0);
		}
	}
}

