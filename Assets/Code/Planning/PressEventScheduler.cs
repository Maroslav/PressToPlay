using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Assets.Code.GameState;
using Assets.Code.PressEvents;

namespace Assets.Code.Planning
{
    public class PressEventScheduler : IPressEventScheduler
    {
        private List<IPressScenario> _scenarios;
        private DateTime _currentDate;
        private readonly WorldState _worldState;
        private DateTime _endDate;
        public PressEventScheduler(WorldState worldState, DateTime startDate, DateTime endDate, params IPressScenario[] scenarios)
        {
            _worldState = worldState;
            _endDate = endDate;
            _currentDate = startDate;
            _scenarios = scenarios.ToList();
        }

        private PressEvent GetNextEvent()
        {
            PressEvent pressEvent;
            do
            {
                var minScenario = GetClosestEventScenario();
                if (minScenario == null)
                {
                    return null;
                }
                pressEvent = minScenario.PopNextEvent();
                if (pressEvent.Date > _currentDate)
                {
                    Debug.Assert(false, "The next event has date smaller than the current date");
                }
                _currentDate = pressEvent.Date;
                //Remove scenario if empty:
                if (minScenario.IsTerminated)
                {
                    _scenarios.Remove(minScenario);
                }
            } while (!pressEvent.CheckConditions(_worldState));
            StartEvent(pressEvent);
            return pressEvent;
        }

        private void StartEvent(PressEvent pressEvent)
        {
            _worldState.Date = pressEvent.Date;
            if (pressEvent.IsTerminating)
            {
                _scenarios.Clear();
            }
        }

        // Gets the scenario that contains event with smallest time value
        private IPressScenario GetClosestEventScenario()
        {
            DateTime min = _endDate;
            IPressScenario minScenario = null;
            foreach (var scenario in _scenarios)
            {
                var nextEvent = scenario.PeekNextEvent();
                if (nextEvent == null) continue;
                if (min >= nextEvent.Date)
                {
                    min = nextEvent.Date;
                    minScenario = scenario;
                }
            }
            return minScenario;
        }

        public void AddScenario(IPressScenario scenario)
        {
            while (scenario.PeekNextEvent().Date < _currentDate)
            {
                scenario.PopNextEvent();
            }
            if (scenario.PeekNextEvent() != null)
            {
                _scenarios.Add(scenario);
            }

        }

        public PressEvent PopNextEvent()
        {
            if (_scenarios.Count == 0) return null;
            var nextEvent = GetNextEvent();
            if (nextEvent == null) return null;
            if (nextEvent.Date > _endDate)
            {
                _scenarios.Clear();
                return null;
            }
            return nextEvent;
        }
    }
}
