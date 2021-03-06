﻿using System;
using System.Collections.Generic;
using Assets.Code.GameState;
using Assets.Code.PressEvents.Choices;
using Assets.Code.PressEvents.Preconditions;

namespace Assets.Code.PressEvents
{
    public abstract class ChoicePressEvent : PressEvent
    {
        // The question / event description displayed to the player.
        public string Description { get; private set; }


        protected ChoicePressEvent(string description, DateTime date, string name, bool isTerminating,
            List<Precondition> preconditions) : base(date, name, isTerminating, preconditions)
        {
            Description = description;
        }


        public virtual void Apply(Choice selectedChoice, WorldState worldState)
        {
            selectedChoice.ApplyEffects(worldState);
        }
    }
}
