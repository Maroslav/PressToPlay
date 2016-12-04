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

        public MultipleChoiceEvent(MultipleChoiceEventDao data, DateTime date) : base(date)
        {
            this.data = data;
            GenerateChoice();
        }

        //Potentially replace placeholders with real names etc.
        private void GenerateChoice()
        {
            Choices = (from x in data.Options select new DecisionChoice(x)).ToList();
        }


        // The question / event description displayed to the player.
        public string Description
        {
            get { return data.Description; }
        }

        public List<DecisionChoice> GetClosestOptions(WorldState state, int count)
        {
            return Algorithms.Closest(Choices,state.JournalistState,count,Attribs.JournalistAttributes);
        }
        //Choose the given option and end this event processing.
        public void FinishEvent(DecisionChoice selectedChoice, WorldState state)
        {
            Algorithms.MoveTowardsPosition(state.JournalistState,selectedChoice.Attributes,Attribs.JournalistAttributes);
            IsFinished = true;
        }

        public override void ProcessEvent(IEventProcessor processor)
        {
            processor.ProcessEvent(this);
        }
    }
}
