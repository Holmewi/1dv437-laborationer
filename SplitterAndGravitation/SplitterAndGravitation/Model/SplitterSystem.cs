#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

#endregion

namespace SplitterAndGravitation.Model
{
	public class SplitterSystem
	{
		Texture2D spark;

		private Model.SplitterParticle[] splitter = new SplitterParticle[100];
		private View.Camera camera;

		public SplitterSystem(ContentManager content, GraphicsDevice device) 
		{
			spark = content.Load<Texture2D> ("spark.png");

			this.camera = new View.Camera (device);
		}

		public void Start() 
		{
			for (int i = 0; i < this.splitter.Length; i++) 
			{	
				Random random = new Random(i);
				this.splitter[i] = new SplitterParticle (random);
			}
		}

		public void Draw(SpriteBatch spriteBatch) 
		{
			for (int i = 0; i < this.splitter.Length; i++) 
			{	
				this.splitter[i].Draw (this.camera, spark, spriteBatch);
			}
		}

		public void Update(float elapsedTime)
		{
			for (int i = 0; i < this.splitter.Length; i++) 
			{	
				this.splitter[i].Update (elapsedTime);
			}
		}
	}
}

