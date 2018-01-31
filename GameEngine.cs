using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using EventSystem;
using SFML.System;
using PhysicEngine;

namespace GameEngine
{
    public class GameEngine
    {
        protected Core.World World_;
        protected GraphicSystem.GraphicSystem GraphicSystem_;
        protected EventSystem.EventSystem EventSystem_;
        protected Factory Factory_;
        protected PhysicEngine.PhysicEngine PhysicSystem_;

        public GameEngine()
        {
            World_ = new Core.World();
            
            GraphicSystem_ = new GraphicSystem.GraphicSystem(World_.Store_);
            World_.AddSystem(GraphicSystem_);

            EventSystem_ = new EventSystem.EventSystem(GraphicSystem_ , World_.Store_);
            World_.AddSystem(EventSystem_);

            PhysicSystem_ = new PhysicEngine.PhysicEngine(EventSystem_, GraphicSystem_);
            World_.AddSystem(PhysicSystem_);

        }

        public virtual void Init()
        {
            Core.GameState gamestate = new Core.GameState(Core.World.INVALID_ENTITY);
            gamestate.IsRunning_ = true;

            World_.Store_.AddComponent<Core.GameState>(gamestate);
        }

        public void Run()
        {

            Core.Store s = World_.Store_;

            Core.GameState gamestate = s.GetComponent<Core.GameState>(Core.World.INVALID_ENTITY);

            GraphicSystem_.LoadScene();

            Clock clock = new Clock();

            while (gamestate.IsRunning_)
            {
                Time elapsed = clock.ElapsedTime;

                World_.Update(elapsed);

                clock.Restart();
                Thread.Sleep(10);
            }
            
        }
    }
}