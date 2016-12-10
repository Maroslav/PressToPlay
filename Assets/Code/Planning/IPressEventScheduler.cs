using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.PressEvents;

namespace Assets.Code.Planning
{
    public interface IPressEventScheduler
    {
        
        void AddScenario(PressScenario scenario);
        //Gets the next event and removes it from the queue.
        PressEvent PopNextEvent();
    }
}
