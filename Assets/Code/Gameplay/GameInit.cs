using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Assets.Code.GameState;
using Assets.Code.Model;
using Assets.Code.Model.Attribs;
using Assets.Code.Planning;
using UnityEngine.Assertions;

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

        public static WorldState CreateWorldState()
        {
            AttributesDefinition attribsDef = XmlUtils.LoadAttributes(Constants.AttributesDefinitionLoc);
            Dictionary<AttribsCategory, Attribs> stateVariables = new Dictionary<AttribsCategory, Attribs>();

            Dictionary<string, Attrib> attribsByName = new Dictionary<string, Attrib>();
            
            foreach (var categoryDao in attribsDef.Categories)
            {
                var category = new AttribsCategory(categoryDao.Name, categoryDao.Description);
                var attribsSet = new Attribs();
                stateVariables.Add(category,attribsSet);
                foreach (var attribDao in categoryDao.Attributes)
                {
                    Attrib attrib = new Attrib(attribDao.Description)
                    {
                        IsDisplayed = attribDao.IsDisplayed,
                        Category = category
                    };
                    attribsByName.Add(attribDao.Name,attrib);
                    attribsSet[attrib]=attribDao.InitialValue;
                }   
            }
            WorldState state = new WorldState {AllStates = stateVariables};
            Attribs.SetAttribsCollection(attribsByName);
            PutCategoriesIntoVariables(stateVariables, state);

            return state;
        }
        // Makes important categories accessible directly through a property in the WorldState.
        private static void PutCategoriesIntoVariables(Dictionary<AttribsCategory, Attribs> stateVariables, WorldState state)
        {
            AttribsCategory journalist = (from x in stateVariables.Keys where x.Name == "Journalist" select x).First();
            Debug.Assert(journalist != null, "The list of attributes does not contain the Journalist category.");
            state.JournalistState = stateVariables[journalist];
        }
    }
}