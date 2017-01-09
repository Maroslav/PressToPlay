using System;
using System.Collections.Generic;
using Assets.Code.GameState;
using Assets.Code.PressEvents.Choices;
using Assets.Code.PressEvents.Preconditions;

namespace Assets.Code.PressEvents
{
    public class MultipleChoiceEvent : ChoicePressEvent
    {
        public MultipleChoiceEvent(string descr, string name, DateTime d, List<TextChoice> choices, bool isTerminating, List<Precondition> precond = null)
            : base(descr, d,name,isTerminating, precond ?? new List<Precondition>())
        {
            Choices = choices;
        }


        //The list of decision options.
        public List<TextChoice> Choices { get; private set; }

        public List<TextChoice> GetClosestOptions(int count)
        {
            return Algorithms.Closest(Choices, WorldStateProvider.State, count);
        }


        public override void ProcessEvent(IEventProcessor processor)
        {
            processor.ProcessEvent(this);
        }
    }
}