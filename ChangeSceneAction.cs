using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class ChangeSceneAction : Core.Action
    {
        GraphicSystem.GraphicSystem GraphicSystem_;
        Scene Scene_;

        public ChangeSceneAction(GraphicSystem.GraphicSystem g, Scene new_scene)
        {
            GraphicSystem_ = g;
            Scene_ = new_scene;
        }

        public void doAction()
        {
            GraphicSystem_.UnloadScene();
            GraphicSystem_.SetScene(Scene_);
            GraphicSystem_.LoadScene();
        }
    }
}

