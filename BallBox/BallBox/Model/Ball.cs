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
		private float positionX = 0.5f;
		private float positionY = 0.5f;
		private float speed = 0.25f;
		private float radius = 0.05f;

		public Ball() 
		{
			
		}

		public float Radius 
		{
			get { return this.radius; }
		}

		public float PositionX
		{
			get { return this.positionX; }
		}

		public float PositionY
		{
			get { return this.positionY; }
		}

		public void Update(float timeElapsedSeconds) 
		{
			this.positionX = positionX + speed * timeElapsedSeconds;
			this.positionY = positionY + speed * timeElapsedSeconds;
		}
	}
}

