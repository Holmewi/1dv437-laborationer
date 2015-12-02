#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

#endregion

namespace FireAndExplosion.Model
{
	public class Textures
	{
		private Texture2D smokeTexture;
		private Texture2D fireTexture;
		private Texture2D splitterTexture;
		private Texture2D shockwaveTexture;

		public Textures(ContentManager content) 
		{
			this.smokeTexture = content.Load<Texture2D> ("smoke.png");
			this.fireTexture = content.Load<Texture2D> ("fire.png");
			this.splitterTexture = content.Load<Texture2D> ("splitter.png");
			this.shockwaveTexture = content.Load<Texture2D> ("shockwave.png");
		}

		public Texture2D SmokeTexture { get { return this.smokeTexture; } }
		public Texture2D FireTexture { get { return this.fireTexture; } }
		public Texture2D SplitterTexture { get { return this.splitterTexture; } }
		public Texture2D ShockwaveTexture { get { return this.shockwaveTexture; } }
	}
}

