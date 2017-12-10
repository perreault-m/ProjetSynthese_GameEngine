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
            static public uint TYPE = BaseComponent.GetNextComponentTypeId();

            public String Src_ { get; set; }

            public Sprite Sprite_ { get; set; }

            public Texture Texture_ { get; set; }

            public Graphic(Entity e, string src) : base(TYPE, e)
            {
                Src_ = src;
                
            }

            public Graphic() : base(TYPE, World.INVALID_ENTITY)
            {

            }
        }

        /*
         *      POSITION COMPONENT
         * */
        public class Position : BaseComponent
        {
            static public uint TYPE = BaseComponent.GetNextComponentTypeId();

            public Position(Entity e) : base(TYPE, e)
            {
            }

            public Position() : base(TYPE, World.INVALID_ENTITY)
            {

            }

            public int X_ { get; set; }
            public int Y_ { get; set; }
        }

        /*
         *      TEXT COMPONENT
         * */
        public class Text : BaseComponent
        {
            static public uint TYPE = BaseComponent.GetNextComponentTypeId();

            public Text(Entity e, string text, string font) : base(TYPE, e)
            {
                Text_ = new SFML.Graphics.Text(text,  new SFML.Graphics.Font(font));

            }

            public Text() : base(TYPE, World.INVALID_ENTITY)
            {

            }

            public SFML.Graphics.Text Text_;

            public uint Relative_X_ = 0;
            public uint Relative_Y_ = 0;
        }

        /*
         *      SIZE COMPONENT
         * */
        public class Size : BaseComponent
        {
            static public uint TYPE = BaseComponent.GetNextComponentTypeId();

            public Size(Entity e) : base(TYPE, e)
            {
            }

            public Size() : base(TYPE, World.INVALID_ENTITY)
            {
            }

            public uint Width_ { get; set; }
            public uint Height_ { get; set; }
    }

    }
}
