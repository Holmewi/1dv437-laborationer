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

		public BallSimulation() 
		{
			ball = new Ball ();
		}

		public float getLogicBallRadius() 
		{
			return ball.Radius;
		}
	}
}

