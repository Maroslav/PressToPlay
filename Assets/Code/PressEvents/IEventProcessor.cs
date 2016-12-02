using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.PressEvents
{
    //Visitor pattern, corresponds to the 'Visitor class'
    public interface IEventProcessor
    {
        void ProcessEvent(MultipleChoiceEvent e);
    }
}
