#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion

namespace ActionsAndSound.Model
{
	class Ball
	{
		private float radius = 0.05f;
		private float speed;

		private Vector2 position;
		private Vector2 velocity;

		public Vector2 collision;
		public bool CollisionOn = true;
		private double mass;

		public Ball(Random random, Vector2 position, float radius) 
		{
			this.radius = radius;
			this.speed = (float)random.NextDouble () * (0.6f - 0.3f) + 0.3f;

			this.position = position;

			this.velocity = new Vector2((float)random.NextDouble () - 0.5f, (float)random.NextDouble () - 0.5f);
			this.velocity.Normalize ();
			this.velocity = this.velocity * ((float)random.NextDouble() * (this.speed - 0.1f) + 0.1f);

			this.mass = Math.Round(Math.Pow((this.radius / 250),2), 10);
		}

		public float Radius { 
			get { return this.radius; }
			set { this.radius = value; }
		}

		public float Speed {
			get { return this.speed; }
			set { this.speed = value; }
		}

		public double Mass { 
			get { return this.mass; }
			set { this.mass = value; }
		}

		public Vector2 Position { 
			get { return this.position; } 
			set { this.position = value; }
		}

		public float PositionX { 
			set { this.position.X = value; }
		}

		public float PositionY { 
			set { this.position.Y = value; }
		}

		public Vector2 Velocity { 
			get { return this.velocity; } 
			set { this.velocity = value; }
		}

		public float VelocityX { 
			set { this.velocity.X = value; }
		}

		public float VelocityY { 
			set { this.velocity.Y = value; }
		}

		public Vector2 Collision { 
			get { return this.collision; }
			set { this.collision = value; }
		}

		public float CollisionX { 
			set { this.collision.X = value; }
		}

		public float CollisionY { 
			set { this.collision.Y = value; }
		}
	}
}

