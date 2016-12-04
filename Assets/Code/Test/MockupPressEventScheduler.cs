using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.GameState;
using Assets.Code.Model;
using Assets.Code.Planning;
using Assets.Code.PressEvents;

namespace Assets.Code.Test
{
    public class MockupPressEventScheduler : IPressEventScheduler
    {

        public PressEvent PeekNextEvent()
        {
            if (i >= list.Count)
                return null;

            return list[i];
        }

        public PressEvent PopNextEvent()
        {
            if (i >= list.Count)
                return null;

            var x = list[i++];
            return x;
        }

        public void AddScenario(PressScenario scenario)
        {
            throw new NotImplementedException();
        }

        private int i = 0;

        private List<PressEvent> list = new List<PressEvent>()
        {
            new MultipleChoiceEvent(
                new MultipleChoiceEventDao("Event1", new List<DecisionChoiceDao>()
                {
                    new DecisionChoiceDao("Choice 1")
                    {
                        Attribs =new AttributeDao[]{new AttributeDao(Attribs.StringCredibility,0) }
                    },
                    new DecisionChoiceDao("Choice 2")
                    {
                        Attribs =new AttributeDao[]{new AttributeDao(Attribs.StringCredibility,700) }
                    },
                    new DecisionChoiceDao("Choice 3")
                    {
                        Attribs =new AttributeDao[]{new AttributeDao(Attribs.StringCredibility,1000) }
                    },
                }), DateTime.Parse("7/11/2018")),
            new MultipleChoiceEvent(
                new MultipleChoiceEventDao("Event2", new List<DecisionChoiceDao>()
                {
                    new DecisionChoiceDao("Choice 1")
                    {
                        Attribs =new AttributeDao[]{new AttributeDao(Attribs.StringCredibility,0) }
                    },
                    new DecisionChoiceDao("Choice 2")
                    {
                        Attribs =new AttributeDao[]{new AttributeDao(Attribs.StringCredibility,700) }
                    },
                    new DecisionChoiceDao("Choice 3")
                    {
                       Attribs =new AttributeDao[]{new AttributeDao(Attribs.StringCredibility,1000) }
                    },
                }), DateTime.Parse("7/11/2018")),

            new CutsceneEvent("TempFolder/temp.png", "The quick brown fox jumps over the lazy dog", DateTime.Parse("7/11/2017")),

            new MultipleChoiceEvent(
                new MultipleChoiceEventDao("Event3", new List<DecisionChoiceDao>()
                {
                    new DecisionChoiceDao("Choice 1")
                    {
                        Attribs =new AttributeDao[]{new AttributeDao(Attribs.StringCredibility,0) }
                    },
                    new DecisionChoiceDao("Choice 2")
                    {
                       Attribs =new AttributeDao[]{new AttributeDao(Attribs.StringCredibility,700) }
                    },
                    new DecisionChoiceDao("Choice 3")
                    {
                        Attribs =new AttributeDao[]{new AttributeDao(Attribs.StringCredibility,1000) }
                    },
                }), DateTime.Parse("7/11/2018")),

        };
    }
}
