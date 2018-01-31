/*
*	Author : Yohann Pruneau
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class BaseComponent
    {
		// Component Type generation for new components identification
        protected static uint NEXT_COMPONENT_TYPE_ID_ = 0;

		/// <summary>
        ///     Static function to generate a new component type id
        /// </summary>
		/// <return>
		///		The next component id to be used by the api to store components
		/// </return>
        protected static uint GetNextComponentTypeId()
        {
            return NEXT_COMPONENT_TYPE_ID_++;
        }

        // The id defines the component type 
        public uint ID_ { get; set; }

        // Component's owner
        public Entity Owner_ { get; set; }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="id">Type of the component/param>
        /// <param name="e">Entity owning this component</param>
        public BaseComponent(uint id, Entity e)
        {

            ID_ = id;
            Owner_ = e;

        }

    }
}


