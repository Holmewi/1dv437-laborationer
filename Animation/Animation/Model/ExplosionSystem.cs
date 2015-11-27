#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion

namespace Animation.Model
{
	public class ExplosionSystem
	{
		private Vector2 position;

		private float timeElapsed;
		private int frameX;
		private int frameY;
		private float size = 0.4f;

		private const int NUMBER_OF_FRAMES = 24;
		private const float MAX_TIME = 0.5f;
		private const int NUM_FRAMES_X = 4;

		public ExplosionSystem(Vector2 position)
		{
			this.position = position;
		}

		public void Update(float elapsedTime)
		{
			this.timeElapsed += elapsedTime;
			float percentAnimated = timeElapsed / MAX_TIME;
			int frame = (int)(percentAnimated * NUMBER_OF_FRAMES);

			this.frameX = frame % NUM_FRAMES_X;
			this.frameY = frame / NUM_FRAMES_X;
		}

		public Vector2 Position { get { return this.position; } }
		public int FrameX { get { return this.frameX; } }
		public int FrameY { get { return this.frameY; } }
		public float Size { get { return this.size; } }

		public bool IsDone() {
			if (this.frameX * this.frameY > NUMBER_OF_FRAMES) {
				return true;
			}
			return false;
		}
	}
}

