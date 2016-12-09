using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Assets.Code.GameState;
using Assets.Code.Model;
using Assets.Code.PressEvents;

namespace Assets.Code.Planning
{
    class RandomEventsScenario:IPressScenario
    {

        private DateTime _lastDate;
        public RandomEventsScenario(DateTime startDate,string path)
        {
            ScenarioDao scenario = XmlUtils.LoadScenario(path);
            converter = new DaoToEventsConverter();
            _events = scenario.Events;
            Random r = new Random();
            //permutate sequence 1..n
            _eventIndexQueue = new Queue<int>(Enumerable.Range(0,_events.Length).OrderBy(x => r.Next()));
            _lastDate = startDate;
            PrepareNextEvent();
        }

        private void PrepareNextEvent()
        {
            _lastDate = _lastDate.AddDays(Algorithms.RandomPauseBetweenEvents());
            converter.AssignedDate = _lastDate;
            if (_eventIndexQueue.Count > 0)
            {
                var eventDao = _events[_eventIndexQueue.Dequeue()];
                Debug.Assert(String.IsNullOrEmpty(eventDao.Date));
                _currentEvent = eventDao.Process(converter);
            }
            else
            {
                _currentEvent = null;
            }
        }

        private PressEvent _currentEvent;
        private Queue<int> _eventIndexQueue;
        private PressEventDao[] _events;
        private DaoToEventsConverter converter;

        public PressEvent PeekNextEvent()
        {
            return _currentEvent;
        }

        public PressEvent PopNextEvent()
        {
            var evt = _currentEvent;
            PrepareNextEvent();
            return evt;
        }
    }
}
