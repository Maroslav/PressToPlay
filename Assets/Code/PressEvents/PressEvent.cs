using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.GameState;
using Assets.Code.Model;
using Assets.Code.PressEvents.Preconditions;

namespace Assets.Code.PressEvents
{
    public abstract class PressEvent
    {
        public DateTime Date { get; private set; }
        public bool IsFinished { get;protected set; }
        public List<Precondition> Preconditions{ get; set; }

        private PressEvent(DateTime date)
        {
            Date = date;
            IsFinished = false;
        }
        protected PressEvent(DateTime date, List<Precondition> preconditions) : this(date)
        {
            Preconditions = preconditions;
        }
        
        public bool CheckConditions(WorldState state)
        {
            foreach (var precondition in Preconditions)
            {
                if (!precondition.Check(state)) return false;
            }
            return true;
        }
        //Visitor pattern, corresponds to the 'accept' method.
        public abstract void ProcessEvent(IEventProcessor processor);



    }
}
