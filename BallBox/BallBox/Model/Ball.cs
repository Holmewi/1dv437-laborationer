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
		private float position;
		private float speed;
		private float radius = 0.05f;

		public Ball() 
		{
			
		}

		public float Radius 
		{
			get { return this.radius; }
			set { this.radius = value; }
		}


	}


}

