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
			this.ball = new Ball ();
			this.box = new Box ();
		}

		public void Update(float seconds)
		{
			if (this.ball.PositionY + this.ball.Radius >= 1.0f || this.ball.PositionY - this.ball.Radius <= 0.0f) {
				this.setCollisionY ();
			}

			else if (this.ball.PositionX + this.ball.Radius >= 1.0f || this.ball.PositionX - this.ball.Radius <= 0.0f) {
				setCollisionX ();
			}

			this.ball.Update (seconds);
		}

		public void setCollisionY()
		{	
			// Ball hit top or bottom
			if (this.ball.SpeedX > 0.0f && this.ball.SpeedY > 0.0f) {
				this.ball.SpeedY = -0.25f;
			}
			else if (this.ball.SpeedX > 0.0f && this.ball.SpeedY < 0.0f) {
				this.ball.SpeedY = 0.25f;
			}
			else if (this.ball.SpeedX < 0.0f && this.ball.SpeedY < 0.0f) {
				this.ball.SpeedY = 0.25f;
			}
			else if (this.ball.SpeedX < 0.0f && this.ball.SpeedY > 0.0f) {
				this.ball.SpeedY = -0.25f;
			}
		}

		public void setCollisionX()
		{
			// Ball hit left or right
			if (this.ball.SpeedX > 0 && this.ball.SpeedY > 0) {
				this.ball.SpeedX = -0.25f;
			}
			else if (ball.SpeedX > 0 && this.ball.SpeedY < 0) {
				this.ball.SpeedX = -0.25f;
			}
			else if (this.ball.SpeedX < 0 && this.ball.SpeedY < 0) {
				this.ball.SpeedX = 0.25f;
			}
			else if (this.ball.SpeedX < 0 && this.ball.SpeedY > 0) {
				this.ball.SpeedX = 0.25f;
			}
		}

		public Ball Ball { get { return this.ball; } }

		public Box Box { get { return this.box; } }
	}
}

