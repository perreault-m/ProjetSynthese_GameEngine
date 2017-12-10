using Core;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicSystem
{
    public class GraphicSystem : Core.Engine
    {

        // The application Window
        public RenderWindow Window_ { get; set; }

        public uint UpdateRate_ { get; set; } = 1000 / 60;
        public uint Updatecounter_ { get; set; } = 0;

        // Reference to the store to work on components
        private Store Store_;

        // CurrentScene to render
        public Scene CurrentScene_;

        /// <summary>
        ///     Action to be done when OnClose event is sent by the window
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        void OnClosed(object sender, EventArgs e)
        {
            GameState state = Store_.GetComponent<Core.GameState>(World.INVALID_ENTITY);
            state.IsRunning_ = false;
            Window_.Close();
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="s">The game store</param>
        public GraphicSystem(Store s)
        {

            // Creating the window
            Window_ = new RenderWindow(new VideoMode(800, 600), "SFML window test");
            Window_.SetActive();

            // Handling the close event
            Window_.Closed += new EventHandler(OnClosed);

            Store_ = s;

        }

        /// <summary>
        ///     Change the current scene to be rendered
        /// </summary>
        /// <param name="s"></param>
        public void SetScene(Scene s)
        {
            CurrentScene_ = s;
        }
        
        /// <summary>
        ///     Load the Graphic component of the entities in the CurrentScene_
        /// </summary>
        public void LoadScene()
        {

            // Loop on each entities in the scene
            foreach(Entity e in CurrentScene_.Entities_)
            {
                // Get it's graphic component
                var g = e.GetComponent<Core.Components.Graphic>();

                // means the entity has a graphic component
                if(g != null)
                {

                    var g_comp = (Core.Components.Graphic)g;

                    // Initialisation of the sprite and texture
                    g_comp.Texture_ = new Texture(g_comp.Src_);
                    g_comp.Sprite_ = new Sprite(g_comp.Texture_);
                }
            }
        }

        /// <summary>
        ///     Unload ( set to null ) the graphic components for the CurrentScene_
        /// </summary>
        public void UnloadScene()
        {

            // Loop on each entity in the scene
            foreach (Entity e in CurrentScene_.Entities_)
            {
                // Get it's graphic component
                var g = e.GetComponent<Core.Components.Graphic>();

                // means the entity has a graphic component
                if (g != null)
                {
                    var g_comp = (Core.Components.Graphic)g;

                    // Set's the texture and sprite to null
                    g_comp.Texture_ = null;
                    g_comp.Sprite_ = null;
                }
            }
        }

        /// <summary>
        ///     Updates the graphic engine. Render the CurrentScene_
        /// </summary>
        public void Update(Time elapsed)
        {

            Updatecounter_ += (uint)elapsed.AsMilliseconds();

            if(Updatecounter_ >= UpdateRate_)
            {
                // Clear the screen
                Window_.Clear();

                // Send the event to handlers
                Window_.DispatchEvents();

                // Draw the Graphic components
                DrawSprites();

                // Draw texts
                DrawTexts();

                // Display the screen
                Window_.Display();

                Updatecounter_ = 0;
            }

        }

        private void DrawSprites()
        {
            // Loop on each Entity in the world
            foreach (Entity e in CurrentScene_.Entities_)
            {


                var g = e.GetComponent<Core.Components.Graphic>();

                // Means the entity has a graphic component
                if (g != null)
                {
                    var g_comp = (Core.Components.Graphic)g;

                    var pos = e.GetComponent<Components.Position>();

                    if (pos != null)
                    {
                        var sprite_pos = g_comp.Sprite_.Position;

                        sprite_pos.X = pos.X_;
                        sprite_pos.Y = pos.Y_;

                        g_comp.Sprite_.Position = sprite_pos;

                        // Draw the component
                        Window_.Draw(g_comp.Sprite_);
                    }

                }


            }
        }


        private void DrawTexts()
        {
            // Loop on each Entity in the world
            foreach (Entity e in CurrentScene_.Entities_)
            {

                var t = e.GetComponent<Core.Components.Text>();

                // Means the entity has a text component
                if (t != null)
                {

                    var pos = e.GetComponent<Components.Position>();

                    if (pos != null)
                    {
                        var text_pos = t.Text_.Position;

                        text_pos.X = pos.X_ + t.Relative_X_;
                        text_pos.Y = pos.Y_ + t.Relative_Y_;

                        t.Text_.Position = text_pos;

                        // Draw the component
                        Window_.Draw(t.Text_);
                    }

                }


            }
        }

    }

    
}
