using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.Planning;

namespace Assets.Code.Gameplay
{
    public static class GameInit
    {
        public static IPressEventScheduler CreateEventScheduler()
        {
            IPressScenario randomEventsScenario = new RandomEventsScenario(Constants.StartDate,Constants.RandomEventsScenarioLoc);

            return new PressEventScheduler(Constants.StartDate,Constants.EndDate,randomEventsScenario);
        }
    }
}
