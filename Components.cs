/*
*	Authors : Yohann Pruneau , Michael Perreault
*/

using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Components
    {

        /*
         *      GRAPHIC COMPONENT
         * */
        public class Graphic : BaseComponent
        {
			/// Component's type
            static public uint TYPE = BaseComponent.GetNextComponentTypeId();

			/// Source of the image. 
            public String Src_ { get; set; }

			/// Drawable : The sprite defines the position , size , texture and transformation
            public Sprite Sprite_ { get; set; }

			/// Texture of the sprite , it's the image to be draw
            public Texture Texture_ { get; set; }

			/// <summary>
			///     Constructor
			/// </summary>
			/// <param name="e">Entity owning this component</param>
			/// <param name="src">Source of the image to be draw by the graphic system</param>
            public Graphic(Entity e, string src) : base(TYPE, e)
            {
                Src_ = src;
                
            }

			/// <summary>
			///     Empty constructor
			/// </summary>
            public Graphic() : base(TYPE, World.INVALID_ENTITY)
            {

            }
        }

        /*
         *      POSITION COMPONENT
         * */
        public class Position : BaseComponent
        {
			
			/// Component's type
            static public uint TYPE = BaseComponent.GetNextComponentTypeId();

			/// <summary>
			///     Constructor
			/// </summary>
			/// <param name="e">Entity owning this component</param>
            public Position(Entity e) : base(TYPE, e)
            {
            }

			/// <summary>
			///     Empty constructor
			/// </summary>
            public Position() : base(TYPE, World.INVALID_ENTITY)
            {

            }

			/// X and Y position in a 2d plan
            public int X_ { get; set; }
            public int Y_ { get; set; }
        }

        /*
         *      TEXT COMPONENT
         * */
        public class Text : BaseComponent
        {
			
			/// Component's type
            static public uint TYPE = BaseComponent.GetNextComponentTypeId();

			/// <summary>
			///     Constructor
			/// </summary>
			/// <param name="e">Entity owning this component</param>
			/// <param name="text">String to be draw by the graphic system</param>
			/// <param name="font">Font name. exemple : "arial". You can use a personnal font using a url to a .tff or .otf file</param>
            public Text(Entity e, string text, string font) : base(TYPE, e)
            {
                Text_ = new SFML.Graphics.Text(text,  new SFML.Graphics.Font(font));

            }

			/// <summary>
			///     Empty constructor
			/// </summary>
            public Text() : base(TYPE, World.INVALID_ENTITY)
            {

            }

			/// SFML text class. Can be rendered by the sfml RenderWindow
            public SFML.Graphics.Text Text_;

			/// Relative X and Y position from the owner's real position
            public uint Relative_X_ = 0;
            public uint Relative_Y_ = 0;
			
        }

        /*
         *      SIZE COMPONENT
         * */
        public class Size : BaseComponent
        {
			
			/// Component's type
            static public uint TYPE = BaseComponent.GetNextComponentTypeId();

			/// <summary>
			///     Constructor
			/// </summary>
			/// <param name="e">Entity owning this component</param>
            public Size(Entity e) : base(TYPE, e)
            {
            }

			/// <summary>
			///     Empty constructor
			/// </summary>
            public Size() : base(TYPE, World.INVALID_ENTITY)
            {
            }

            public uint Width_ { get; set; }
            public uint Height_ { get; set; }
        }

        /*
         *      VELOCITY COMPONENT
         * */
        public class Velocity : BaseComponent
        {
			
			/// Component's type
            static public uint TYPE = BaseComponent.GetNextComponentTypeId();

			/// <summary>
			///     Constructor
			/// </summary>
			/// <param name="e">Entity owning this component</param>
            public Velocity(Entity e) : base(TYPE, e)
            {
            }

			/// <summary>
			///     Empty constructor
			/// </summary>
            public Velocity() : base(TYPE, World.INVALID_ENTITY)
            {
            }

			/// Horizontal and vertical velocity in pixel per seconds
            public int X_ { get; set; } // X translation in pixels per seconds
            public int Y_ { get; set; } // Y translation in pixels per seconds
        }

    }
}
