using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Assets.Code.Model;
using Assets.Code.PressEvents;

namespace Assets.Code.Planning
{
    class RandomEventsScenario:IPressScenario
    {
        public RandomEventsScenario(DateTime startDate,string path)
        {
            StreamReader reader = new StreamReader(path);
            XmlSerializer xmlReader = new XmlSerializer(typeof(ScenarioDao));
            ScenarioDao scenario = (ScenarioDao)xmlReader.Deserialize(reader);
            _events = scenario.Events;
            Random r = new Random();
            //permutate sequence 1..n
            _eventIndexQueue = new Queue<int>(Enumerable.Range(0,_events.Length-1).OrderBy(x => r.Next()));
            if (_eventIndexQueue.Count > 0)
            {
                //_currentEvent = _events[_eventIndexQueue.Dequeue()];
                //TODO: Finish
            }
        }

        private PressEvent _currentEvent;
        private Queue<int> _eventIndexQueue;
        private PressEventDao[] _events;

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
