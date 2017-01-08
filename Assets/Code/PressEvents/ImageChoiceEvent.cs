using System;
using System.Collections.Generic;
using Assets.Code.PressEvents.Choices;
using Assets.Code.PressEvents.Preconditions;

namespace Assets.Code.PressEvents
{
    ///
    /// Paths to images are stored in the choices property.
    /// 
    public class ImageChoiceEvent:ChoicePressEvent
    {
        public ImageChoiceEvent(DateTime date, string name, bool isTerminating, List<Precondition> preconditions, List<ImageChoice> choices, string description
            ) : base(date,name, isTerminating, preconditions)
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
    }
}
