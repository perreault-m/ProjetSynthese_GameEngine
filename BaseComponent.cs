using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{

    // The BaseComponent Class
    // Helds it's owner and it's type
    public class BaseComponent
    {

        protected static uint NEXT_COMPONENT_TYPE_ID_ = 0;

        protected static uint GetNextComponentTypeId()
        {
            return NEXT_COMPONENT_TYPE_ID_++;
        }

        // The id defines the component type 
        // Is defined by herited class with construciton
        public uint ID_ { get; set; }

        // Component's owner
        public Entity Owner_ { get; set; }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="id">Type of the component defined by inherited classes</param>
        /// <param name="e">Entity owner of the component</param>
        public BaseComponent(uint id, Entity e)
        {

            ID_ = id;
            Owner_ = e;

        }

    }
}


