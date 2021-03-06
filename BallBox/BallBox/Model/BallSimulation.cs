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
			// Why is the ball position reach above 1.0f when hitting the bottom?
			Console.WriteLine (this.ball.PositionY + this.ball.Radius);

			// Ball hit top
			if (this.ball.PositionY - this.ball.Radius <= 0.0f) {
				this.setCollisionY ();
				this.ball.PositionY = 0.0f + this.ball.Radius;
			}

			// Ball hit bottom
			else if (this.ball.PositionY + this.ball.Radius >= 1.0f) {
				this.setCollisionY ();
				this.ball.PositionY = 1.0f - this.ball.Radius;
			}

			// Ball hit left
			else if (this.ball.PositionX - this.ball.Radius <= 0.0f) {
				setCollisionX ();
				this.ball.PositionX = 0.0f + this.ball.Radius;
			}

			// Ball hit right
			else if (this.ball.PositionX + this.ball.Radius >= 1.0f) {
				setCollisionX ();
				this.ball.PositionX = 1.0f - this.ball.Radius;
			}

			this.ball.Update (seconds);
		}

		public void setCollisionY()
		{	
			// Ball move towards bottom right
			if (this.ball.SpeedX > 0 && this.ball.SpeedY > 0) {
				this.ball.SpeedY = -0.9f;
			}
			// Ball move towards top right
			else if (this.ball.SpeedX > 0 && this.ball.SpeedY < 0) {
				this.ball.SpeedY = 0.9f;
			}
			// Ball move towards top left
			else if (this.ball.SpeedX < 0 && this.ball.SpeedY < 0) {
				this.ball.SpeedY = 0.9f;
			}
			// Ball move towards bottom left
			else if (this.ball.SpeedX < 0 && this.ball.SpeedY > 0) {
				this.ball.SpeedY = -0.9f;
			}
		}

		public void setCollisionX()
		{
			// Ball move towards bottom right
			if (this.ball.SpeedX > 0 && this.ball.SpeedY > 0) {
				this.ball.SpeedX = -0.5f;
			}
			// Ball move towards top right
			else if (ball.SpeedX > 0 && this.ball.SpeedY < 0) {
				this.ball.SpeedX = -0.5f;
			}
			// Ball move towards top left
			else if (this.ball.SpeedX < 0 && this.ball.SpeedY < 0) {
				this.ball.SpeedX = 0.5f;
			}
			// Ball move towards bottom left
			else if (this.ball.SpeedX < 0 && this.ball.SpeedY > 0) {
				this.ball.SpeedX = 0.5f;
			}
		}

		public Ball Ball { get { return this.ball; } }

		public Box Box { get { return this.box; } }
	}
}

