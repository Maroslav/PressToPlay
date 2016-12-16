using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.Gameplay
{
    public static class Constants
    {

        public const int DefaultChoicesCount = 2;

        //The scenario source files locations:
        public const string RandomEventsScenarioLoc = "Scenarios/random";
        public const string StoryEventsScenarioLoc = "Scenarios/story";
        
        //Attributes definition source file:
        public const string AttributesDefinitionLoc = "Scenarios/attributes";
        //The expected number of days between two events:
        public const int RandomEventsMeanVal = 5;
        
        public static DateTime StartDate = new DateTime(2017,3,24);
        public static DateTime EndDate = new DateTime(2017, 12, 31);
    }
}
