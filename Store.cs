using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    /**
     *  Store class is used to store any components
     */
    public class Store
    {

        // Generic Box to store any class derived from BaseComponent
        public class Box<T>
        {
            public Dictionary<Entity, T> Components_ = new Dictionary<Entity, T>();
        }

        // This dictionnary contains the boxes , therefor every components are stored here
        private Dictionary<uint, Box<BaseComponent>> Boxes_ = new Dictionary<uint, Box<BaseComponent>>();


        /// <summary>
        ///     Add a components in the store
        /// </summary>
        /// <typeparam name="T">Component Type</typeparam>
        /// <param name="c">The component</param>
        public void AddComponent<T>(T c) where T : BaseComponent , new() {

            Box<BaseComponent> box = GetBox<T>();

            // means there's no box for this type of component
            if(box == null)
            {
                // Creating a box for the type of component the user wants to store
                box = new Box<BaseComponent>();
                Boxes_.Add(c.ID_, box);
            }

            // Adding the component to the box
            box.Components_.Add(c.Owner_, c);

        }

        /// <summary>
        ///     Delete a component from the store
        /// </summary>
        /// <typeparam name="T">Component Type</typeparam>
        /// <param name="c">the component</param>
        public void DeleteComponent<T>(Entity owner) where T : BaseComponent, new()
        {
            Box<BaseComponent> box = GetBox<T>();

            // means there's no box for this type of component
            if (box != null )
            {
                box.Components_.Remove(owner);
            }
        }

        /// <summary>
        ///     Delete every component for an entity
        /// </summary>
        /// <param name="e">The entity to delete</param>
        public void DeleteComponentsFor(Entity e)
        {
            foreach(var box in Boxes_)
            {
                box.Value.Components_.Remove(e);
            }
        }

        /// <summary>
        ///     Returns a component for a specified entity
        /// </summary>
        /// <typeparam name="T">Type of the component</typeparam>
        /// <param name="owner">The entity</param>
        /// <returns>The component or null if the entity doesn't have the specified component </returns>
        public T GetComponent<T>(Entity owner) where T : BaseComponent , new()
        {
            // To access the right type of box we need to know which id is in 'T'
            T x = new T();

            Box<BaseComponent> box;

            // Getting the box
            Boxes_.TryGetValue(x.ID_, out box);

            // means there's no box for the asked component , so we return null
            if (box == null)
            {
                return null;
            }

            // From here the box for the specified component exists

            BaseComponent component;

            // Getting the component from the box 
            box.Components_.TryGetValue(owner, out component);

            // Returns the component casted to the concrete type or null if the component doesn't exist
            return component == null ? null : (T)component;
        }

        /// <summary>
        ///     Returns the box for a specified component
        /// </summary>
        /// <typeparam name="T">Type of the Box</typeparam>
        /// <returns>The box or null</returns>
        public Box<BaseComponent> GetBox<T>() where T : BaseComponent, new()
        {
            T x = new T();

            Box<BaseComponent> box;

            Boxes_.TryGetValue(x.ID_, out box);

            return box;
        }
    }
}
