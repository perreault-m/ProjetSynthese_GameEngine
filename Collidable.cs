/*
*	Author : Yohann Pruneau
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Core
{
    public class Collidable : BaseComponent
    {
        public class TypeOfCollision
        {
            public static int up = 1;
            public static int left = 2;
            public static int right = -2;
            public static int down = -1;
            public static int none = 0;
            public static int collided = 3;
        }

		// Collidable component type
        static public uint TYPE = BaseComponent.GetNextComponentTypeId();
		
		// Event Associated to the collision
        public Core.GameEvent gameEvnt { get; set; }

		// Type of the collision
        public int CollisionType_ { get; set; }
		
		/// <summary>
        ///     Constructor ( No event ). User have to associate an event after construction
        /// </summary>
        /// <param name="e">Entity owning this component</param>
        public Collidable(Entity e) : base(TYPE, e)
        {
        }

		/// <summary>
        ///     Constructor with event association
        /// </summary>
        /// <param name="e">Entity owning this component</param>
        public Collidable(Core.GameEvent gameEvent, Entity e) : base(TYPE, e)
        {
            gameEvnt = gameEvent;
        }

		/// <summary>
        ///     Empty constructor
        /// </summary>
        /// <param name="e">Entity owning this component</param>
        public Collidable() : base(TYPE, World.INVALID_ENTITY)
        {
        }

		// Size of the collidable zone
        public uint Width_ { get; set; }
        public uint Height_ { get; set; }
		
		// Tells with which entity a collision occured
        public Entity CollidedWith_ { get; set; } = null;
		
		// Type of a collision
        public int CollisionType { get; set; } = TypeOfCollision.none;
		
		// Distance of the movement that produced the collision.
        public int Dist_X_ { get; set; }
        public int Dist_Y_ { get; set; }
		
		// Relative distance of the collidable zone from the owner real position.
        public uint Relative_X_ { get; set; } = 0;
        public uint Relative_Y_ { get; set; } = 0;
    }
}
