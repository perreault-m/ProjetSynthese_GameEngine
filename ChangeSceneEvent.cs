using Core;
using EventSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class ChangeSceneEvent : GameEvent
    {
        public ChangeSceneEvent(Core.Action theaction) : base(theaction,1)
        {
        }
    }
}
