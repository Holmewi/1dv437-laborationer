#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace ActionsAndSound.Model
{
	class BallSimulation
	{
		private List<Model.Ball> ballList = new List<Model.Ball>();

		private const int NUMBER_OF_BALLS = 10;
		private float ballSpawnTimer = 1.0f;
		private float ballSpawnTimerByClick = 1.0f;

		private Random random;

		public BallSimulation() 
		{
			this.random = new Random ();
		}
			
		public void Update(float elapsedTime)
		{
			if (this.ballSpawnTimer >= 1.0f && this.ballList.Count < NUMBER_OF_BALLS) {
				Vector2 position = new Vector2((float)random.NextDouble () * (0.9f - 0.1f) + 0.1f, (float)random.NextDouble () * (0.9f - 0.1f) + 0.1f);
				float radius = (float)random.NextDouble () * (0.1f - 0.05f) + 0.05f;
				this.CreateBall (position, radius);
				this.ballSpawnTimer = 0f;
			}
			this.ballSpawnTimer += elapsedTime;
			this.ballSpawnTimerByClick += elapsedTime;

			foreach(Model.Ball ball in this.ballList) {
				this.CheckBoxCollision (ball);
				ball.Position = elapsedTime * (ball.Velocity + ball.Collision) + ball.Position;
				ball.CollisionX = 0;
				ball.CollisionY = 0;
			}
				
			int theball = 0;
			while (this.ballList.Count > theball)
			{
				int otherBall = theball + 1;
				while (this.ballList.Count > otherBall)
				{
					if (this.BallsColliding (this.ballList [theball], this.ballList [otherBall])) {
						this.CollisionCalculation (this.ballList [theball], this.ballList [otherBall]);
					}
					otherBall++;
				}
				theball++;
			}
		}

		private void CreateBall(Vector2 position, float radius) {

			Model.Ball newBall;
			bool collision = false;
			int i = 0;

			do {
				newBall = this.GenerateBall(position, radius);
				collision = false;

				while (i < this.ballList.Count) {
					if (this.BallsColliding (newBall, this.ballList [i])) {
						collision = true;
					}
					i++;
				}
			} while(collision);
			if (!collision) {
				this.ballList.Add(newBall);
			}
		}

		public Model.Ball CheckBubbleHit(Vector2 mousePos)
		{
			foreach(Model.Ball ball in this.ballList.ToList()) {
				float xd = ball.Position.X - mousePos.X;
				float yd = ball.Position.Y - mousePos.Y;
				float sqrRadius = ball.Radius * ball.Radius;

				float distSqr = (xd * xd) + (yd * yd);

				if (distSqr <= sqrRadius) {
					this.ballSpawnTimer = 1.0f;
					if (ball.Radius <= 0.06f) {
						this.ballList.Remove (ball);
						return ball;
					} else {
						if(this.ballSpawnTimerByClick >= 1.0f) {
							float radius = ball.Radius * 0.75f;
							Vector2 ball1Pos = new Vector2 (mousePos.X + radius * 0.75f, mousePos.Y + radius * 0.75f);
							Vector2 ball2Pos = new Vector2 (mousePos.X - radius * 0.75f, mousePos.Y - radius * 0.75f);
							this.ballList.Remove (ball);
							this.CreateBall (ball1Pos, radius);
							this.CreateBall (ball2Pos, radius);
							this.ballSpawnTimerByClick = 0f;
						}
					}

				}
			}
			return null;
		}

		private void CheckBoxCollision(Ball ball)
		{
			// Ball hit top
			if (ball.Position.Y - ball.Radius <= 0.0f) {
				this.SetCollisionY (ball);
				ball.PositionY = 0.0f + ball.Radius;
			}

			// Ball hit bottom
			else if (ball.Position.Y + ball.Radius >= 1.0f) {
				this.SetCollisionY (ball);
				ball.PositionY = 1.0f - ball.Radius;
			}

			// Ball hit left
			else if (ball.Position.X - ball.Radius <= 0.0f) {
				this.SetCollisionX (ball);
				ball.PositionX = 0.0f + ball.Radius;
			}

			// Ball hit right
			else if (ball.Position.X + ball.Radius >= 1.0f) {
				this.SetCollisionX (ball);
				ball.PositionX = 1.0f - ball.Radius;
			}
		}

		private void SetCollisionY(Ball ball)
		{	
			// Ball move towards bottom right
			if (ball.Velocity.X > 0 && ball.Velocity.Y > 0) {
				ball.VelocityY = ball.Velocity.Y * -1;
			}
			// Ball move towards top right
			else if (ball.Velocity.X > 0 && ball.Velocity.Y < 0) {
				ball.VelocityY = Math.Abs(ball.Velocity.Y);
			}
			// Ball move towards top left
			else if (ball.Velocity.X < 0 && ball.Velocity.Y < 0) {
				ball.VelocityY = Math.Abs(ball.Velocity.Y);
			}
			// Ball move towards bottom left
			else if (ball.Velocity.X < 0 && ball.Velocity.Y > 0) {
				ball.VelocityY = ball.Velocity.Y * -1;
			}
		}

		private void SetCollisionX(Ball ball)
		{
			// Ball move towards bottom right
			if (ball.Velocity.X > 0 && ball.Velocity.Y > 0) {
				ball.VelocityX = ball.Velocity.X * -1;
			}
			// Ball move towards top right
			else if (ball.Velocity.X > 0 && ball.Velocity.Y < 0) {
				ball.VelocityX = ball.Velocity.X * -1;
			}
			// Ball move towards top left
			else if (ball.Velocity.X < 0 && ball.Velocity.Y < 0) {
				ball.VelocityX = Math.Abs(ball.Velocity.X);
			}
			// Ball move towards bottom left
			else if (ball.Velocity.X < 0 && ball.Velocity.Y > 0) {
				ball.VelocityX = Math.Abs(ball.Velocity.X);
			}
		}

		public List<Model.Ball> Balls { get { return this.ballList; } }

		/**
		 * Borrowed code from kc3vv
		 * Source: https://www.youtube.com/watch?v=OnWj1KU5ueU&index=2&list=PL7pJMbthqgFutow15zPPGUiPqeYCunzPd
		 * Edited it to fit this project
		 */

		private bool BallsColliding(Model.Ball ball1, Model.Ball ball2)
		{
			float xd = ball1.Position.X - ball2.Position.X;
			float yd = ball1.Position.Y - ball2.Position.Y;
			float sumRadius = ball1.Radius + ball2.Radius;
			float sqrRadius = sumRadius * sumRadius;

			// The distance between the ball1 square and ball2 square
			float distSqr = (xd * xd) + (yd * yd);
		
			//calculation including Velocity
			//float vxd = (ball1.Position.X + ball1.Velocity.X) - (ball2.Position.X + ball2.Velocity.X); //0.1 - 0.7 = -0.6
			//float vyd = (ball1.Position.Y + ball1.Velocity.Y) - (ball2.Position.Y + ball2.Velocity.Y); //0.9 - 0.4 = 0.5
			//float vecDistSqr = (vxd * vxd) + (vyd * vyd); // 0.86 + 0.25 = 1.11

			if (distSqr <= sqrRadius) {
				if (ball1.CollisionOn || ball2.CollisionOn) {
					ball1.CollisionOn = false;
					ball2.CollisionOn = false;
					return true;
				} else {
					this.CollisionCalculation (ball1, ball2);
				}
				return false;
			} else {
				ball1.CollisionOn = true;
				ball2.CollisionOn = true;
				return false;
			}
		}


		/**
		 * Borrowed code from kc3vv
		 * * Source: https://www.youtube.com/watch?v=OnWj1KU5ueU&index=2&list=PL7pJMbthqgFutow15zPPGUiPqeYCunzPd
		 * Edited it to fit this project
		 */
		private void CollisionCalculation(Model.Ball ball1, Model.Ball ball2)
		{
			//Find normal vector
			Vector2 nv = new Vector2(ball2.Position.X - ball1.Position.X, ball2.Position.Y - ball1.Position.Y);

			//Find normal vector's modulus, i.e. length
			float nvmod = (float)Math.Sqrt(Math.Pow(nv.X, 2) + Math.Pow(nv.Y, 2));

			//Find unitnormal
			double ex = (ball1.Position.X - ball2.Position.X) / nvmod;
			double ey = (ball1.Position.Y - ball2.Position.Y) / nvmod;

			//Find tangent
			double ox = -1*ey;
			double oy = ex;

			//Balls normal speed before collision
			double e1x = (ball1.Velocity.X * ex + ball1.Velocity.Y * ey) * ex;
			double e1y = (ball1.Velocity.X * ex + ball1.Velocity.Y * ey) * ey;
			double e2x = (ball2.Velocity.X * ex + ball2.Velocity.Y * ey) * ex;
			double e2y = (ball2.Velocity.X * ex + ball2.Velocity.Y * ey) * ey;

			//Balls tangential speed 
			double o1x = (ball1.Velocity.X * ox + ball1.Velocity.Y * oy) * ox;
			double o1y = (ball1.Velocity.X * ox + ball1.Velocity.Y * oy) * oy;
			double o2x = (ball2.Velocity.X * ox + ball2.Velocity.Y * oy) * ox;
			double o2y = (ball2.Velocity.X * ox + ball2.Velocity.Y * oy) * oy;

			//Calculate normal speeds after the collision
			double vxs = (ball1.Mass * e1x + ball2.Mass * e2x) / (ball1.Mass + ball2.Mass);
			double vys = (ball1.Mass * e1y + ball2.Mass * e2y) / (ball1.Mass + ball2.Mass);

			//Balls velocity after Collision
			double vx1 = -e1x + 2 * vxs + o1x;
			double vy1 = -e1y + 2 * vys + o1y;
			double vx2 = -e2x + 2 * vxs + o2x;
			double vy2 = -e2y + 2 * vys + o2y;

			//Console.WriteLine ("e1x: " + e1x + ", e1y: " + e1y + ", e2x: " + e2x + ", e2y: " + e2y);
			//Console.WriteLine ("o1x: " + o1x + ", o1y: " + o1y + ", o2x: " + o2x + ", o2y: " + o2y);
			//Console.WriteLine ("vx1: " + vx1 + ", vy1: " + vy1 + ", vx2: " + vx2 + ", vy2: " + vy2);

			ball1.VelocityX = (float)vx1;
			ball1.VelocityY = (float)vy1;
			ball2.VelocityX = (float)vx2;
			ball2.VelocityY = (float)vy2;

			//ball1.PositionX = ball1.Position.X + nv.X;
			//ball1.PositionY = ball1.Position.Y + nv.Y;
			//ball2.PositionX = ball2.Position.X - nv.X;
			//ball2.PositionY = ball2.Position.Y - nv.Y;
		}

		public Model.Ball GenerateBall(Vector2 position, float radius) {
			return new Model.Ball (this.random, position, radius);
		}
	}
}

