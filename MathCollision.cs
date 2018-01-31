using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Collidable;
using static Core.Components;

namespace PhysicEngine
{

    public class Point
    {
        public Point(float x , float y)
            {

            }
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class RectDataHolder
    {
        public RectDataHolder(Core.Entity e)
        {
            var ePos = e.GetComponent<Core.Components.Position>();
         
            var e1Size = e.GetComponent<Collidable>();
       
            Left = ePos.X_ + e1Size.Relative_X_;
            Right = ePos.X_ + e1Size.Width_ + e1Size.Relative_Y_;
            Top = ePos.Y_ + e1Size.Relative_Y_;
            Down = ePos.Y_ + e1Size.Height_+  e1Size.Relative_X_;
        }
        public float Down { get; set; }
        public float Top { get; set; }
        public float Right { get; set; }
        public float Left { get; set; }
    }

    public class MathCollision
    {
        public int checkCollisionWithExtrapolation(Core.Entity e1 , Core.Entity e2) {

            var collision = TypeOfCollision.none;

            RectDataHolder EntityBounds = new RectDataHolder(e1);
            RectDataHolder OtherBounds = new RectDataHolder(e2);

            float entity_bottom = EntityBounds.Down;
            float other_bottom = OtherBounds.Down;
            float entity_right = EntityBounds.Right;
            float other_right = OtherBounds.Right;

            float b_collision = other_bottom - EntityBounds.Top;
            float t_collision = entity_bottom - OtherBounds.Top;
            float l_collision = entity_right - OtherBounds.Left;
            float r_collision = other_right - EntityBounds.Left;

            if(     EntityBounds.Right < OtherBounds.Left // too much on left side
                ||  EntityBounds.Left > OtherBounds.Right // too much on right side
                ||  EntityBounds.Down < OtherBounds.Top // too much over
                ||  EntityBounds.Top > OtherBounds.Down // too much under
                )
            {
                return TypeOfCollision.none;
            }
            else
            {
                if (t_collision < b_collision && t_collision < l_collision && t_collision < r_collision)
                {
                    return TypeOfCollision.down;
                }
                if (b_collision < t_collision && b_collision < l_collision && b_collision < r_collision)
                {
                    return TypeOfCollision.up;
                    
                }
                if (l_collision < r_collision && l_collision < t_collision && l_collision < b_collision)
                {
                    return TypeOfCollision.right;
                }
                if (r_collision < l_collision && r_collision < t_collision && r_collision < b_collision)
                {
                    return TypeOfCollision.left;
                    
                }

                return TypeOfCollision.none;
            }
        }
    }
}
