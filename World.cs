/*
*	 Author : Michael Perreault
*/

using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class World
    {
        /// Defines an invalid entity for debugging purpose
        public static Entity INVALID_ENTITY = new Entity(0, null);

        /// Entities in the world
        private List<Entity> Entities_;

        /// The world store , components are stored there
        public Store Store_ { get; }

        /// Next entity id to be created
        private uint NextEntityID_;

        /// List of the different systems added in the world
        private List<Engine> Systems_ = new List<Engine>();

        /// <summary>
        ///     Constructor
        /// </summary>
        public World()
        {
            Entities_ = new List<Entity>();
            Store_ = new Store();
            NextEntityID_ = 1;
        }

        /// <summary>
        ///     Creates a new entity
        /// </summary>
        /// <returns>
        ///     The new entity created
        /// </returns>
        public Entity NewEntity()
        {

            Entity new_entity = new Entity(NextEntityID_, Store_);
            NextEntityID_++;
            Entities_.Add(new_entity);

            return new_entity;
        }

        /// <summary>
        ///     Delete an entity and all of its components
        /// </summary>
        /// <param name="e">The Entity to delete</param>
        public void DeleteEntity(Entity e)
        {
            Store_.DeleteComponentsFor(e);
            Entities_.Remove(e);
        }

        /// <summary>
        ///     Add a system to the world
        /// </summary>
        /// <param name="s"></param>
        public void AddSystem(Engine s)
        {
            Systems_.Add(s);
        }

        /// <summary>
        ///     Update every system in the world
        /// </summary>
        public void Update(Time elapsed)
        {
            foreach(var sys in Systems_)
            {
                sys.Update(elapsed);
            }
        }
        
    }
}
