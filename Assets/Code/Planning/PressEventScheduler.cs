using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.PressEvents;

namespace Assets.Code.Planning
{
    class PressEventScheduler:IPressEventScheduler
    {
        private List<IPressScenario> scenarios=new List<IPressScenario>();
        public void AddScenario(PressScenario scenario)
        {
            throw new NotImplementedException();
        }

        public PressEvent PeekNextEvent()
        {
            throw new NotImplementedException();
        }

        public PressEvent PopNextEvent()
        {
            throw new NotImplementedException();
        }
    }
}
