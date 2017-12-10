using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSystem
{
    public class ClickEvent : GameEvent
    {
        public ClickEvent(Action theaction) : base(theaction)
        {
        }
    }

    public class Clickable : BaseComponent
    {

        static public uint TYPE = BaseComponent.GetNextComponentTypeId();

        public GameEvent ClickEvent_ { get; set; }

        public Clickable(Entity e, GameEvent click_event) : base(TYPE, e)
        {
            ClickEvent_ = click_event;
        }

        public Clickable() : base(TYPE , World.INVALID_ENTITY)
        {

        }
    }
}
