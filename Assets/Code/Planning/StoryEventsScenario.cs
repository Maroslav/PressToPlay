using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Assets.Code.Model;
using Assets.Code.PressEvents;

namespace Assets.Code.Planning
{
    class StoryEventsScenario:IPressScenario
    {
        private readonly Queue<PressEventDao> _eventQueue;
        private PressEvent _nextEvent;
        private readonly DaoToEventsConverter _processor= new DaoToEventsConverter();
        public StoryEventsScenario(string path)
        {
            var scenario = XmlUtils.LoadScenario(path);
            _eventQueue=new Queue<PressEventDao>(scenario.Events);
            PrepareNextEvent();

        }

        private void PrepareNextEvent()
        {
            if (_eventQueue.Count == 0)
            {
                _nextEvent = null;
                return;
            }
            var pressEventDao = _eventQueue.Dequeue();
            Debug.Assert(!string.IsNullOrEmpty(pressEventDao.Date), "Story events should contain date.");
            _nextEvent = pressEventDao.Process(_processor);

        }

        public PressEvent PeekNextEvent()
        {
            return _nextEvent;
        }

        public PressEvent PopNextEvent()
        {
            var evt = _nextEvent;
            PrepareNextEvent();
            return evt;
        }
    }
}
