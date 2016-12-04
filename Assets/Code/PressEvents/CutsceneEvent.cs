using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.PressEvents
{
    public class CutsceneEvent : PressEvent
    {

        public CutsceneEvent(DateTime date)
            : base(date)
        {
            
        }


        public override void ProcessEvent(IEventProcessor processor)
        {
            processor.ProcessEvent(this);
        }
    }
}
