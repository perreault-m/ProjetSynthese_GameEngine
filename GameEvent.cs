using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EventSystem
{



   public class GameEvent {
       
      
        protected Action action;

        public GameEvent(Action theaction)
        {

            action = theaction;
        }
     
        public void doAction()
        {

            action.doAction();
        }

    
    }


 


}
