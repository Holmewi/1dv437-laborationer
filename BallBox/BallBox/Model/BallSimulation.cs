#region Using Statements
using System;
using BallBox.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion

namespace BallBox.Model
{
	class BallSimulation
	{
		private Ball ball;
		private Box box;

		public BallSimulation() 
		{
			ball = new Ball ();
			box = new Box ();
		}

		public void boxCollider()
		{
			
		}

		public void Update(float seconds)
		{
			ball.Update (seconds);
		}

		public float getLogicBallRadius() 
		{
			return ball.Radius;
		}

		public float getBallPositionX()
		{
			return ball.PositionX;
		}

		public float getBallPositionY()
		{
			return ball.PositionY;
		}

		public void createBox(float top, float bottom, float left, float right) 
		{
			box.Top = top;
			box.Bottom = bottom;
			box.Left = left;
			box.Right = right;
		}

		public float BoxTop { get { return box.Top; } }
		public float BoxBottom { get { return box.Bottom; } }
		public float BoxLeft { get { return box.Left; } }
		public float BoxRight { get { return box.Right; } }
	}
}

