using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Assets.Code.GameState;
using Assets.Code.Model;
using Assets.Code.PressEvents;
using Assets.Code.PressEvents.Construction;

namespace Assets.Code.Planning
{
    class RandomEventsScenario:IPressScenario
    {
        private PressEvent _currentEvent;
        private Queue<int> _eventIndexQueue;
        private PressEventDao[] _events;
        private DaoToEventsConverter _converter;
        private DateTime _lastDate;

        public RandomEventsScenario(DateTime startDate,string path)
        {
            ScenarioDao scenario = XmlUtils.LoadScenario(path);
            _converter = new DaoToEventsConverter();
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
            _converter.AssignedDate = _lastDate;
            if (_eventIndexQueue.Count > 0)
            {
                var eventDao = _events[_eventIndexQueue.Dequeue()];
                Debug.Assert(string.IsNullOrEmpty(eventDao.Date));
                _currentEvent = eventDao.Process(_converter);
            }
            else
            {
                _currentEvent = null;
            }
        }

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
