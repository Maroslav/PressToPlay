using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.PressEvents;

namespace Assets.Code.Planning
{
    interface IPressEventScheduler:IPressScenario
    {
        
        void AddScenario(PressScenario scenario);
    }
}
