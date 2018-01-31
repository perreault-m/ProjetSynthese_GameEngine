/*
*	Author : Michael Perreault
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    ///
    ///  An entity define any game object in a game , it is represented by a unique id.
    ///  The entity is also used as a handle to the store to add and remove components easily
    /// 
    public class Entity
    {
        /// Unique id of the entity
        private uint id_;

        /// Store reference to add and remove components
        private Store Store_;

		/// This id represent the game object
        public uint ID_ { get { return id_; } set { } }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="id">The entity id</param>
        /// <param name="s">The store reference</param>
        public Entity(uint id, Store s)
        {
            id_ = id;
            Store_ = s;
        }

        /// <summary>
        ///     Add a component to the store
        /// </summary>
        /// <typeparam name="T">Type of the component</typeparam>
        /// <param name="c">The component</param>
        public void AddComponent<T>(T c) where T : BaseComponent, new(){
            Store_.AddComponent<T>(c);
        }

        /// <summary>
        ///     Get a component for this entity
        /// </summary>
        /// <typeparam name="T">Component type</typeparam>
        /// <returns>the component or null</returns>
        public T GetComponent<T>() where T : BaseComponent, new()
        {
            return Store_.GetComponent<T>(this);
        }

        /// <summary>
        ///     Delete a component for this entity
        /// </summary>
        /// <typeparam name="T">Component Type to delete</typeparam>
        public void DeleteComponent<T>() where T : BaseComponent, new()
        {
            Store_.DeleteComponent<T>(this);
        }
    }
}
