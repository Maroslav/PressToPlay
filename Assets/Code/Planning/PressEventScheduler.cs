using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Assets.Code.GameState;
using Assets.Code.PressEvents;

namespace Assets.Code.Planning
{
    class PressEventScheduler:IPressEventScheduler
    {
        private List<IPressScenario> _scenarios;
        private DateTime _currentDate;
        private readonly WorldState _worldState;
        private DateTime _endDate;
        private PressEvent _currentEvent = null;
        public PressEventScheduler(WorldState worldState, DateTime startDate, DateTime endDate, params IPressScenario[] scenarios)
        {
            _worldState = worldState;
            _endDate = endDate;
            _currentDate = startDate;
            _scenarios = scenarios.ToList();
            PrepareNextEvent();
        }

        private void PrepareNextEvent()
        {
            IPressScenario minScenario;
            do
            {
                minScenario = GetClosestEventScenario();
                if (minScenario == null)
                {
                    _currentEvent = null;
                    return;
                }
                _currentEvent = minScenario.PopNextEvent();
                if (_currentEvent.Date > _currentDate)
                {
                    Debug.Assert(false, "The next event has date smaller than the current date");
                }
                _currentDate = _currentEvent.Date;
                //Remove scenario if empty:
                if (minScenario.PeekNextEvent() == null)
                {
                    _scenarios.Remove(minScenario);
                }
            } while (!_currentEvent.CheckConditions(_worldState));
            


        }
        // Gets the scenario that contains event with smallest time value
        private IPressScenario GetClosestEventScenario()
        {
            DateTime min = _endDate;
            IPressScenario minScenario = null;
            foreach (var scenario in _scenarios)
            {
                var nextEvent = scenario.PeekNextEvent();
                if (min > nextEvent.Date)
                {
                    min = nextEvent.Date;
                    minScenario = scenario;
                }
            }
            return minScenario;
        }

        public void AddScenario(PressScenario scenario)
        {
            _scenarios.Add(scenario);
            while (scenario.PeekNextEvent().Date < _currentDate)
            {
                scenario.PopNextEvent();
            }
        }

        public PressEvent PeekNextEvent()
        {
            return _currentEvent;
        }

        public PressEvent PopNextEvent()
        {
            var ret = _currentEvent;
            PrepareNextEvent();
            return ret;
        }
    }
}
