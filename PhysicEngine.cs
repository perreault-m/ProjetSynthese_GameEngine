using Core;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicSystem;
using EventSystem;
using SFML.System;
using static Core.Components;
using static Core.Collidable;

namespace PhysicEngine
{
    public class PhysicEngine :  Engine
    {
        public uint UpdateRate_ { get; set; } = 1000 / 10;
        public uint Updatecounter_ { get; set; } = 0;

        private GraphicSystem.GraphicSystem GraphicSystem_;

        private MathCollision mathCollision = new MathCollision();

        private EventSystem.EventSystem EventSystem_;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="s">The game store</param>
        public PhysicEngine(EventSystem.EventSystem eventSys, GraphicSystem.GraphicSystem gs)
        {
            EventSystem_ = eventSys;
            GraphicSystem_ = gs;
        }


        private Dictionary<TypeOfCollision, GameEvent> CollisionMapper = new Dictionary<TypeOfCollision, GameEvent>();

        
        /// <summary>
        ///     Updates the graphic engine. Render the CurrentScene_
        /// </summary>
        public void Update(Time elapsed)
        {
            Updatecounter_ += (uint)elapsed.AsMilliseconds();

            if (Updatecounter_ >= UpdateRate_)
            {

                foreach (Entity e in GraphicSystem_.CurrentScene_.Entities_)
                {
                    // Get's the velocity ( no need to test collision if entities are not moving )
                    var velocity = e.GetComponent<Velocity>();

                    if (velocity != null)
                    {
                        
                        // Get it's physic collidable Components
                        var collidable = e.GetComponent<Collidable>();

                        var collision = TypeOfCollision.none;


                        var moving_position = e.GetComponent<Position>();
                        moving_position.X_ += (int)(Updatecounter_ * velocity.X_) / 1000;
                        moving_position.Y_ += (int)(Updatecounter_ * velocity.Y_) / 1000;

                        // Means the entity has a Collidable component
                        if (collidable != null)
                        {

                            foreach (Entity other in GraphicSystem_.CurrentScene_.Entities_)
                            {
   

                                if (e != other)
                                {
                                    var p2 = other.GetComponent<Collidable>();

                                    if (p2 != null)
                                    {
                                        collision = mathCollision.checkCollisionWithExtrapolation(e, other);
                                        
                                        if (collision != TypeOfCollision.none)
                                        {
                                            collidable.CollisionType_ = collision;
                                            collidable.CollidedWith_ = other;
                                            collidable.Dist_X_ = (int)(Updatecounter_ * velocity.X_) / 1000;
                                            collidable.Dist_Y_ = (int)(Updatecounter_ * velocity.Y_) / 1000;

                                            collidable.gameEvnt.doAction();
                                        
                                            p2.CollisionType_ = collision * -1; // if one collides left ,the other collides right
                                            p2.CollidedWith_ = e;

                                            p2.gameEvnt.doAction();

                                        }
                                    }
                                }
                            }
                        }
                    }
                    
                }

                Updatecounter_ = 0;
            }

        }

    }
}
