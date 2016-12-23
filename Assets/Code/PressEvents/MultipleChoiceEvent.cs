using System;
using System.Collections.Generic;
using Assets.Code.GameState;
using Assets.Code.PressEvents.Choices;
using Assets.Code.PressEvents.Preconditions;

namespace Assets.Code.PressEvents
{
    public class MultipleChoiceEvent : PressEvent
    {
        public MultipleChoiceEvent(string descr, DateTime d, List<TextChoice> choices, List<Precondition> precond = null)
            : base(d, precond ?? new List<Precondition>())
        {
            Description = descr;
            Choices = choices;
        }


        //The list of decision options.
        public List<TextChoice> Choices { get; private set; }

        // The question / event description displayed to the player.
        public string Description { get; private set; }

        public List<TextChoice> GetClosestOptions(int count)
        {
            return Algorithms.Closest(Choices, WorldStateProvider.State.JournalistState, count,
                Attribs.JournalistAttributes);
        }

        //Choose the given option and end this event processing.
        public void Finish(TextChoice selectedChoice)
        {
            Algorithms.MoveTowardsPosition(WorldStateProvider.State.JournalistState, selectedChoice.Attributes,
                Attribs.JournalistAttributes);
            IsFinished = true;
        }


        public override void ProcessEvent(IEventProcessor processor)
        {
            processor.ProcessEvent(this);
        }
    }
}