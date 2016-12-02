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
                new MultipleChoiceEventDao("Event1", new List<DecisionChoiceDao>()
                {
                    new DecisionChoiceDao("Choice 1")
                    {
                        Attribs = new Attribs(new Dictionary<Attrib, int>() {{Attribs.Credibility, 0}})
                    },
                    new DecisionChoiceDao("Choice 2")
                    {
                        Attribs = new Attribs(new Dictionary<Attrib, int>() {{Attribs.Credibility, 700}})
                    },
                    new DecisionChoiceDao("Choice 3")
                    {
                        Attribs = new Attribs(new Dictionary<Attrib, int>() {{Attribs.Credibility, 1000}})
                    },
                }), DateTime.Parse("7/11/2018"))  
        };
    }
}
