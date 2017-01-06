﻿using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.GameState;
using Assets.Code.Model;
using Assets.Code.PressEvents.Choices;
using Assets.Code.PressEvents.Preconditions;

namespace Assets.Code.PressEvents
{
    public abstract class PressEvent
    {
        public DateTime Date { get; set; }
        public bool IsFinished { get;protected set; }
        public List<Precondition> Preconditions{ get; private set; }
        public bool IsTerminating { get; private set; }

        private PressEvent(DateTime date)
        {
            Date = date;
            IsFinished = false;
        }
        protected PressEvent(DateTime date, bool isTerminating, List<Precondition> preconditions) : this(date)
        {
            Preconditions = preconditions;
            IsTerminating = isTerminating;
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

        public virtual void Finish(Choice selectedChoice, WorldState worldState)
        {
            selectedChoice.ApplyEffects(worldState);
            IsFinished = true;
        }
    }
}
