using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.PressEvents.Choices;
using Assets.Code.PressEvents.Preconditions;

namespace Assets.Code.PressEvents
{
    ///
    /// Paths to images are stored in the choices property.
    /// 
    public class ImageChoiceEvent:PressEvent
    {
        public ImageChoiceEvent(DateTime date, List<Precondition> preconditions) : base(date, preconditions)
        {
        }

        public string Description { get; set; }
        public List<ImageChoice> Choices { get; set; }
        public override void ProcessEvent(IEventProcessor processor)
        {
            processor.ProcessEvent(this);
        }
    }
}
