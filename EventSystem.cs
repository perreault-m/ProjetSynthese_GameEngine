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
    public class EventSystem : Core.Engine , ISubscriber
    {
        List<GameEvent> receiveEvents = new List<GameEvent>();

        RenderWindow Window_;

        Dictionary<Keyboard.Key, GameEvent> keyEvent_ = new Dictionary<Keyboard.Key, GameEvent>();

        Store Store_;

        List<Keyboard.Key> keyPressed_;

        private uint UpdateRate_ = 100 / 25;
        private uint Updatecounter_ = 0;

        public void Bind(Keyboard.Key k, GameEvent ev)
        {
            keyEvent_.Add(k, ev);
        }
        
        public EventSystem(RenderWindow w, Store s)
        {
            Window_ = w;

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
            var clickables = Store_.GetBox<Clickable>();

            if(clickables != null)
            {
                foreach(var clickable in clickables.Components_)
                {
                    var clickable_comp = (Clickable)clickable.Value;

                    var owner = clickable_comp.Owner_;

                    var size = owner.GetComponent<Components.Size>();
                    var pos = owner.GetComponent<Components.Position>();

                    if(size != null && pos != null)
                    {
                        
                        if(
                            e.Y < pos.Y_ 
                            || e.X < pos.X_
                            || e.Y > pos.Y_ + size.Height_
                            || e.X > pos.X_ + size.Width_
                         )
                        {

                        }
                        else
                        {
                            Receive(clickable_comp.ClickEvent_);
                        }
                    }
                }
            }
        }

        public void Receive(GameEvent gameEvent)
        {
            receiveEvents.Add(gameEvent);
        }

        public void Update(Time elapsed)
        {
            Updatecounter_ += (uint)elapsed.AsMilliseconds();

            if(Updatecounter_ >= UpdateRate_)
            {
                foreach (var key in keyPressed_)
                {
                    if (keyEvent_.ContainsKey(key))
                    {
                        GameEvent ev;

                        keyEvent_.TryGetValue(key, out ev);

                        if (ev != null)
                            Receive(ev);
                    }
                }

                foreach (var temp in receiveEvents)
                {
                    Console.WriteLine("EXECUTING ACTION");
                    temp.doAction();
                }

                receiveEvents.Clear();

                Updatecounter_ = 0;
            }

        }
    }
}
