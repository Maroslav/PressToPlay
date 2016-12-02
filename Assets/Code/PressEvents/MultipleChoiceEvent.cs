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
        public List<DecisionOption> Options { get; private set; }

        public MultipleChoiceEvent(MultipleChoiceEventDao data, DateTime date) : base(date)
        {
            this.data = data;
            GenerateOptions();
        }

        //Potentially replace placeholders with real names etc.
        private void GenerateOptions()
        {
            Options = (from x in data.Options select new DecisionOption(x)).ToList();
        }


        // The question / event description displayed to the player.
        public string Description
        {
            get { return data.Description; }
        }

        public List<DecisionOption> GetClosestOptions(WorldState state, int count)
        {
            
            //TODO: IMPLEMENT
            return new List<DecisionOption>();
        }
        //Choose the given option and end this event processing.
        public void SelectOption(DecisionOption option)
        {
            //TODO: IMPLEMENT
            IsFinished = true;
        }

        public override void ProcessEvent(IEventProcessor processor)
        {
            processor.ProcessEvent(this);
        }
    }
}
