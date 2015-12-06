#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

#endregion

namespace ActionsAndSound.View
{
	public class PointerView
	{
		private Camera camera;
		private Texture2D pointer;

		private Vector2 mousePos;
		private const float POINTER_SIZE = 0.3f;

		public PointerView(ContentManager content, Camera camera)
		{
			this.pointer = content.Load<Texture2D>("Texture/pointer.png");
			this.camera = camera;
		}

		public void Update(Vector2 mousePos)
		{
			this.mousePos = mousePos;
		}

		public void Draw(SpriteBatch spriteBatch) 
		{
			int pointerTextureWidth = this.pointer.Bounds.Width;
			int pointerTextureHeight = this.pointer.Bounds.Height;

			Vector2 ballTextureDisplacement = new Vector2 ((float)pointerTextureWidth / 2, (float)pointerTextureHeight / 2);
			//float scale = this.camera.GetVisualScale (POINTER_SIZE, pointerTextureWidth, pointerTextureHeight);
			float scale = 0.5f;

			Console.WriteLine (this.mousePos.X + ", " + this.mousePos.Y);
			if (this.mousePos != null) {
				spriteBatch.Draw(this.pointer, this.mousePos - ballTextureDisplacement * scale, null, 
					Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
			}
		}
			
	}
}

