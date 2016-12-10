using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.GameState;
using Assets.Code.Planning;

namespace Assets.Code.Gameplay
{
    public static class GameInit
    {
        public static IPressEventScheduler CreateEventScheduler(WorldState worldState)
        {
            IPressScenario randomEventsScenario = new RandomEventsScenario(Constants.StartDate,Constants.RandomEventsScenarioLoc);
            IPressScenario storyScenario= new StoryEventsScenario(Constants.StoryEventsScenarioLoc);
            return new PressEventScheduler(worldState, Constants.StartDate,Constants.EndDate, storyScenario,randomEventsScenario);
        }
    }
}
