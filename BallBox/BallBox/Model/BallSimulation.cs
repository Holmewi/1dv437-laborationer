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

		public void setCollisionY()
		{	
			// Ball hit top or bottom
			if (ball.SpeedX > 0.0f && ball.SpeedY > 0.0f) {
				ball.SpeedY = -0.25f;
			}
			else if (ball.SpeedX > 0.0f && ball.SpeedY < 0.0f) {
				ball.SpeedY = 0.25f;
			}
			else if (ball.SpeedX < 0.0f && ball.SpeedY < 0.0f) {
				ball.SpeedY = 0.25f;
			}
			else if (ball.SpeedX < 0.0f && ball.SpeedY > 0.0f) {
				ball.SpeedY = -0.25f;
			}
		}

		public void setCollisionX()
		{
			// Ball hit left or right
			if (ball.SpeedX > 0 && ball.SpeedY > 0) {
				ball.SpeedX = -0.25f;
			}
			else if (ball.SpeedX > 0 && ball.SpeedY < 0) {
				ball.SpeedX = -0.25f;
			}
			else if (ball.SpeedX < 0 && ball.SpeedY < 0) {
				ball.SpeedX = 0.25f;
			}
			else if (ball.SpeedX < 0 && ball.SpeedY > 0) {
				ball.SpeedX = 0.25f;
			}
		}

		public void Update(float seconds)
		{
			if (ball.PositionY + ball.Radius >= 1.0f || ball.PositionY - ball.Radius <= 0.0f) {
				this.setCollisionY ();
			}

			else if (ball.PositionX + ball.Radius >= 1.0f || ball.PositionX - ball.Radius <= 0.0f) {
				setCollisionX ();
			}

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

