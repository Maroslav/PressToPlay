using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.GameState;
using Assets.Code.PressEvents.Choices;
using Assets.Code.PressEvents.Preconditions;

namespace Assets.Code.PressEvents
{
    ///
    /// Paths to images are stored in the choices property.
    /// 
    public class ImageChoiceEvent:PressEvent
    {
        public ImageChoiceEvent(DateTime date, List<Precondition> preconditions, List<ImageChoice> choices, string description
            ) : base(date, preconditions)
        {
            Choices = choices;
            Description = description;
        }

        public string Description { get; set; }
        public List<ImageChoice> Choices { get; set; }
        public override void ProcessEvent(IEventProcessor processor)
        {
            processor.ProcessEvent(this);
        }

        public void Finish(ImageChoice selectedChoice, WorldState worldState)
        {
            selectedChoice.ApplyEffects(worldState);
            IsFinished = true;
        }
    }
}
