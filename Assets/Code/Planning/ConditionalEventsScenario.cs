using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.GameState;
using Assets.Code.Model;
using Assets.Code.PressEvents;
using Assets.Code.PressEvents.Construction;

namespace Assets.Code.Planning
{
    public class ConditionalEventsScenario:IPressScenario
    {
        
        private WorldState _worldState;
        private List<PressEvent> _events;

        public ConditionalEventsScenario(string path, WorldState worldState)
        {
            this._worldState = worldState;
            var scenario = XmlUtils.LoadScenario(path);
            DaoToEventsConverter processor = new DaoToEventsConverter();
            _events = new List<PressEvent>(scenario.Events.Length);
            foreach (var eventDao in scenario.Events)
            {
                _events.Add(eventDao.Process(processor));
            }
            
        }

        public PressEvent PeekNextEvent()
        {
            PressEvent next=GetFirstSatisfied();
            if (next == null) return null;
            next.Date = _worldState.Date;
            return next;
        }
        public PressEvent PopNextEvent()
        {
            PressEvent next = GetFirstSatisfied();
            if (next == null) return null;
            next.Date = _worldState.Date;
            _events.Remove(next);
            return next;
        }

        private PressEvent GetFirstSatisfied()
        {
            foreach (var pressEvent in _events)
            {
                if (pressEvent.CheckConditions(_worldState))
                {
                    return pressEvent;
                }
            }
            return null;
        }

        public bool IsTerminated
        {
            get { return _events.Count == 0; }
        }
    }
}
