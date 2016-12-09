using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.GameState;
using Assets.Code.Model;

namespace Assets.Code.PressEvents
{
    public class MultipleChoiceEvent : PressEvent
    {
        private MultipleChoiceEventDao data;


        //The list of decision options.
        public List<DecisionChoice> Choices { get; private set; }

        // The question / event description displayed to the player.
        public string Description
        {
            get { return data.Description; }
        }


        public MultipleChoiceEvent(MultipleChoiceEventDao data, DateTime date) : base(date)
        {
            this.data = data;

            Choices = (from x in data.Choices select new DecisionChoice(x)).ToList();
            //Potentially replace placeholders with real names etc.
        }


        public List<DecisionChoice> GetClosestOptions(int count)
        {
            return Algorithms.Closest(Choices, WorldStateProvider.State.JournalistState, count, Attribs.JournalistAttributes);
        }

        //Choose the given option and end this event processing.
        public void Finish(DecisionChoice selectedChoice)
        {
            Algorithms.MoveTowardsPosition(WorldStateProvider.State.JournalistState, selectedChoice.Attributes, Attribs.JournalistAttributes);
            IsFinished = true;
        }


        public override void ProcessEvent(IEventProcessor processor)
        {
            processor.ProcessEvent(this);
        }
    }
}
