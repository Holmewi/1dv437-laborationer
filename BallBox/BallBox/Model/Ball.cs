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
	class Ball
	{
		private float radius = 0.05f;
		private float positionX = 0.2f;
		private float positionY = 0.7f;
		private float speedX = 0.25f;
		private float speedY = 0.25f;

		public Ball() 
		{
			
		}

		public float Radius { get { return this.radius; } }

		public float PositionX { get { return this.positionX; } }

		public float PositionY { get { return this.positionY; } }

		public float SpeedX {
			get { return this.speedX; }
			set { this.speedX = value; }
		}

		public float SpeedY {
			get { return this.speedY; }
			set { this.speedY = value; }
		}

		public void Update(float timeElapsedSeconds) 
		{
			this.positionX = this.positionX + this.speedX * timeElapsedSeconds;
			this.positionY = this.positionY + this.speedY * timeElapsedSeconds;
		}
	}
}

