/*
*	Author : Yohann Pruneau
*/

using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    
    public interface Engine
    {
		/// <summary>
		///    Interface for systems
		/// </summary>
		/// <param name="elapsed">Elapsed time since the last time this function was called</param>
        void Update(Time elapsed);
    }
}
