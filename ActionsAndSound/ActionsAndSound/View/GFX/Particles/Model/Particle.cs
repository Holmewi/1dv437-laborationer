#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

#endregion

namespace ActionsAndSound.View.GFX.Particles.Model
{
	public class Particle
	{
		private Texture2D texture;

		private Vector2 position;
		private Vector2 acceleration;
		private Vector2 velocity;
		private Vector2 gravity;

		private float speed = 0f;
		private float rotation = 0f;
		private float rotationSpeed = 0f;
		private float size = 1.0f;
		private float life = 1.0f;
		private float fade = 1.0f;
		private float timer = 0f;

		public Texture2D Texture { 
			get { return this.texture; } 
			set { this.texture = value; }
		}

		public Vector2 Position { 
			get { return this.position; } 
			set { this.position = value; }
		}

		public Vector2 Acceleration { 	
			get { return this.acceleration; }
			set { this.acceleration = value; }
		}

		public Vector2 Velocity { 	
			get { return this.velocity; }
			set { this.velocity = value; }
		}

		public Vector2 Gravity { 	
			get { return this.gravity; }
			set { this.gravity = value; }
		}

		public float Speed { 	
			get { return this.speed; }
			set { this.speed = value; }
		}

		public float Rotation { 	
			get { return this.rotation; }
			set { this.rotation = value; }
		}

		public float RotationSpeed { 	
			get { return this.rotationSpeed; }
			set { this.rotationSpeed = value; }
		}

		public float Size { 	
			get { return this.size; }
			set { this.size = value; }
		}

		public float Life { 	
			get { return this.life; }
			set { this.life = value; }
		}

		public float Fade { 	
			get { return this.fade; }
			set { this.fade = value; }
		}

		public float Timer { 	
			get { return this.timer; }
			set { this.timer = value; }
		}
	}
}

