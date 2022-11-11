using System;
using System.Collections.Generic;
using System.Linq;
using GameEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace GameEngine
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D snow, background;
      
        private int pause =0;
      
        public List<Snow> obj = new List<Snow>();
       
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.IsFullScreen = false;
            Add();
            graphics.ApplyChanges();
            IsMouseVisible = true;
        }

        protected void Add()
        {
            var rnd = new Random();
            for (int i = 0; i < 1000; i++)
            {
                obj.Add(new Snow
                {
                    X = rnd.Next(graphics.PreferredBackBufferWidth),
                    Y = -rnd.Next(graphics.PreferredBackBufferHeight),
                    Size = rnd.Next(15,40)
                });
            }
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = TextureLoader.Load("back", Content);
            snow = TextureLoader.Load("snow", Content);
        }
        protected override void Update(GameTime gameTime)
        {
            Input.Update();
            StopAndStart();    
        }
        protected override void Draw(GameTime gameTime)
        {
            if (pause == 0)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(background,
                    new Rectangle(0, 0,
                    graphics.PreferredBackBufferWidth,
                    graphics.PreferredBackBufferHeight),
                    Color.White);
                foreach (var snowflake in obj)
                {
                    snowflake.Y += snowflake.Size / 5;
                    snowflake.X += snowflake.Size/8;
                    if (snowflake.Y > graphics.PreferredBackBufferHeight)
                    {
                        snowflake.Y = -snowflake.Size;
                    }
                    if (snowflake.X > graphics.PreferredBackBufferWidth)
                    {
                        snowflake.X = -snowflake.Size;
                    }
                }
                foreach (var snowflake in obj)
                {
                    spriteBatch.Draw(snow, 
                        new Rectangle(snowflake.X,
                                      snowflake.Y,  
                                      snowflake.Size,
                                      snowflake.Size), Color.White);
                }
                spriteBatch.End();
            }           
        }
        private void StopAndStart()
        {
            if (Input.KeyPressed(Keys.Space))
            {     
                if (pause == 0)
                {
                    pause = 1;
                    
                }else if(pause == 1)
                {
                    pause = 0;
                    
                }
            }
        }
    }
}
