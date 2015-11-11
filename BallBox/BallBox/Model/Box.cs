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
	public class Box
	{
		private float boxTop;
		private float boxBottom;
		private float boxLeft;
		private float boxRight;

		public Box()
		{
			
		}

		public float Top
		{
			get { return this.boxTop; }
			set { this.boxTop = value; }
		}

		public float Bottom
		{
			get { return this.boxBottom; }
			set { this.boxBottom = value; }
		}

		public float Left
		{
			get { return this.boxLeft; }
			set { this.boxLeft = value; }
		}

		public float Right
		{
			get { return this.boxRight; }
			set { this.boxRight = value; }
		}
	}

}

