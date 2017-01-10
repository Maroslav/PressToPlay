using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Gameplay
{
    public static class Constants
    {

        public const int DefaultChoicesCount = 2;

        //The scenario source files locations:
        public const string RandomEventsScenarioLoc = "Scenarios/random";
        public const string StoryEventsScenarioLoc = "Scenarios/story";
        public const string ConditionalScenarioLoc = "Scenarios/conditional";
        
        //Attributes definition source file:
        public const string AttributesDefinitionLoc = "Scenarios/attributes";
        //The expected number of days between two events:
        public const int RandomEventsMeanVal = 5;

        public const string ArticleImagesResourceFolder = "Images/Articles";

        public static DateTime StartDate = new DateTime(2019,1,1);
        public static DateTime EndDate = new DateTime(2030, 12, 31);

        public static Color DefaultSliderColor = new Color(204.0f/255.0f, 140.0f / 255.0f, 59.0f / 255.0f);
    }
}
