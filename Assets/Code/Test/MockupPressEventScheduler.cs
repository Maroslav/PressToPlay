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
    class MockupPressEventScheduler:IPressEventScheduler
    {
      
        public PressEvent PeekNextEvent()
        {
            return list[i];
        }

        public PressEvent PopNextEvent()
        {
            var x = list[i];
            i = (i + 1)%list.Capacity;
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
                new MultipleChoiceEventDao("Event1",new List<DecisionDao>()
                {
                    new DecisionDao("Choice 1")
                    {
                        Attributes = new Dictionary<string, int>()
                        {
                            {Attributes.Credibility, 0}
                        }
                    },
                     new DecisionDao("Choice 2")
                    {
                        Attributes = new Dictionary<string, int>()
                        {
                            {Attributes.Credibility, 700}
                        }
                    },
                      new DecisionDao("Choice 3")
                    {
                        Attributes = new Dictionary<string, int>()
                        {
                            {Attributes.Credibility, 1000}
                        }
                    }
                }), DateTime.Parse("7/11/2018")),
            new MultipleChoiceEvent(
                new MultipleChoiceEventDao("Event 2",new List<DecisionDao>()
                {
                    new DecisionDao("Choice 1")
                    {
                        Attributes = new Dictionary<string, int>()
                        {
                            {Attributes.Credibility, 0}
                        }
                    },
                     new DecisionDao("Choice 2")
                    {
                        Attributes = new Dictionary<string, int>()
                        {
                            {Attributes.Credibility, 700}
                        }
                    },
                      new DecisionDao("Choice 3")
                    {
                        Attributes = new Dictionary<string, int>()
                        {
                            {Attributes.Credibility, 1000}
                        }
                    }
                }), DateTime.Parse("7/10/2018")),
            new MultipleChoiceEvent(
                new MultipleChoiceEventDao("Event3",new List<DecisionDao>()
                {
                    new DecisionDao("Choice 1")
                    {
                        Attributes = new Dictionary<string, int>()
                        {
                            {Attributes.Credibility, 0}
                        }
                    },
                     new DecisionDao("Choice 2")
                    {
                        Attributes = new Dictionary<string, int>()
                        {
                            {Attributes.Credibility, 700}
                        }
                    },
                      new DecisionDao("Choice 3")
                    {
                        Attributes = new Dictionary<string, int>()
                        {
                            {Attributes.Credibility, 1000}
                        }
                    }
                }), DateTime.Parse("7/7/2018"))
        };
    }
}
