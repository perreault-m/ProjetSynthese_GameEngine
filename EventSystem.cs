using Core;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSystem
{

    //Missing the extension of Core.System
    public class EventSystem : Core.Engine, ISubscriber
    {
        List<GameEvent> receiveEvents = new List<GameEvent>();

        RenderWindow Window_;

        GraphicSystem.GraphicSystem GraphicSystem_;

        Store Store_;

        List<Keyboard.Key> keyPressed_;

        private uint UpdateRate_ = 100 / 25;
        private uint Updatecounter_ = 0;

        public EventSystem(GraphicSystem.GraphicSystem g, Store s)
        {
            GraphicSystem_ = g;

            Window_ = g.Window_;

            Window_.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);
            Window_.KeyReleased += new EventHandler<KeyEventArgs>(OnKeyReleased);
            Window_.MouseButtonPressed += new EventHandler<MouseButtonEventArgs>(OnMouseEvent);

            Store_ = s;
            keyPressed_ = new List<Keyboard.Key>();
        }

        private void OnKeyReleased(object sender, KeyEventArgs e)
        {
            if (keyPressed_.Contains(e.Code))
            {
                keyPressed_.Remove(e.Code);
            }
        }

        private void OnKeyPressed(object sender, KeyEventArgs e)
        {
            if (!keyPressed_.Contains(e.Code))
            {
                keyPressed_.Add(e.Code);
            }

        }

        private void OnMouseEvent(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("DETECTED CLIC");
            foreach (var entity in GraphicSystem_.CurrentScene_.Entities_)
            {
                var clickable = entity.GetComponent<Clickable>();

                if (clickable != null)
                {

                    var owner = clickable.Owner_;

                    var size = owner.GetComponent<Components.Size>();
                    var pos = owner.GetComponent<Components.Position>();

                    if (size != null && pos != null)
                    {

                        if (
                            e.Y < pos.Y_
                            || e.X < pos.X_
                            || e.Y > pos.Y_ + size.Height_
                            || e.X > pos.X_ + size.Width_
                         )
                        {

                        }
                        else
                        {
                            Console.WriteLine("CLIC COLLISION");
                            Receive(clickable.ClickEvent_);
                        }
                    }
                }
            }

        }
        
        public void Update(Time elapsed)
        {
            Updatecounter_ += (uint)elapsed.AsMilliseconds();

            if(Updatecounter_ >= UpdateRate_)
            {
                Scene currentScene = GraphicSystem_.CurrentScene_;
                
                if(currentScene != null)
                {
                    // update cooldowns time
                    foreach(var action in currentScene.keyEvent_.Values)
                    {
                        action.LastCalled_ += Updatecounter_;
                    }

                    foreach (var key in keyPressed_)
                    {
                        if (currentScene.keyEvent_.Keys.Contains(key))
                        {
                            GameEvent ev;

                            currentScene.keyEvent_.TryGetValue(key, out ev);

                            if (ev != null)
                            {
                                if(ev.LastCalled_ / 1000 >= ev.Cooldown_ )
                                {
                                    Receive(ev);
                                    ev.LastCalled_ = 0;
                                }
                                    
                            }     
                        }
                    }
                }

                foreach (var temp in receiveEvents)
                {
                    temp.doAction();
                }

                receiveEvents.Clear();

                Updatecounter_ = 0;
            }

        }
        

        public void Receive(GameEvent gameEvent)
        {
            receiveEvents.Add(gameEvent);
        }
    }
}
