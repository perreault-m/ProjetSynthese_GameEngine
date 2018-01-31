/*
*	Author : Michael Perreault
*/

using Core;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    
    public class Scene
    {
		
		/// Source and Sprit of the scene background
        public string BackgroundSrc_ { get; set; }
        public Sprite Background_ { get; set; }

		/// Keyboard and event mapping
        public Dictionary<Keyboard.Key, GameEvent> keyEvent_ = new Dictionary<Keyboard.Key, GameEvent>();

		/// <summary>
        ///     Bind a key to an event for this scene
        /// </summary>
        /// <param name="k">Keyboard key triggering the event</param>
		/// <param name="ev">The event associated to the key</param>
        public void Bind(Keyboard.Key k, GameEvent ev)
        {
            keyEvent_.Add(k, ev);
        }

		/// List of the entitiesin the scene
        public List<Entity> Entities_ { get; set; } = new List<Entity>();

    }
}
