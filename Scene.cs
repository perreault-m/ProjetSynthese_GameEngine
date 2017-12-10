using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicSystem
{
    /*
     *  Scene class is used to separate different render scene in a game
     *  exemple : The menu is a scene , a playable level is a scene , opening full-screen ui ( like inventory ) is a scene
     *  it holds the entity belonging to the scene
     */ 
    public class Scene
    {
        public List<Entity> Entities_ { get; set; } = new List<Entity>();

    }
}
